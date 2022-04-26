using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.Data;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        //inyecto el automapper
        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get() 
        {
            //Entity framework genera un query y trae la data que queremos desde la base de datos. 
            // var actores = await context.Actors.Select(a => new { Id = a.Id, Name = a.Name}).ToListAsync();
            //return Ok(actores);

            //Mapeo al DTO a mano
            // return  await context.Actors.Select(a => new ActorDTO { Id = a.Id, Name = a.Name}).ToListAsync();

            //mapero con autoMapper
            //en projectto<> pongo hacia donde quiero hacer la proyeccion
            return await context.Actors.ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();

        }
        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ActorCreacionDTO actorCreacionDTO, int id) 
        {
            var actorDB = await context.Actors.AsTracking().FirstOrDefaultAsync(a => a.Id == id);

            if(actorDB is null)
            {
                return NotFound();
            }
            //con este mapeo actualizo los datos, como actualizo el objeto en memoria entity framework le puede seguir dando seguimiento
            actorDB = mapper.Map(actorCreacionDTO, actorDB);

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("desconectado/{id:int}")]
        public async Task<ActionResult> PutDesconectado(ActorCreacionDTO actorCreadionDTO, int id) 
        {
            var existeActor = await context.Actors.AnyAsync(a => a.Id == id);

            if (!existeActor) 
            {
                return NotFound();
            }

            var actor = mapper.Map<Actor>(actorCreadionDTO);
            actor.Id = id;
            context.Update(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
