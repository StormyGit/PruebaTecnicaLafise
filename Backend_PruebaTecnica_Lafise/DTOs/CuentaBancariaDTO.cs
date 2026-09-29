namespace Backend_PruebaTecnica_Lafise.DTOs
{
    public class CuentaBancariaDTO
    {
        /*
            este DTO ayuda a mosrtar datos de la cuenta junto con los del cliente y el saldo saldo actual que tiene en su cuenta
            para no mostrar la modelo
        */
        public Guid id { get; set; }
        public string clienteNombre { get; set; } = "";
        public decimal saldo { get; set; } 
    }
}
