using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvertirTextoController : ControllerBase
    {
        [HttpGet("invertir")]
        public IActionResult Invertir([FromQuery] string texto)
        {
            string resultado = "";

            if (texto == null || texto == "")
            {
                return BadRequest(new
                {
                    mensaje = "Debe ingresar un texto."
                });
            }

            for (int i = texto.Length - 1; i >= 0; i--)
            {
                resultado = resultado + texto[i];
            }

            return Ok(new
            {
                textoOriginal = texto,
                textoInvertido = resultado
            });
        }
    }
}