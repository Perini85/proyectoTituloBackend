using Microsoft.EntityFrameworkCore;
using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.Models;
using ProyectoTituloBackend.Persistence.Context;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        private readonly AplicationDbContext _context;

        public LoginRepository(AplicationDbContext context)
        {

            _context = context;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {

            var user = await _context.Usuarios.Where(u => u.nombreUsuario == usuario.nombreUsuario
           && u.Password == usuario.Password).FirstOrDefaultAsync();

            return user;

        }

    }
}
