using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropinaController : ControllerBase
    {
        [HttpGet("calcular")]
        public IActionResult Calcular([FromQuery] double monto, [FromQuery] double porcentaje)
        {
            double propina = 0;
            double total = 0;

            propina = monto * porcentaje / 100;

            total = monto + propina;

            return Ok(new
            {
                montoOriginal = monto,
                porcentajePropina = porcentaje,
                propina = propina,
                totalAPagar = total
            });
        }
    }
}