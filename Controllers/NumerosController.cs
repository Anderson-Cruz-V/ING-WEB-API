using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumerosController : ControllerBase
    {
        [HttpGet("analizar")]
        public IActionResult Analizar([FromQuery] int n)
        {
            string paridad = "";
            string tipo = "";
            string primo = "";

            if (n % 2 == 0)
            {
                paridad = "Par";
            }
            else
            {
                paridad = "Impar";
            }

            if (n > 0)
            {
                tipo = "Positivo";
            }
            else
            {
                if (n < 0)
                {
                    tipo = "Negativo";
                }
                else
                {
                    tipo = "Cero";
                }
            }

            if (n == 2 || n == 3 || n == 5 || n == 7)
            {
                primo = "Es primo";
            }
            else
            {
                if (n <= 1)
                {
                    primo = "No es primo";
                }
                else
                {
                    if (n % 2 == 0 || n % 3 == 0 || n % 5 == 0 || n % 7 == 0)
                    {
                        primo = "No es primo";
                    }
                    else
                    {
                        primo = "Es primo";
                    }
                }
            }

            return Ok(new
            {
                numero = n,
                paridad = paridad,
                tipo = tipo,
                primo = primo
            });
        }
    }
}