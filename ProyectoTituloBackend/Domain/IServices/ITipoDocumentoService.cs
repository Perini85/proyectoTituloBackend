using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Domain.IServices
{
    public interface ITipoDocumentoService
    {

        Task<List<TipoDocumento>> GetListTipoDocumento();
    }
}
