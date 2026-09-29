using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_PruebaTecnica_Lafise.Controllers
{
    [ApiController]
    [Route("CuentaBancaria")]
    public class CuentaBancariaController : ControllerBase
    {
        private readonly ICuentaBancariaService _svrCBancaria;

        public CuentaBancariaController(ICuentaBancariaService svrCBancaria) {
            _svrCBancaria = svrCBancaria;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var cuentasBancarias = _svrCBancaria.GetAll();
            return Ok(cuentasBancarias);
        }


        [HttpPost("crearCuentaBancaria")]
        public IActionResult CrearCuentabancaria([FromBody] CuentaBancariaInsertDTO dto) {
            _svrCBancaria.CrearCuenta(dto);
            return Ok();
        }
    }
}
