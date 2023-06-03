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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaUseCase _categoriaUseCase;

        public CategoriasController()
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

        [HttpGet("Categorias/TipoCategoria/{siglaTipo}")]
        public IActionResult ObtenerListadoCategoriasPorTipoCategoria(string siglaTipo)
        {

            var result = _categoriaUseCase.ObtenerListadoCategoriasPorTipoCategoria(siglaTipo);

            if (!result.Succeeded)
                return BadRequest();
            return new JsonResult(result);
        }

        [HttpGet("Categorias/TipoCategoriaPaginado/{siglaTipo}/{parametro}/{pagina}")]
        public IActionResult ObtenerListadoCategoriasPorTipoCategoriaPaginado(string siglaTipo, string parametro, int pagina)
        {

            var result = _categoriaUseCase.ObtenerListadoCategoriasPorTipoCategoriaPaginado(siglaTipo, parametro, pagina);

            if (!result.Succeeded)
                return BadRequest();
            return new JsonResult(result);
        }
    }
}
