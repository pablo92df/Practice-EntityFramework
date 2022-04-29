using EFCorePeliculas.Data;
using EFCorePeliculas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController
    {
        private readonly ApplicationDbContext context;

        public ProductosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpGet("merch")]
        public async Task<ActionResult<IEnumerable<Merchandising>>> GetMerch()
        {
            //en las consultas de tablas por tipo mejor usar SET que produce una mejor query
            return await context.Set<Merchandising>().ToListAsync();
        }

        [HttpGet("alquileres")]
        public async Task<ActionResult<IEnumerable<PeliculaAlquilable>>> GetPeliculaAlquilable()
        {
            //en las consultas de tablas por tipo mejor usar SET que produce una mejor query
            return await context.Set<PeliculaAlquilable>().ToListAsync();
        }

    }
}
