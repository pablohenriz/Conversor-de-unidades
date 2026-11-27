using Microsoft.AspNetCore.Mvc;

namespace Conversor.API;

[ApiController]
[Route("api/[controller]")] //a rota sera /api/conversor
public class ConversorController : ControllerBase
{
     [HttpGet("temperatura")]
     public IActionResult ConverterTemperatura([FromQuery] double valor, [FromQuery] string de, [FromQuery] string para)
     {
          double resultado = 0;

          if(de.ToUpper() == "C" && para.ToUpper == "F")
          {
               resultado = (valor * 9 / 5) + 32;
          }
     }
}
