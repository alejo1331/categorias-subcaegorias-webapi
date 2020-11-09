using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;


using Domain.Bussiness.Interface;
using Domain.Bussiness.BO;
using Domain.Data;
using Domain.Categorias.AplicationModel;

using Api.Helpers;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
    public class VncSubcategoriactgController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncSubcategoriactgController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriaSubcategoria());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncSubcategoriaCategoriaAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto nulo");
                }
                return new JsonResult(this.administracionBO.AgregarVncCategoriaSubcategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            VncSubcategoriaCategoriaAM vinculo = administracionBO.ObtenerVncCategoriaSubcategoria(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("Subcategorias/{id}")]
        public IActionResult getSubcategorias(int id)
        {
            return new JsonResult(this.administracionBO.TodosVncSubcategoria(id));
        }

        [HttpPut("{idCategoria}/{idSubcategoria}")]
        public IActionResult PutCategoria(int idCategoria, int idSubcategoria)
        {
            try
            {
                VncSubcategoriaCategoriaAM objeto = this.administracionBO.DesvncSubcategoriasCategoria(idCategoria, idSubcategoria);
                if (objeto == null)
                    return BadRequest("Objeto nulo");

                return new JsonResult(objeto);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }

        [HttpPut("Desvincular/Subategorias")]
        public IActionResult PuttipoCategoria(DvcSubcategoriaCategoria objeto)
        {
            if (objeto == null)
                return new JsonResult(false);

            this.administracionBO.DesvncSubcategoriasCategoria(objeto);
            return new JsonResult(true);
        }

        [HttpPost("Vincular/Subcategorias")]
        public IActionResult PutVincular(DvcSubcategoriaCategoria objeto)
        {
            if (objeto == null)
                return new JsonResult(false);

            this.administracionBO.VincularSubcategoriasCategoria(objeto);
            return new JsonResult(true);
        }

        [HttpPost("Vinculadas")]
        public IActionResult getVinculadas(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoria(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpPost("Vincular")]
        public IActionResult getVincular(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VincularSubcategoria(vincular.idParametro, vincular.page, vincular.size));
        }

        [HttpPost("Vinculadas/Activas")]
        public IActionResult getVinculadasActivas(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoriaActivas(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpPost("Vinculadas/Inactivas")]
        public IActionResult getVinculadasInactivas(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoriaInactivas(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpGet("Vinculadas/{id}")]
        public IActionResult getVinculadas(int id)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoria(id));
        }

        [HttpGet("Vinculadas/Total/{id}")]
        public IActionResult getVinculadasTotal(int id)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoriasTotal(id));
        }

        [HttpGet("Vinculadas/Total/Activas/{id}")]
        public IActionResult getVinculadasTotalActivas(int id)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoriasTotalActivas(id));
        }

        [HttpGet("Vinculadas/Total/Inactivas/{id}")]
        public IActionResult getVinculadasTotalInactivas(int id)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoriasTotalInactivas(id));
        }

        [HttpGet("Vincular/Total/{id}")]
        public IActionResult getVincularTotal(int id)
        {
            return new JsonResult(administracionBO.VincularSubcategoriasTotal(id));
        }
    }
}