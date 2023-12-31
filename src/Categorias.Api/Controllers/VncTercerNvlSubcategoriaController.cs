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
    public class VncTercerNvlSubcategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncTercerNvlSubcategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPut("Actualizar/{id}")]
        public IActionResult PutCategoria(int id, VncTercerNvlSubcategoriaAM objeto)
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
                return new JsonResult(this.administracionBO.ActualizarVncTercerNvlSubcategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            //return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncTercerNvlSubcategoria());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncTercerNvlSubcategoriaAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Owner object is null");
                }
                return new JsonResult(this.administracionBO.AgregarVncTercerNvlSubcategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getVncTercerNvlSubcategoria(int id)
        {
            VncTercerNvlSubcategoriaAM vinculo = administracionBO.ObtenerVncTercerNvlSubcategoria(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("{padre}/{id}")]
        public IActionResult getVncTercerNvlSubcategoria(int padre, int id)
        {
            VncTercerNvlSubcategoriaAM vinculo = administracionBO.ObtenerVncTercerNvlSubcategoria(padre, id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("TercerNivel/{id}")]
        public IActionResult getTercerNivels(int id)
        {
            return new JsonResult(this.administracionBO.TodosVncTercerNivel(id));
        }

        [HttpPut("{idSubcategoria}/{idTercerNivel}")]
        public IActionResult PuttipoCategoria(int idSubcategoria, int idTercerNivel)
        {
            try
            {
                VncTercerNvlSubcategoriaAM objeto = this.administracionBO.DesvncTercerNvlSubcategoria(idSubcategoria, idTercerNivel);
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

        [HttpPut("Desvincular/TercerNivels")]
        public IActionResult PuttipoCategoria(DvcTercerNivelSct objeto)
        {
            if(objeto == null)
                return new JsonResult(false);

            this.administracionBO.DesvncTercerNvlSbc(objeto);
            return new JsonResult(true);
        }

        [HttpPut("Vincular/TercerNivels")]
        public IActionResult PutTercerNivel(DvcTercerNivelSct objeto)
        {
            if(objeto == null)
                return new JsonResult(false);

            this.administracionBO.VincularTercerNvlSbc(objeto);
            return new JsonResult(true);
        }

        [HttpPost("Vinculadas")]
        public IActionResult getVinculadas(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivel(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpPost("Vinculadas/TipoCero")]
        public IActionResult getVinculadasTipoCero(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivelTipoCero(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpPost("Vincular")]
        public IActionResult getVincular(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VincularTercerNivel(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpPost("Vinculadas/Activas")]
        public IActionResult getVinculadasActivas(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivelActivas(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpPost("Vinculadas/Inactivas")]
        public IActionResult getVinculadasInactivas(PaginateVincular vincular)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivelInactivas(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd));
        }

        [HttpGet("Vinculadas/{id}")]
        public IActionResult getVinculadas(int id)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivel(id));
        }

        [HttpGet("Vinculadas/Total/{id}")]
        public IActionResult getVinculadasTotal(int id)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivelTotal(id));
        }

        [HttpGet("Vinculadas/Total/TipoCero/{id}")]
        public IActionResult getVinculadasTotalTipoCero(int id)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivelTipoCeroTotal(id));
        }

        [HttpGet("Vinculadas/Total/Activas/{id}")]
        public IActionResult getVinculadasTotalActivas(int id)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivelTotalActivas(id));
        }

        [HttpGet("Vinculadas/Total/Inactivas/{id}")]
        public IActionResult getVinculadasTotalInactivas(int id)
        {
            return new JsonResult(administracionBO.VinculadasTercerNivelTotalInactivas(id));
        }

        [HttpGet("Vincular/Total/{id}")]
        public IActionResult getVincularTotal(int id)
        {
            return new JsonResult(administracionBO.VincularTercerNivelTotal(id));
        }
        
    }
}