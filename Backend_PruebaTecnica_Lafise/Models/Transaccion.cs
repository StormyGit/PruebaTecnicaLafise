using Backend_PruebaTecnica_Lafise.Utils;

namespace Backend_PruebaTecnica_Lafise.Models
{
    public class Transaccion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CuentaBancariaId { get; set; }
        public TransaccionTipo Tipo { get; set; }
        public long Monto { get; set; }
        public long Saldo { get; set; }
        public bool IsAprobado { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public CuentaBancaria CuentaBancaria { get; set; } = null!;
    }
}