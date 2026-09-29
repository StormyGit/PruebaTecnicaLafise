using Backend_PruebaTecnica_Lafise.Data;
using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_PruebaTecnica_Lafise.Services
{
    public class CuentaBancariaServices : ICuentaBancariaService
    {
        // Servicios
        private readonly AppDbContext _context;
        private readonly ILogger<CuentaBancariaServices> _logger;
        private readonly ITransaccionServices _svrTransaccion;

        // constructor
        public CuentaBancariaServices( AppDbContext context, ILogger<CuentaBancariaServices> logger, ITransaccionServices svrTransaccion)
        {
            _context = context;
            _logger = logger;
            _svrTransaccion = svrTransaccion;
        }

        // metodos
        public List<CuentaBancariaDTO> GetAll()
        {
            List<CuentaBancaria> cuentas = _context.CuentasBancarias.Include(c => c.Cliente).ToList();

            return cuentas.Select(c => ConvertirADTO(c)).ToList();
        }

        // metodo para crear una cuenta con un cliente existente
        public Boolean CrearCuenta(CuentaBancariaInsertDTO dto)
        {
            Cliente? c = _context.Clientes.FirstOrDefault(c => c.Id == dto.clienteId);

            // ver si el cliente existe
            if (c == null)
            {
                _logger.LogWarning("No se encontró el cliente con Id {ClienteId}", dto.clienteId);
                return false;
            }

            // ver si el cliente ya tiene cuenta
            List<CuentaBancaria> cbTemp = _context.CuentasBancarias.Where(cuentaBan => cuentaBan.ClienteId == dto.clienteId).ToList();

            if (cbTemp.Any())
            {
                _logger.LogWarning( "El usuario ya tiene una cuenta {ClienteId}", dto.clienteId);
                return false;
            }

            CuentaBancaria cb = new CuentaBancaria
            {
                Id = Guid.NewGuid(),
                ClienteId = c.Id
            };
            _context.CuentasBancarias.Add(cb);
            _context.SaveChanges();

            // Agregar el primer deposito inicial a la cuenta
            _svrTransaccion.SetDeposito(DecimalACentavos(dto.SaldoInicial), cb.Id);


            return true;
        }



        // metodo para pasar de numeros decimales a centavos
        private long DecimalACentavos(decimal numero)
        {
            return (long)Math.Round(numero * 100m);
        }
        // pasa de centavos a decimal para mostrar al usuarios 
        private decimal CentavosADecimal(long centavos)
        {
            return centavos / 100m;
        }


        private CuentaBancariaDTO ConvertirADTO(CuentaBancaria cuenta)
        {
            long saldoActual = ObtenerSaldoActual(cuenta.Id);
            return new CuentaBancariaDTO
            {
                id = cuenta.Id,
                clienteNombre = cuenta.Cliente.nombre,
                saldo = CentavosADecimal(saldoActual)
            };
        }

        private long ObtenerSaldoActual(Guid cuentaBancariaId)
        {
            Transaccion? ultimaTransaccion = _context.Transacciones
                .Where(t => t.CuentaBancariaId == cuentaBancariaId && t.IsAprobado)
                .OrderByDescending(t => t.Fecha)
                .FirstOrDefault();

            return ultimaTransaccion?.Saldo ?? 0;
        }
    }
}