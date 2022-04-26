using EFCorePeliculas.Data;
using EFCorePeliculas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenerosController(ApplicationDbContext context)
        {
            this.context = context; 
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get() 
        {
            // el asnotracking es para hacer consultas de solo lectura, son consultas mas rapidas que las normales
            //si uso astracking puedo tener seguimientos de los cambios en la entidad para despues guarda con savechanges
            // return await context.Generos.AsNoTracking().ToListAsync();



            //return await context.Generos.ToListAsync();
            //ordeno por una propiedad sombra, crea una columna sin modificar la entidad Genero
            return await context.Generos.OrderByDescending(g=>EF.Property<DateTime>(g,"FechaCreacion")).ToListAsync();


        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id) 
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g=>g.Id == id);

            if (genero is null) 
            {
                return NotFound();
            }
            //busco el valor de la propiedad sombra
            var fechaCreacion = context.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue;

            return Ok(new
            {
                Id = genero.Id,
                NoContent = genero.Nombre,
                fechaCreacion

            });

           
        
        }
        [HttpGet("primer")]
        public async Task<Genero> Primer()
        {
            //First si no coincide niguno en la busqueda arroja error mientras que FirstOrDefault si no encuentra arroja null

            return await context.Generos.FirstAsync();
        }

        [HttpGet("filtrar")]
        public async Task<IEnumerable<Genero>> Filtrar(string nombre) 
        {
            //return await context.Generos.Where(g=>g.Nombre.StartsWith("C") || 
            //                                   g.Nombre.StartsWith("A")
            //                                   ).ToListAsync();
            //no importa el orden el order o el where
            return await context.Generos
                .Where(g => g.Nombre.Contains(nombre)
                ).OrderBy(g=>g.Nombre)
                .ToListAsync();                               
        }
        //[HttpGet("Paginacion")]
        //public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion(int pagina = 1)
        //{
        //    var cantidadRegistroPorPagina = 2;
        //    //take toma de a dos en este caso, puedo cambiar la variable.
        //    //skip se salta el registro que uno ponga. por ejemplo se salta el primero
        //    //implementacion de paginacion
        //    var generos = await context.Generos
        //        .Skip((pagina -1)*cantidadRegistroPorPagina)
        //        .Take(cantidadRegistroPorPagina)
        //        .ToListAsync();
        //    return generos;


        //}


        //////////////INSERTAR/////////////////
        [HttpPost("ungenero")]
        public async Task<ActionResult> Post(Genero genero)
        {
            var existeGenero = await context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if (existeGenero)
            {
                return BadRequest("Ya existe un genero con ese nombre" + genero.Nombre);
            }

            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        //se pueden agregar varias operaciones ADD y al final puede hacerse el savechanges
        //las operaciones puden ser de distintas entidades
        public async Task<ActionResult> Post(Genero[] generos)
        {
            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("agrgar2")]
        //actualizando registro con modelos conectado, es conectado porque traigo la data de la base de dato y le agrego info a esa data
        //uso el mismo DBcontext
        public async Task<ActionResult> Post(int id) 
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g=>g.Id == id);
            if (genero is null) 
            {
                return NotFound();
            }
            genero.Nombre += " 2";
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            context.Remove(genero);
            await context.SaveChangesAsync();
            return Ok();
        }
        //borrado suave o logico no lo borra pero lo deja marcado 
        //un atributo es booleano y puedo agregar filtro al modelo para que no muestre esos datos
        //este filtro se puede saltar por si se quiere reestablecer el dato
        [HttpDelete("borradosuave/{id:int}")]
        public async Task<ActionResult> DeleteSuave(int id)
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = true;
      
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("restaurar/{id:int}")]
        public async Task<ActionResult> DeleteRestaurar(int id)
        {
            var genero = await context.Generos.AsTracking()
                                                .IgnoreQueryFilters()
                                                .FirstOrDefaultAsync(g => g.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = true;

            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
