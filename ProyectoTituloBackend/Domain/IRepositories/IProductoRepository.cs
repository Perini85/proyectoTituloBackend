using ProyectoTituloBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Domain.IRepositories
{
    public interface IProductoRepository
    {

        Task CreateProducto(Producto producto);


        Task<Producto> GetProducto(int idProducto);

        Task EliminarProducto(Producto producto);

        Task<List<Producto>> GetListProducto();

        Task ActualizarProducto(int id, Producto producto);

        Task<Producto> BuscarProducto(int idProducto);
    }
}
