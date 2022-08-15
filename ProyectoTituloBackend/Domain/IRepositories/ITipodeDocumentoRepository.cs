using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Domain.IRepositories
{
    public interface ITipodeDocumentoRepository
    {

        Task<List<TipoDocumento>> GetListTipoDocumento();
    }
}
