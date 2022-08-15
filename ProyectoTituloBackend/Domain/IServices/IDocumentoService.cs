using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Domain.IServices
{
    public interface IDocumentoService
    {

        Task CreateDocumento(Documento documento);

        Task<Documento> GetDocumento(int idDocumento);

        Task EliminarDocumento(Documento documento);

        Task<List<Documento>> GetListDocumento();

        Task ActualizarDocumento(int id, Documento documento);

        Task<Documento> BuscarDocumento(int idDocumento);
    }
}
