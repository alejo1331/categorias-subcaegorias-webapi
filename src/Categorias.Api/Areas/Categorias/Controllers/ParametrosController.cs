using Categorias.Application.UseCases;
using Categorias.Application.UseCases.Interface;
using Microsoft.AspNetCore.Mvc;
using Categorias.Application.Models;
using System;
using Categorias.Domain.Data;

namespace Categorias.Api.Areas.Categorias.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        private readonly IParametroUseCase _parametroUseCase;

        public ParametrosController(ContextoParametro context)
        {
            _parametroUseCase = new ParametroUseCase();

        }

        [HttpPost]
        [Produces("application/json")]
        [Route("[action]")]
        public IActionResult ObtenerValorParametro(string sigla)
        {
            try
            {
                var result = _parametroUseCase.ObtenerValorParametro(sigla);
                if (!result.Succeeded)
                    return BadRequest();
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                //TODO: log error
                return new JsonResult(e.Message);
            }

        }


    }
}
