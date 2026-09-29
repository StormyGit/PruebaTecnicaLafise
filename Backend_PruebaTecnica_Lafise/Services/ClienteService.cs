using Backend_PruebaTecnica_Lafise.Data;
using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_PruebaTecnica_Lafise.Services
{
    public class ClienteService : IClienteService
    {
        // Servicios
        private readonly AppDbContext _context;
        private readonly ILogger<ClienteService> _logger;

        // constructor
        public ClienteService(AppDbContext context, ILogger<ClienteService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // metodos CRU
        public List<Cliente> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los clientes");
            return _context.Clientes.ToList();
        }
        public Cliente Get(Guid id)
        {
            _logger.LogInformation("Obteniendo cliente con Id {ClienteId}", id);
            return _context.Clientes.Where(c => c.Id == id).FirstOrDefault();
        }
        public Boolean Insert(ClienteInsertDTO clienteNew) {
            _logger.LogInformation("Creando nuevo Cliente");
            Cliente c = new Cliente();

            // datos de cliente
            c.nombre = clienteNew.nombreCliente;
            c.fechaNacimiento = clienteNew.fechaNacimiento;
            c.sexo = clienteNew.Genero;


            c.Id = Guid.NewGuid();  // nuevo ID
            c.Ingreso = 0;          // ingreso en monedas

            _context.Clientes.Add(c);
            _context.SaveChanges();
            
            _logger.LogInformation("Se a creando nuevo cliente con Id {id}", c.Id);

            return true;
        }

        public Boolean Update(ClienteInsertDTO clienteNew, Guid id) {
            _logger.LogInformation("modificando el cliente con Id {id}", id);
            Cliente? c = _context.Clientes.FirstOrDefault(c => c.Id == id);
            
            // si no existe el cliente que se esta actualizado
            if (c == null)
            {
                _logger.LogWarning("No se encontró el cliente con Id {ClienteId}", id);
                return false;
            }

            // datos de cliente
            c.nombre = clienteNew.nombreCliente;
            c.fechaNacimiento = clienteNew.fechaNacimiento;
            c.sexo = clienteNew.Genero;

            _context.SaveChanges();
            _logger.LogInformation("Se a modificado el cliente con Id {id}", c.Id);
            return true;
        }
    }
}
