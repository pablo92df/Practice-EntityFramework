using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.Data;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/pelicula")]
    public class PeliculaController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id) 
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Generos.OrderByDescending(g=>g.Nombre))
                .Include(p => p.SalaDeCines)
                    .ThenInclude(s => s.Cine)
                .Include(p => p.PeliculasActores.Where(pa => pa.Actor.FechaNacimiento.Value.Year >= 1980))
                    .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula is null) 
            {
                return NotFound();
            }
            //mapper sin projectTo
            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);

            //me traia los cines repetidos
            peliculaDTO.Cines = peliculaDTO.Cines.DistinctBy(x => x.Id).ToList();
            return peliculaDTO;
        }
        //cuando uso projectTo no es necesario usar los include el mapper se encarga de las relaciones
        //para el ordenamiento lo tengo que hacer en la configuracion del automapper
        [HttpGet("conprojectto{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetProjectTo(int id)
        {
            var pelicula = await context.Peliculas
               .ProjectTo<PeliculaDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula is null)
            {
                return NotFound();
            }


            //me traia los cines repetidos
            pelicula.Cines = pelicula.Cines.DistinctBy(x => x.Id).ToList();
            return pelicula;
        }
        [HttpGet("cargadoselectivo/{id:int}")]
        public async Task<ActionResult> GetSelectivo(int id) 
        {
            var pelicula = await context.Peliculas.Select(p=> 
            new 
            { 
                Id = p.Id,
                Nombre = p.Name,
                Generos = p.Generos.Select(g => g.Nombre).ToList(),
                CantidadActores = p.PeliculasActores.Count(),
                CantidadCines = p.SalaDeCines.Select(s => s.CineId).Distinct().Count(),
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula is null) 
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpGet("cargadoexplicito/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetExplicito(int id) 
        {

            //carga explicita en general es util si necesito separar la carga de la entidad principal con la relacionada
            var pelicula = await context.Peliculas.AsTracking().FirstOrDefaultAsync(p => p.Id == id);
            //la desventaja de los query asi es que es mas lento porque hago mas consultas 
            await context.Entry(pelicula).Collection(p=>p.Generos).LoadAsync();

            var cantidadGeneros = await context.Entry(pelicula).Collection(p=> p.Generos).Query().CountAsync();
            if(pelicula is null) 
            {
                return NotFound();
            }

            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);

            return peliculaDTO;
        }

        [HttpGet("lazyloading/{id:int}")]
        //lazyloading es lento por la cantidad de consultas, si esta en memoria el dato lo toma sino tiene que hacerce una consulta.
        //hay que poner en virtual a las entidades
        public async Task<ActionResult<PeliculaDTO>> GetLazyLoading(int id) 
        {
            var pelicula = await context.Peliculas.AsTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula is null) 
            {
                return NotFound();
            }

            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);
            peliculaDTO.Cines = peliculaDTO.Cines.DistinctBy(x => x.Id).ToList();
            return peliculaDTO;

        }

        [HttpGet("agrupadasPorEstreno")]
        public async Task<ActionResult> GetAgrupadasPorCartelera()
        {
            var peliculasAgrupadas = await context.Peliculas.GroupBy(p=>p.EnCartelera)
                                            .Select(g => new
                                            {
                                                EnCartelera = g.Key,
                                                Conteo = g.Count(),
                                                Peliculas = g.ToList()
                                            }).ToListAsync();

            return Ok(peliculasAgrupadas);
        }
        [HttpGet("agrupadasPorCantidadDeGeneros")]

        public async Task<ActionResult> GetAgrupadasPorCantidadDeGeneros()
        {
            var peliculasAgrupadas = await context.Peliculas.GroupBy(p => p.Generos.Count())
                                                             .Select(g => new
                                                             {
                                                                 Conteo = g.Key,
                                                                 Titulos = g.Select(x => x.Name),
                                                                 Generos = g.Select(p => p.Generos).SelectMany(gen => gen).Select(gen => gen.Nombre).Distinct()
                                                                 //con selec many hago que esten en un solo array, porque sino aparecia un array de generos por cada peli
                                                             }).ToListAsync();
            return Ok(peliculasAgrupadas);
        }

        [HttpGet("filtrar")]
        //el from query es porque estoy recibiendo un dato complejo, permite recibir desde query string
        //usamos concepto de ejecucion diferida
        //al ser AsQueryable podemos ir armando el filtrado paso por paso
        public async Task<ActionResult<List<PeliculaDTO>>> Filtrar([FromQuery]
                            PeliculasFiltroDTO peliculasFiltroDTO)
        { 
            var peliculasQueryable = context.Peliculas.AsQueryable();
            if (!string.IsNullOrEmpty(peliculasFiltroDTO.Name)) 
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.Name.Contains(peliculasFiltroDTO.Name));
            }

            if (peliculasFiltroDTO.EnCartelera)
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.EnCartelera);
            }
            if (peliculasFiltroDTO.ProximosEstrenos) 
            {
                var hoy = DateTime.Today;
                peliculasQueryable = peliculasQueryable.Where(p => p.FechaEstreno > hoy);
            }

            if (peliculasFiltroDTO.GeneroId != 0)
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.Generos
                                            .Select(g => g.Id)
                                            .Contains(peliculasFiltroDTO.GeneroId));
            }
            var peliculas = await peliculasQueryable.Include(p=>p.Generos).ToListAsync();

            return mapper.Map<List<PeliculaDTO>>(peliculas);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO peliculaCreacionDTO) 
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);
            //le digo a entity framework que los generos que estoy pasando son generos de consulta que ya existe
            //y que solo los quiero agregar como relacion sin modificar ni crear nuevos
            //y para que no sean modificados es con el unchanged, esto ignora modificar, agregar o borrar solo crea la relacion
            pelicula.Generos.ForEach(g => context.Entry(g).State = EntityState.Unchanged);
            pelicula.SalaDeCines.ForEach(s => context.Entry(s).State = EntityState.Unchanged);

            if (pelicula.PeliculasActores is not null) 
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++) 
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
