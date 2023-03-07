using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasas.Entidades;

namespace WebApiCasas.Controllers
{
    [ApiController]
    [Route("habitante")]
    public class HabitanteController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public HabitanteController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Habitante>>> GetAll()
        {
            return await dbContext.Habitante.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Habitante>> GetByID(int id)
        {
            return await dbContext.Habitante.FirstOrDefaultAsync(x => x.ID == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Habitante habitante)
        {
            var existeCasa = await dbContext.Casas.AnyAsync(x => x.ID == habitante.CasaID);

            if (!existeCasa)
            {
                return BadRequest("No existe la casa");
            }

            dbContext.Add(habitante);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Habitante habitante, int id)
        {
            var existeHabitante = await dbContext.Habitante.AnyAsync(x => x.ID == habitante.ID);

            if (!existeHabitante)
            {
                return BadRequest("No existe el habitante");
            }

            if (habitante.ID != id)
            {
                return BadRequest("El ID del habitante no coincide en la URL ");
            }

            dbContext.Update(habitante);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.Habitante.AnyAsync(x => x.ID == id);
            if (!exists)
            {
                return NotFound("No existe habitante con tal ID");
            }

            dbContext.Remove(new Habitante()
            {
                ID = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
