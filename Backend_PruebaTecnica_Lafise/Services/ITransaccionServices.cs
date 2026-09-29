using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Models;

namespace Backend_PruebaTecnica_Lafise.Services
{
    public interface ITransaccionServices
    {
        bool SetDeposito(decimal monto, Guid cuentaBancariaId);
        bool SetRetiro(decimal monto, Guid cuentaBancariaId);
        List<HistorialDTO> Historial(Guid cuentaBancariaId);
    }
}
