using ProyectoTituloBackend.Domain.Models;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);

    }
}
