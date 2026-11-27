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

          //Verifica se algum dos campos esta nulo ou vazio
          if(string.IsNullOrEmpty(de) || string.IsNullOrEmpty(para))
          {
               return BadRequest("Os parametros 'de' e 'para' sao obrigatorios");
          }


          if(de.ToUpper() == "C" && para.ToUpper() == "F")
          {
               resultado = (valor * 9 / 5) + 32;
          }
          else if (de.ToUpper() == "F" && para.ToUpper() == "C")
          {
               resultado = (valor - 32) * 5 / 9;
          }
          else
          {
               return BadRequest("Conversor nao suporta. Use C ou F");
          }

          //Criando o pacote do que vai ser enviado de volta com retorno da operacao
          return Ok(new { valorOriginal = valor, resultado = resultado, de = de, para = para });
     }
}
