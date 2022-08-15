using Microsoft.EntityFrameworkCore;
using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.Models;
using ProyectoTituloBackend.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly AplicationDbContext _context;



        public ClienteRepository(AplicationDbContext context)
        {

            _context = context;
        }


        public async Task CreateCliente(Clientes clientes)
        {
            _context.Add(clientes);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Clientes>> GetListClientes()
        {

            var listClientes = await _context.Clientes.Where(c => c.Activo == 1).Select(o
                  => new Clientes
                  {
                      Id = o.Id,
                      Nombres = o.Nombres,
                      Apellidos = o.Apellidos,
                      Rut = o.Rut,
                      Correo = o.Correo,
                      Telefono = o.Telefono

                  }).ToListAsync();

            return listClientes;

        }

        public async Task EliminarCliente(Clientes clientes)
        {

            clientes.Activo = 0;
            _context.Entry(clientes).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Clientes> GetCliente(int idCliente)
        {

            var cliente = await _context.Clientes.Where(c => c.Id == idCliente &&
                                                        c.Activo == 1).Include(c => c.ListDocumentos).FirstOrDefaultAsync();
            return cliente;
        }


        public async Task ActualizarCliente(int id, Clientes clientes)
        {



            _context.Entry(clientes).State = EntityState.Modified;
            _context.Update(clientes);
            await _context.SaveChangesAsync();

        }

        public async Task<Clientes> BuscarCliente(int idCliente)
        {
            var cliente = await _context.Clientes.Where(c => c.Id == idCliente && c.Activo == 1).FirstOrDefaultAsync();
            return cliente;
        }

    }
}
