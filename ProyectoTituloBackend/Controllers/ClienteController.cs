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
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        //private readonly AplicationDbContext _context;




        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;


        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Clientes clientes)
        {

            try
            {

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                clientes.Activo = 1;
                await _clienteService.CreateCliente(clientes);

                return Ok(new { message = "Se agrego el cliente exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListClientes")]
        [HttpGet]
        public async Task<IActionResult> GetListClientes()
        {


            try
            {

                var listClientes = await _clienteService.GetListClientes();
                return Ok(listClientes);




            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, [FromBody] Clientes clientes)
        {

            try
            {

                if (id != clientes.Id)
                {
                    return BadRequest();
                }


                clientes.Activo = 1;
                //_context.Entry(clientes).State = EntityState.Modified;
                //_context.Update(clientes);
                //_context.SaveChanges();
                //return Ok();

                await _clienteService.ActualizarCliente(id, clientes);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{idCliente}")]
        public async Task<IActionResult> Get(int idCliente)
        {
            try
            {

                var cliente = await _clienteService.GetCliente(idCliente);
                return Ok(cliente);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        //[Route("Eliminar")]
        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> /*ActionResult*/ Delete(int idCliente)
        {
            try
            {


                var cliente = await _clienteService.BuscarCliente(idCliente);


                if (cliente == null)
                {
                    return BadRequest(new { message = "No se encontro ningun cliente" });
                }

                await _clienteService.EliminarCliente(cliente);
                return Ok(new { message = "El cliente fue eliminado con exito" });


                //Clientes cliente = _context.Clientes.Where(c => c.Id == idCliente).First();
                //cliente.Activo = 0;
                //_context.s

                //return Ok();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }




    }
}
