using Backend_PruebaTecnica_Lafise.Data;
using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Models;
using Backend_PruebaTecnica_Lafise.Utils;

namespace Backend_PruebaTecnica_Lafise.Services
{
    public class TransaccionServices : ITransaccionServices
    {
        // Servicios
        private readonly AppDbContext _context;
        private readonly ILogger<ClienteService> _logger;

        // constructor
        public TransaccionServices(AppDbContext context, ILogger<ClienteService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // mostrar el historia de una cuenta existente con ayuda de un DTO
        public List<HistorialDTO> Historial(Guid cuentaBancariaId)
        {
            List<Transaccion> historial = _context.Transacciones
                .Where(t =>
                    t.CuentaBancariaId == cuentaBancariaId &&
                    t.IsAprobado)
                .OrderByDescending(t => t.Fecha)
                .ToList();

            return historial
                .Select(t => ConvertirADTO(t))
                .ToList();
        }

        // hacer un deposito en una cuenta existente
        public bool SetDeposito(decimal monto, Guid cuentaBancariaId)
        {
            long montoCentavos = DecimalACentavos(monto);

            if (montoCentavos <= 0)
            {
                return false;
            }

            CuentaBancaria? cuenta = _context.CuentasBancarias.FirstOrDefault(c => c.Id == cuentaBancariaId);

            if (cuenta == null)
            {
                _logger.LogWarning( "No se encontró la cuenta bancaria con Id {CuentaId}", cuentaBancariaId);
                return false;
            }
            long SaldoActual = ObtenerSaldoActual(cuentaBancariaId);
            // aumentar saldo en centavos
            SaldoActual += montoCentavos;

            // registrar transacción
            Transaccion t = new Transaccion
            {
                Id = Guid.NewGuid(),
                CuentaBancariaId = cuenta.Id,
                Tipo = TransaccionTipo.deposito,
                Monto = montoCentavos,
                Saldo = SaldoActual,
                IsAprobado = true
            };

            _context.Transacciones.Add(t);

            _context.SaveChanges();

            return true;
        }

        // hacer un retiro en una cuenta existente
        public bool SetRetiro(decimal monto, Guid cuentaBancariaId)
        {
            long montoCentavos = DecimalACentavos(monto);

            if (montoCentavos <= 0)
            {
                return false;
            }

            CuentaBancaria? cuenta = _context.CuentasBancarias.FirstOrDefault(c => c.Id == cuentaBancariaId);

            if (cuenta == null)
            {
                _logger.LogWarning( "No se encontró la cuenta bancaria con Id {CuentaId}", cuentaBancariaId);
                return false;
            }
            long SaldoActual = ObtenerSaldoActual(cuentaBancariaId);
            // validar fondos
            if (SaldoActual < montoCentavos)
            {
                _logger.LogWarning("Fondos insuficientes en la cuenta {CuentaId}", cuentaBancariaId);
                return false;
            }

            // restar saldo
            SaldoActual -= montoCentavos;

            // registrar transacción
            Transaccion t = new Transaccion
            {
                Id = Guid.NewGuid(),
                CuentaBancariaId = cuenta.Id,
                Tipo = TransaccionTipo.retiro,
                Monto = montoCentavos,
                Saldo = SaldoActual,
                IsAprobado = true
            };

            _context.Transacciones.Add(t);

            _context.SaveChanges();

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

        private HistorialDTO ConvertirADTO(Transaccion transaccion)
        {
            return new HistorialDTO
            {
                Id = transaccion.Id,
                Tipo = transaccion.Tipo == TransaccionTipo.deposito
                    ? "Deposito"
                    : "Retiro",

                Monto = CentavosADecimal(transaccion.Monto),
                Saldo = CentavosADecimal(transaccion.Saldo),
                Fecha = transaccion.Fecha,
                CuentaBancaria = null!
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
