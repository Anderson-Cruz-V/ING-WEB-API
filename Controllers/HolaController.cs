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
            string paridad;
            string tipoNumero;
            bool esPrimo;

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
                tipoNumero = "Positivo";
            }
            else if (n < 0)
            {
                tipoNumero = "Negativo";
            }
            else
            {
                tipoNumero = "Cero";
            }

            esPrimo = VerificarPrimo(n);

            return Ok(new
            {
                numero = n,
                paridad = paridad,
                primo = esPrimo ? "Es primo" : "No es primo",
                tipo = tipoNumero
            });
        }

        private bool VerificarPrimo(int numero)
        {
            if (numero <= 1)
            {
                return false;
            }

            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}