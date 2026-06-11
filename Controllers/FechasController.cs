using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechasController : ControllerBase
    {
        [HttpGet("diferencia")]
        public IActionResult Diferencia([FromQuery] DateTime desde, [FromQuery] DateTime hasta)
        {
            TimeSpan resultado = hasta - desde;

            return Ok(new
            {
                fechaDesde = desde.ToShortDateString(),
                fechaHasta = hasta.ToShortDateString(),
                diasDiferencia = resultado.Days
            });
        }

        [HttpGet("agregar")]
        public IActionResult Agregar([FromQuery] DateTime fecha, [FromQuery] int dias)
        {
            DateTime nuevaFecha = fecha.AddDays(dias);

            return Ok(new
            {
                fechaOriginal = fecha.ToShortDateString(),
                diasAgregados = dias,
                nuevaFecha = nuevaFecha.ToShortDateString()
            });
        }
    }
}