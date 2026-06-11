using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolaController : ControllerBase
    {
        [HttpGet("saludo")]
        public IActionResult Saludo([FromQuery] string nombre)
        {
            string mensaje = "";

            if (nombre == null || nombre == "")
            {
                mensaje = "Debe ingresar un nombre.";

                return BadRequest(new
                {
                    mensaje = mensaje
                });
            }
            else
            {
                mensaje = "Bienvenido " + nombre;

                return Ok(new
                {
                    mensaje = mensaje
                });
            }
        }
    }
}