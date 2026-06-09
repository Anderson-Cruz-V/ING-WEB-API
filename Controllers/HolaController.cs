using Microsoft.AspNetCore.Http;
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
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest(new
                {
                    mensaje = "Debe ingresar un nombre."
                });
            }

            string mensajeBienvenida = "Bienvenido " + nombre;

            return Ok(new
            {
                mensaje = mensajeBienvenida
            });
        }
    }
}