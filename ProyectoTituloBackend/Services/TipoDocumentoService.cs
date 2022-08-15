using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.IServices;
using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {

        private readonly ITipodeDocumentoRepository _tipoDocumentoRepository;


        public TipoDocumentoService(ITipodeDocumentoRepository tipodeDocumentoRepository)
        {

            _tipoDocumentoRepository = tipodeDocumentoRepository;

        }

        public async Task<List<TipoDocumento>> GetListTipoDocumento()
        {
            return await _tipoDocumentoRepository.GetListTipoDocumento();
        }
    }
}
