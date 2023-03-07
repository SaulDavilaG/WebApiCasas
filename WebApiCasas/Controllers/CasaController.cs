using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasas.Entidades;

namespace WebApiCasas.Controllers;

[ApiController]
[Route("casa")]
public class CasaController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;
    public CasaController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet]

    public ActionResult<List<Casa>> Get()
    {
        return new List<Casa>() {
            new Casa() {ID = 1, numeroCasa =142, pisos=1, ancho=7, largo = 16, calle="Juan XXIII"},
            new Casa() { ID = 2, numeroCasa =639, pisos=2, ancho=6, largo = 15, calle="Ejido San Nicolás"}
        };

    }

    [HttpPost]
    public async Task<ActionResult> Post(Casa casa)
    {
        dbContext.Add(casa);
        await dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("/lista")]
    public async Task<ActionResult<List<Casa>>> GetAll()
    {
        return await dbContext.Casas.Include(x => x.habitantes).ToListAsync();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(Casa casa, int id)
    {
        if (casa.ID != id)
        {
            return BadRequest("El ID de la casa no coincide con el establecido en la url");
        }

        dbContext.Update(casa);
        await dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var exists = await dbContext.Casas.AnyAsync(x =>x.ID == id);
        if (!exists) 
        { 
            return NotFound("No existe registro con tal ID");
        }

        dbContext.Remove(new Casa()
        {
            ID = id
        });
        await dbContext.SaveChangesAsync();
        return Ok();
    }

}   
