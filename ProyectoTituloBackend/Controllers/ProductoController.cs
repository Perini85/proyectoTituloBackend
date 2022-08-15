using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoTituloBackend.Domain.IServices;
using ProyectoTituloBackend.Domain.Models;
using ProyectoTituloBackend.Utils;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {


        private readonly IProductoService _productoService;


        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {

            try
            {

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);


                producto.UsuarioId = idUsuario;
                producto.Activo = 1;
                await _productoService.CreateProducto(producto);
                return Ok(new { message = "Se agrego el producto exitosamente" });

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Route("GetListProductos")]
        [HttpGet]
        public async Task<IActionResult> GetListProductos()
        {

            try
            {
                var listDocumento = await _productoService.GetListProducto();
                return Ok(listDocumento);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, [FromBody] Producto producto)
        {

            try
            {
                if (id != producto.Id)
                {
                    return BadRequest();
                }

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);


                producto.UsuarioId = idUsuario;
                producto.Activo = 1;
                await _productoService.ActualizarProducto(id, producto);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{idProducto}")]
        public async Task<IActionResult> Get(int idProducto)
        {

            try
            {

                var producto = await _productoService.GetProducto(idProducto);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idProducto}")]
        public async Task<IActionResult> Delete(int idProducto)
        {
            try
            {
                var producto = await _productoService.BuscarProducto(idProducto);

                if (producto == null)
                {
                    return BadRequest(new { message = "No se encontro ningun producto" });
                }

                await _productoService.EliminarProducto(producto);
                return Ok(new { message = "El producto fue eliminado con exito" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
