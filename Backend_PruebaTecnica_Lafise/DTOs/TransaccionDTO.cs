using Backend_PruebaTecnica_Lafise.Models;
using Backend_PruebaTecnica_Lafise.Utils;

namespace Backend_PruebaTecnica_Lafise.DTOs
{
    /*
        este DTO ayuda a mosrtar datos de las transacciones del cliente
    */
    public class HistorialDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Tipo { get; set; } = "";
        public Decimal Monto { get; set; }
        public Decimal Saldo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public CuentaBancaria CuentaBancaria { get; set; } = null!;
    }
}
