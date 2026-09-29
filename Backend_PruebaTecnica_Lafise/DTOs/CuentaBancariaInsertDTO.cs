namespace Backend_PruebaTecnica_Lafise.DTOs
{
    public class CuentaBancariaInsertDTO
    {
        /*
            este DTO ayuda para el FormBody de la cuenta bancaria, es para crear una cuenta Bancaria
        */
        public Guid clienteId { get; set; }
        public decimal SaldoInicial { get; set; }
    }
}
