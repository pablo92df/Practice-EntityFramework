using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.Data;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entities;
using EFCorePeliculas.Entities.SinLlaves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/cine")]
    public class CineController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CineController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CineDTO>> Get() 
        {
            return await context.Cines.ProjectTo<CineDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
        [HttpGet("SinUbicacion")]
        public async Task<IEnumerable<CineSinUbicacion>> GetCinesSinUbicacion() 
        {
            //SET permite crear en tiempo real un DTO esta opcion es si no creo el DBset de CineSinUbicacion
          //  return await context.Set<CineSinUbicacion>().ToListAsync();

            return await context.CineSinUbicacions.ToListAsync();
        }

        [HttpGet("cercanos")]
        public async Task<ActionResult> Get(double latitud, double longitud) 
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(longitud, latitud));
            var distanciaMaxima = 2000;
            var cines = await context.Cines
                .OrderBy(c => c.Ubicacion.Distance(miUbicacion))
                .Where(c=> c.Ubicacion.IsWithinDistance(miUbicacion, distanciaMaxima))
                .Select(c => new { 
                    Nombre = c.Name,
                    Distancia = Math.Round(c.Ubicacion.Distance(miUbicacion))
                }).ToListAsync();

            return Ok(cines);
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(-69.896979, 18.476276));

            var cine = new Cine()
            {
                Name = "Mi cine",
                Ubicacion = miUbicacion,
                CineOferta = new CineOferta()
                {
                    PorcentajeDescuento = 5,
                    FechaInicio = DateTime.Today,
                    FechaFin = DateTime.Today.AddDays(7)
                },
                SalasDeCines = new HashSet<SalaDeCine>()
                {
                    new SalaDeCine()
                    {
                        Precio = 200,
                        TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
                    },
                    new SalaDeCine()
                    {
                        Precio = 250,
                        TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
                    }
                }
            };
            context.Add(cine);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("conDTO")]
        public async Task<ActionResult> Post(CineCreacionDTO cineCreacionDTO)
        {
            var cine = mapper.Map<Cine>(cineCreacionDTO);
            context.Add(cine);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //cargo el cineoferta en memoria para que entityframework pueda modificar el id de cine cuando lo borro sino tira error
            var cines = await context.Cines.Include(c => c.CineOferta).FirstOrDefaultAsync(x => x.Id == id);

            if (cines is null)
            { 
                return NotFound();
            }

            context.Remove(cines);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
