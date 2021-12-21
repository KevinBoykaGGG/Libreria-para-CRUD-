using WebApplication1.Models;


namespace ClassLibrary1.Interfaces
{
    public interface IClienteRepository
    {
        Task<bool> DeleteCliente(int id);
        Task<Cliente> GetClienteById(int id);
        Task<IEnumerable<Cliente>> GetClientes();
        Task InsertCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
    }
}