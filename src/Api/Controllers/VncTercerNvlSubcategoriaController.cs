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
    public class VncTercerNvlSubcategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncTercerNvlSubcategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
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
            return NoContent();
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
            return new JsonResult(administracionBO.VinculadasTercerNivel(vincular.idParametro, vincular.page, vincular.size));
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
    }
}