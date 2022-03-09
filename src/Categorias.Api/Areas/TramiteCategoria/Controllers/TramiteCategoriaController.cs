using Categorias.Application.UseCases;
using Categorias.Application.UseCases.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Categorias.Api.Areas.TramiteCategoria.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    
    public class TramiteCategoriaController: ControllerBase
    {
        private readonly ITramiteCategoriaUseCase _tramitecategoriaUseCase;

        public TramiteCategoriaController()
        {
            _tramitecategoriaUseCase = new TramiteCategoriaUseCase();

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ObtenerCategoriasPorTramite(string idTramite)
        {
            var result =  _tramitecategoriaUseCase.ObtenerListaTramitesCategorias(idTramite);
            if (!result.Succeeded)
                return BadRequest();
            return new JsonResult(result.Data);

        }

    }
}
