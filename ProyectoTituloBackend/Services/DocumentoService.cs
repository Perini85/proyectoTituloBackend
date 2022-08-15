using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.IServices;
using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Services
{
    public class DocumentoService : IDocumentoService

    {

        private readonly IDocumentoRepository _documentoRepository;

        public DocumentoService(IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }
        public async Task ActualizarDocumento(int id, Documento documento)
        {
            await _documentoRepository.ActualizarDocumento(id, documento);
        }

        public async Task<Documento> BuscarDocumento(int idDocumento)
        {

            return await _documentoRepository.BuscarDocumento(idDocumento);
        }

        public async Task CreateDocumento(Documento documento)
        {
            await _documentoRepository.CreateDocumento(documento);
        }

        public async Task EliminarDocumento(Documento documento)
        {
            await _documentoRepository.EliminarDocumento(documento);
        }

        public async Task<Documento> GetDocumento(int idDocumento)
        {
            return await _documentoRepository.GetDocumento(idDocumento);
        }

        public async Task<List<Documento>> GetListDocumento()
        {
            return await _documentoRepository.GetListDocumento();
        }



    }

}
