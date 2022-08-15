using Microsoft.EntityFrameworkCore;
using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.Models;
using ProyectoTituloBackend.Persistence.Context;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AplicationDbContext _context;

        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {

            var validateExistence = await _context.Usuarios.AnyAsync(u => u.nombreUsuario == usuario.nombreUsuario);
            return validateExistence;
        }

        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {

            var usuario = await _context.Usuarios.Where(u => u.Id == idUsuario && u.Password == passwordAnterior).FirstOrDefaultAsync();
            return usuario;

        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
