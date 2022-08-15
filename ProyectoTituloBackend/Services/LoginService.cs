using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.IServices;
using ProyectoTituloBackend.Domain.Models;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Services
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;


        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {

            return await _loginRepository.ValidateUser(usuario);
        }

    }
}
