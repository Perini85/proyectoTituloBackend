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
    public class DocumentoController : ControllerBase
    {

        private readonly IDocumentoService _documentoService;


        public DocumentoController(IDocumentoService documentoService)
        {

            _documentoService = documentoService;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Documento documento)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                documento.UsuarioId = idUsuario;
                documento.FechaCreacion = DateTime.Now;
                documento.Activo = 1;
                await _documentoService.CreateDocumento(documento);

                return Ok(new { message = "Se agrego el documento exitosamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListDocumentos")]
        [HttpGet]

        public async Task<IActionResult> GetListDocumentos()
        {

            try
            {
                var listDocumento = await _documentoService.GetListDocumento();
                return Ok(listDocumento);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, [FromBody] Documento documento)
        {
            try
            {

                if (id != documento.Id)
                {
                    return BadRequest();
                }


                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                documento.UsuarioId = idUsuario;
                documento.FechaCreacion = DateTime.Now;
                documento.Activo = 1;
                await _documentoService.ActualizarDocumento(id, documento);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpGet("{idDocumento}")]
        public async Task<IActionResult> Get(int idDocumento)
        {

            try
            {

                var documento = await _documentoService.GetDocumento(idDocumento);
                return Ok(documento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{idDocumento}")]
        public async Task<IActionResult> Delete(int idDocumento)
        {
            try
            {

                var documento = await _documentoService.BuscarDocumento(idDocumento);

                if (documento == null)
                {
                    return BadRequest(new { message = "No se encontro ningun documento" });
                }

                await _documentoService.EliminarDocumento(documento);
                return Ok(new { message = "El documento fue eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }

    }
}
