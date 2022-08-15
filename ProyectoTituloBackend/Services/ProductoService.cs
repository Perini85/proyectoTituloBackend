using ProyectoTituloBackend.Domain.IRepositories;
using ProyectoTituloBackend.Domain.IServices;
using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Services
{
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _productoRepository;


        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task ActualizarProducto(int id, Producto producto)
        {
            await _productoRepository.ActualizarProducto(id, producto);
        }

        public async Task<Producto> BuscarProducto(int idProducto)
        {

            return await _productoRepository.BuscarProducto(idProducto);
        }

        public async Task CreateProducto(Producto producto)
        {

            await _productoRepository.CreateProducto(producto);
        }

        public async Task EliminarProducto(Producto producto)
        {

            await _productoRepository.EliminarProducto(producto);
        }

        public async Task<List<Producto>> GetListProducto()
        {

            return await _productoRepository.GetListProducto();
        }

        public async Task<Producto> GetProducto(int idProducto)
        {

            return await _productoRepository.GetProducto(idProducto);
        }
    }
}
