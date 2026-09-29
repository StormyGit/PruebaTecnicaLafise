using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Backend_PruebaTecnica_Lafise.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _svrCliente;

        public ClientesController(IClienteService svrCliente)
        {
            _svrCliente = svrCliente;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var clientes = _svrCliente.GetAll();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var cliente = _svrCliente.Get(id);

            if (cliente == null) return NotFound();
            
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] ClienteInsertDTO clienteNew)
        {
            bool result = _svrCliente.Insert(clienteNew);

            if (!result) return BadRequest();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ClienteInsertDTO clienteNew)
        {
            bool result = _svrCliente.Update(clienteNew, id);

            if (!result) return NotFound();
            
            return Ok();
        }
    }
}