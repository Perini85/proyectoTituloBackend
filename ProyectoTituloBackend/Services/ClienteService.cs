using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.IServices;
using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Services
{
    public class ClienteService : IClienteService
    {


        private readonly IClienteRepository _clienteRepository;


        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task ActualizarCliente(int id, Clientes clientes)
        {

            await _clienteRepository.ActualizarCliente(id, clientes);
        }

        public async Task CreateCliente(Clientes clientes)
        {

            await _clienteRepository.CreateCliente(clientes);
        }

        public async Task EliminarCliente(Clientes clientes)
        {
            await _clienteRepository.EliminarCliente(clientes);
        }

        public async Task<Clientes> GetCliente(int idCliente)
        {
            return await _clienteRepository.GetCliente(idCliente);
        }

        public async Task<List<Clientes>> GetListClientes()
        {
            return await _clienteRepository.GetListClientes();
        }

        public async Task<Clientes> BuscarCliente(int idCliente)
        {
            return await _clienteRepository.BuscarCliente(idCliente);
        }
    }
}
