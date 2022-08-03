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

        [HttpGet("{padre}/{id}")]
        public IActionResult getSubcategoriaId(int padre, int id)
        {
            VncSubcategoriaCategoriaAM vinculo = administracionBO.ObtenerVncCategoriaSubcategoria(padre, id);
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

        [HttpPut("Actualizar/{id}")]
        public IActionResult PutCategoria(int id, VncSubcategoriaCategoriaAM objeto)
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
                return new JsonResult(this.administracionBO.ActualizarVncCategoriaSubcategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            //return NoContent();
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
            //return NoContent();
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

        [HttpPost("Vinculadas/TipoCero")]
        public IActionResult getVinculadasTipoCero(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoriaTipoCero(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpPost("Vincular")]
        public IActionResult getVincular(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VincularSubcategoria(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
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

        [HttpGet("Vinculadas/Total/TipoCero/{id}")]
        public IActionResult getVinculadasTipoCeroTotal(int id)
        {
            return new JsonResult(administracionBO.VinculadasSubcategoriasTipoCeroTotal(id));
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