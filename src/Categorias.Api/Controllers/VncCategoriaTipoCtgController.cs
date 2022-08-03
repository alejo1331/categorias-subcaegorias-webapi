using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;


using Categorias.Domain.Bussiness.Interface;
using Categorias.Domain.Bussiness.BO;
using Categorias.Domain.Data;
using Domain.Categorias.AplicationModel;
using Categorias.Api.Helpers;


namespace Categorias.Api.Controllers
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

        [HttpPut("Actualizar/{id}")]
        public IActionResult Post([FromBody] VncCategoriaTipoCtgAM objeto, int id)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Owner object is null");
                }
                
                if(objeto.id != id)
                {
                    return BadRequest("Owner object is null for id");
                }
                return new JsonResult(this.administracionBO.ActualizarVncCategoriaTipoCtg(objeto));
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

        [HttpGet("{padre}/{id}")]
        public IActionResult getSubcategoriaId(int padre, int id)
        {
            VncCategoriaTipoCtgAM vinculo = administracionBO.ObtenerVncCategoriaTipoCtg(padre, id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpPost("Desvincular")]
        public IActionResult getCategoriaId(PaginateVincular desvincular)
        {
            return new JsonResult(this.administracionBO.TodosVncCategorias(desvincular.idParametro, desvincular.page, desvincular.size, desvincular.orden, desvincular.ascd));
        }

        [HttpPost("Desvincular/Vinculadas")]
        public IActionResult getCategoriaVinculadas(PaginateVincular desvincular)
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriasVinculadas(desvincular.idParametro, desvincular.page, desvincular.size, desvincular.orden, desvincular.ascd));
        }

        [HttpPost("Desvincular/Activas")]
        public IActionResult getCategoriaActivas(PaginateVincular desvincular)
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriasActivas(desvincular.idParametro, desvincular.page, desvincular.size, desvincular.orden, desvincular.ascd));
        }

        [HttpPost("Desvincular/Inactivas")]
        public IActionResult getCategoriaInactivas(PaginateVincular desvincular)
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriasInactivas(desvincular.idParametro, desvincular.page, desvincular.size, desvincular.orden, desvincular.ascd));
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
            //return NoContent();
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
            return new JsonResult(administracionBO.VincularCategorias(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
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
        [HttpGet("Desvincular/Total/Vinculadas/{id}")]
        public IActionResult getDevincularVinculadasTotal(int id)
        {
            return new JsonResult(administracionBO.DesvincularCategoriasVinculadasTotal(id));
        }
        [HttpGet("Desvincular/Total/Activas/{id}")]
        public IActionResult getDevincularTotalActivas(int id)
        {
            return new JsonResult(administracionBO.DesvincularCategoriasTotalActivas(id));
        }

        [HttpGet("Desvincular/Total/Inactivas/{id}")]
        public IActionResult getDevincularTotalinactivas(int id)
        {
            return new JsonResult(administracionBO.DesvincularCategoriasTotalInactivas(id));
        }
    }
}