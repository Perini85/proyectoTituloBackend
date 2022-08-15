using Microsoft.EntityFrameworkCore;
using ProyectoTituloBackend.Domain.Models;

namespace ProyectoTituloBackend.Persistence.Context
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Documento> Documentos { get; set; }

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        public DbSet<Producto> Productos { get; set; }


        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }


    }
}
