using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Domain.IServices
{
    public interface IClienteService
    {

        Task CreateCliente(Clientes clientes);

        Task<Clientes> GetCliente(int idCliente);

        Task EliminarCliente(Clientes clientes);

        Task<List<Clientes>> GetListClientes();

        Task ActualizarCliente(int id, Clientes clientes);

        Task<Clientes> BuscarCliente(int idCliente);

    }
}
