using Microsoft.EntityFrameworkCore;
using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.Models;
using ProyectoTituloBackend.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Persistence.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {

        private readonly AplicationDbContext _context;


        public DocumentoRepository(AplicationDbContext context)
        {
            _context = context;
        }


        public async Task CreateDocumento(Documento documento)
        {
            _context.Add(documento);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Documento>> GetListDocumento()
        {

            var listdoc = await _context.Documentos.Where(d => d.Activo == 1).Select(o
                                                                     => new Documento
                                                                     {
                                                                         Id = o.Id,
                                                                         TipoDocumentoId = o.TipoDocumentoId,
                                                                         IdCliente = o.IdCliente,
                                                                         NumeroDoc = o.NumeroDoc,
                                                                         UsuarioId = o.UsuarioId,
                                                                         Valor = o.Valor,
                                                                         FechaCreacion = o.FechaCreacion


                                                                     }).ToListAsync();
            return listdoc;

        }


        public async Task EliminarDocumento(Documento documento)
        {

            documento.Activo = 0;
            _context.Entry(documento).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }


        public async Task<Documento> GetDocumento(int idDocumento)
        {

            var doc = await _context.Documentos.Where(d => d.Id == idDocumento
            && d.Activo == 1).FirstOrDefaultAsync();
            return doc;

        }

        public async Task ActualizarDocumento(int id, Documento documento)
        {
            _context.Entry(documento).State = EntityState.Modified;
            _context.Update(documento);
            await _context.SaveChangesAsync();
        }

        public async Task<Documento> BuscarDocumento(int idDocumento)
        {
            var doc = await _context.Documentos.Where(d => d.Id == idDocumento &&
            d.Activo == 1).FirstOrDefaultAsync();
            return doc;

        }


    }
}
