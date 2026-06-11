using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImcController : ControllerBase
    {
        [HttpGet("calcular")]
        public IActionResult Calcular([FromQuery] double peso, [FromQuery] double altura)
        {
            double imc = 0;
            string categoria = "";

            imc = peso / (altura * altura);

            if (imc < 18.5)
            {
                categoria = "Bajo peso";
            }
            else
            {
                if (imc < 25)
                {
                    categoria = "Normal";
                }
                else
                {
                    if (imc < 30)
                    {
                        categoria = "Sobrepeso";
                    }
                    else
                    {
                        categoria = "Obesidad";
                    }
                }
            }

            return Ok(new
            {
                peso = peso,
                altura = altura,
                imc = imc,
                categoria = categoria
            });
        }
    }
}