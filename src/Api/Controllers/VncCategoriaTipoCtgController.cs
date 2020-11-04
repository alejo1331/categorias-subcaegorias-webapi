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
    public class VncCategoriaTipoCtgController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncCategoriaTipoCtgController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriaTipoCtg());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncCategoriaTipoCtgAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Owner object is null");
                }
                return new JsonResult(this.administracionBO.AgregarVncCategoriaTipoCtg(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            VncCategoriaTipoCtgAM vinculo = administracionBO.ObtenerVncCategoriaTipoCtg(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpPost("Desvincular")]
        public IActionResult getCategoriaId(PaginateVincular desvincular)
        {
            return new JsonResult(this.administracionBO.TodosVncCategorias(desvincular.idParametro, desvincular.page, desvincular.size));
        }

        [HttpPost("Desvincular/Activas")]
        public IActionResult getCategoriaActivas(PaginateVincular desvincular)
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriasActivas(desvincular.idParametro, desvincular.page, desvincular.size));
        }

        [HttpGet("Desvincular/{id}")]
        public IActionResult getCategoriaId(int id)
        {
            return new JsonResult(this.administracionBO.TodosVncCategorias(id));
        }

        [HttpPut("{idTipoCategoria}/{idCategoria}")]
        public IActionResult PuttipoCategoria(int idTipoCategoria, int idCategoria)
        {
            try
            {
                VncCategoriaTipoCtgAM objeto = this.administracionBO.DesvncCategoriaTipoCtg(idTipoCategoria, idCategoria);
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

        [HttpPut("Desvincular/Categorias")]
        public IActionResult PuttipoCategoria(DvcCategoriaTipoCtg objeto)
        {
            if (objeto == null)
                return new JsonResult(false);

            this.administracionBO.DesvncCategoriaTipo(objeto);
            return new JsonResult(true);
        }

        [HttpPost("Vincular/Categorias")]
        public IActionResult PutVincular(DvcCategoriaTipoCtg objeto)
        {
            if (objeto == null)
                return new JsonResult(false);

            this.administracionBO.VincularCategoriaTipo(objeto);
            return new JsonResult(true);
        }

        [HttpPost("Vincular")]
        public IActionResult getVincular(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VincularCategorias(vincular.idParametro, vincular.page, vincular.size));
        }

        [HttpGet("Vincular/Total/{id}")]
        public IActionResult getVincularTotal(int id)
        {
            return new JsonResult(administracionBO.VincularCategoriasTotal(id));
        }

        [HttpGet("Desvincular/Total/{id}")]
        public IActionResult getDevincularTotal(int id)
        {
            return new JsonResult(administracionBO.DesvincularCategoriasTotal(id));
        }
        [HttpGet("Desvincular/Total/Activas/{id}")]
        public IActionResult getDevincularTotalActivas(int id)
        {
            return new JsonResult(administracionBO.DesvincularCategoriasTotalActivas(id));
        }
    }
}