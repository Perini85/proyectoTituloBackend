using Microsoft.AspNetCore.Mvc;
using ProyectoTituloBackend.Domain.IServices;
using System;
using System.Threading.Tasks;

namespace ProyectoTituloBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {

        private readonly ITipoDocumentoService _tipoDocumentoService;


        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService)
        {

            _tipoDocumentoService = tipoDocumentoService;

        }



        [Route("GetListTipoDocumento")]
        [HttpGet]
        public async Task<IActionResult> GetListTipoDocumento()
        {


            try
            {

                var listTipoDoc = await _tipoDocumentoService.GetListTipoDocumento();
                return Ok(listTipoDoc);




            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
