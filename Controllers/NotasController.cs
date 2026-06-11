using Microsoft.AspNetCore.Mvc;

namespace ING_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        [HttpPost("estadisticas")]
        public IActionResult Estadisticas([FromBody] DatosNotas datos)
        {
            double suma = 0;
            double promedio = 0;
            int notaMayor = 0;
            int notaMenor = 0;
            int aprobados = 0;
            int reprobados = 0;

            if (datos.notas.Count == 0)
            {
                return BadRequest(new
                {
                    mensaje = "Debe ingresar al menos una nota."
                });
            }

            notaMayor = datos.notas[0];
            notaMenor = datos.notas[0];

            for (int i = 0; i < datos.notas.Count; i++)
            {
                int nota = datos.notas[i];

                suma = suma + nota;

                if (nota > notaMayor)
                {
                    notaMayor = nota;
                }

                if (nota < notaMenor)
                {
                    notaMenor = nota;
                }

                if (nota >= 70)
                {
                    aprobados = aprobados + 1;
                }
                else
                {
                    reprobados = reprobados + 1;
                }
            }

            promedio = suma / datos.notas.Count;

            return Ok(new
            {
                promedio = promedio,
                notaMayor = notaMayor,
                notaMenor = notaMenor,
                aprobados = aprobados,
                reprobados = reprobados
            });
        }
    }

    public class DatosNotas
    {
        public List<int> notas { get; set; } = new List<int>();
    }
}