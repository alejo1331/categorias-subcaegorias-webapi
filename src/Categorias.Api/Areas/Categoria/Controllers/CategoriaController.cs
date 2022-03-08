using Categorias.Application.Models;
using Categorias.Application.UseCases;
using Categorias.Application.UseCases.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Categorias.Api.Areas.Categoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaUseCase _categoriaUseCase;

        public CategoriaController()
        {
            _categoriaUseCase = new CategoriaUseCase();

        }


        [HttpPost]
        [Produces("application/json")]
        [Route("[action]")]
        public IActionResult ObtenerListadoCategoriasPaginado(PaginateModel paginateModel)
        {
            try
            {
                var result = _categoriaUseCase.ObtenerListadoCategoriasPaginado(paginateModel);
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


        [HttpGet]
        [Route("[action]")]
        public IActionResult ObtenerListadoCategorias()
        {

            var result = _categoriaUseCase.ObtenerListadoCategorias();

            if (!result.Succeeded)
                return BadRequest();
            return new JsonResult(result);
        }
    }
}
