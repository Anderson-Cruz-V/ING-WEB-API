using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextoController : ControllerBase
    {
        [HttpGet("contar")]
        public IActionResult Contar([FromQuery] string texto)
        {
            int caracteres = 0;
            int palabras = 1;
            int vocales = 0;

            if (texto == null || texto == "")
            {
                return BadRequest(new
                {
                    mensaje = "Debe ingresar un texto."
                });
            }

            caracteres = texto.Length;

            for (int i = 0; i < texto.Length; i++)
            {
                char letra = texto[i];

                if (letra == ' ')
                {
                    palabras = palabras + 1;
                }

                if (letra == 'a' || letra == 'e' || letra == 'i' || letra == 'o' || letra == 'u' ||
                    letra == 'A' || letra == 'E' || letra == 'I' || letra == 'O' || letra == 'U')
                {
                    vocales = vocales + 1;
                }
            }

            return Ok(new
            {
                texto = texto,
                palabras = palabras,
                caracteres = caracteres,
                vocales = vocales
            });
        }

        [HttpGet("invertir")]
        public IActionResult Invertir([FromQuery] string texto)
        {
            string textoInvertido = "";

            if (texto == null || texto == "")
            {
                return BadRequest(new
                {
                    mensaje = "Debe ingresar un texto."
                });
            }

            for (int i = texto.Length - 1; i >= 0; i--)
            {
                textoInvertido = textoInvertido + texto[i];
            }

            return Ok(new
            {
                textoOriginal = texto,
                textoInvertido = textoInvertido
            });
        }
    }
}