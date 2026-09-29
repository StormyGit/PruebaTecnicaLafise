using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Models;

namespace Backend_PruebaTecnica_Lafise.Services
{
    public interface ICuentaBancariaService
    {
        List<CuentaBancariaDTO> GetAll();
        Boolean CrearCuenta(CuentaBancariaInsertDTO dto);
    }
}
