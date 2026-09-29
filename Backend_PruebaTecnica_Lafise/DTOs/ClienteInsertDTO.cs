using Backend_PruebaTecnica_Lafise.Utils;

namespace Backend_PruebaTecnica_Lafise.DTOs
{
    /*
        este DTO es para el bodyForm al moneto de insertar un cliente
     */
    public class ClienteInsertDTO
    {
        public string nombreCliente { get; set; } = "";
        public DateTime fechaNacimiento { get; set; }
        public Genero Genero { get; set; }
    }
}
