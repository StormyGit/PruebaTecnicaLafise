using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Services;
using Backend_PruebaTecnica_Lafise.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Backend_PruebaTecnica_Lafise.Controllers
{
    [ApiController]
    [Route("transaccion")]
    public class transaccionController : ControllerBase
    {
        private readonly ITransaccionServices _svrtransaccion;

        public transaccionController(ITransaccionServices svrtransaccion)
        {
            _svrtransaccion = svrtransaccion;
        }

        [HttpGet("historial/{cuentaBancariaId}")]
        public IActionResult historial(Guid cuentaBancariaId)
        {
            var historial = _svrtransaccion.Historial(cuentaBancariaId);
            return Ok(historial);
        }

        [HttpPost("transaccion/{cuentaBancariaId}")]
        public IActionResult Transaccion( Guid cuentaBancariaId, [FromBody] TransaccionInsertDTO dto)
        {
            bool resultado;

            if (dto.tipo == TransaccionTipo.deposito)
            {
                resultado = _svrtransaccion.SetDeposito(dto.Monto, cuentaBancariaId);
            }
            else if (dto.tipo == TransaccionTipo.retiro)
            {
                resultado = _svrtransaccion.SetRetiro(dto.Monto, cuentaBancariaId);
            }
            else {
                return BadRequest();
            }

            if (!resultado)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
