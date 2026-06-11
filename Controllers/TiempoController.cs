using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiempoController : ControllerBase
    {
        [HttpGet("formatear")]
        public IActionResult Formatear([FromQuery] int segundos)
        {
            int horas = 0;
            int minutos = 0;
            int segundosRestantes = 0;

            if (segundos < 0)
            {
                return BadRequest(new
                {
                    mensaje = "Debe ingresar una cantidad de segundos positiva."
                });
            }

            horas = segundos / 3600;

            minutos = (segundos % 3600) / 60;

            segundosRestantes = segundos % 60;

            return Ok(new
            {
                segundosIngresados = segundos,
                horas = horas,
                minutos = minutos,
                segundos = segundosRestantes
            });
        }
    }
}