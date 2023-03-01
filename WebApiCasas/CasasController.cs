using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApiCasas.Entidades;

namespace WebApiCasas.Controllers
{
    [ApiController]
    [Route("api/casas")]
    public class CasasController : ControllerBase
    {
        [HttpGet]

        public ActionResult<List<Casa>> Get() 
        {
            return new List<Casa>() {
                new Casa() {idCasa = 1, numeroCasa =142, pisos=1, ancho=7, largo = 16, calle="Juan XXIII"},
                new Casa() { idCasa = 2, numeroCasa =639, pisos=2, ancho=6, largo = 15, calle="Ejido San Nicolás"}
            };
        
            }

        

    }
}
