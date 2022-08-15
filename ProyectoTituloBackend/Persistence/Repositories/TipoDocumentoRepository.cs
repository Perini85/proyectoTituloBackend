using Microsoft.EntityFrameworkCore;
using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.Models;
using ProyectoTituloBackend.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Persistence.Repositories
{
    public class TipoDocumentoRepository : ITipodeDocumentoRepository

    {
        private readonly AplicationDbContext _context;

        public TipoDocumentoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoDocumento>> GetListTipoDocumento()
        {
            var listTidoc = await _context.TipoDocumentos.Where(t => t.Id >= 1).Select(o
                  => new TipoDocumento
                  {
                      Id = o.Id,
                      Descripcion = o.Descripcion
                  }).ToListAsync();

            return listTidoc;
        }
    }
}
