using Backend_PruebaTecnica_Lafise.Utils;

namespace Backend_PruebaTecnica_Lafise.DTOs
{
    public class TransaccionInsertDTO
    {
        /*
            este DTO es para el FormBody solo limita el monto y el tipo de trasancion ya que lo demas es automatico
        */
        public decimal Monto { get; set; }
        public TransaccionTipo tipo { get; set; }
    }
}
