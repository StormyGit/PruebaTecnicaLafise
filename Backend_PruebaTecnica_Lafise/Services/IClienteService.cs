using Backend_PruebaTecnica_Lafise.DTOs;
using Backend_PruebaTecnica_Lafise.Models;

namespace Backend_PruebaTecnica_Lafise.Services
{
    public interface IClienteService
    {
        List<Cliente> GetAll();
        Cliente? Get(Guid id);
        Boolean Insert(ClienteInsertDTO clienteNew);
        Boolean Update(ClienteInsertDTO clienteNew, Guid id);
    }
}
