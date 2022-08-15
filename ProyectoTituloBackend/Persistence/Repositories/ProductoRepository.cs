using Microsoft.EntityFrameworkCore;
using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.Models;
using ProyectoTituloBackend.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository

    {


        private readonly AplicationDbContext _context;

        public ProductoRepository(AplicationDbContext context)
        {

            _context = context;
        }


        public async Task ActualizarProducto(int id, Producto producto)
        {

            _context.Entry(producto).State = EntityState.Modified;
            _context.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<Producto> BuscarProducto(int idProducto)
        {

            var producto = await _context.Productos.Where(p => p.Id == idProducto && p.Activo == 1).FirstOrDefaultAsync();
            return producto;
        }

        public async Task CreateProducto(Producto producto)
        {

            _context.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProducto(Producto producto)
        {

            producto.Activo = 0;
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<List<Producto>> GetListProducto()
        {
            var Listproducto = await _context.Productos.Where(p => p.Activo == 1).Select(
                                                             o => new Producto
                                                             {
                                                                 Id = o.Id,
                                                                 Descripcion = o.Descripcion,
                                                                 Precio = o.Precio,
                                                                 Stock = o.Stock


                                                             }).ToListAsync();

            return Listproducto;
        }

        public async Task<Producto> GetProducto(int idProducto)
        {

            var producto = await _context.Productos.Where(p => p.Id == idProducto && p.Activo == 1).FirstOrDefaultAsync();
            return producto;
        }
    }
}
