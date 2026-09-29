namespace Backend_PruebaTecnica_Lafise.Models
{
    public class CuentaBancaria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
    }
}
