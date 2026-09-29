using Backend_PruebaTecnica_Lafise.Utils;

namespace Backend_PruebaTecnica_Lafise.Models
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string nombre { get; set; } = "";
        public DateTime fechaNacimiento { get; set; }
        public Genero sexo { get; set; }
        public int Ingreso { get; set; }
    }
}
