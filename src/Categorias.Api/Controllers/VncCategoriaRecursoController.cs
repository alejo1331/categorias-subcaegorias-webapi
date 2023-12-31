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


namespace Categorias.Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
    public class VncCategoriaRecursoController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncCategoriaRecursoController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriaRecurso());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncCategoriaRecursoAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto nulo");
                }
                return new JsonResult(this.administracionBO.AgregarVncCategoriaRecurso(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            JsonResult response = new JsonResult(false);

            VncCategoriaRecursoAM vinculo = administracionBO.ObtenerVncCategoriaRecurso(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("{id}/{padre}")]
        public IActionResult getId(int id, int padre)
        {
            JsonResult response = new JsonResult(false);

            VncCategoriaRecursoAM vinculo = administracionBO.ObtenerVncCategoriaRecurso(id, padre);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("Total/{id}")]
        public IActionResult getTotalId(int id)
        {
            return new JsonResult(administracionBO.ObtenerVncCategoriaRecursoTotal(id));
        }

        [HttpPut("Estado/{id}")]
        public IActionResult Estado(int id)
        {
            VncCategoriaRecursoAM recurso = this.administracionBO.ObtenerVncCategoriaRecurso(id);

            if (recurso == null)
            {
                return BadRequest("El objeto es nulo");
            }

            try
            {
                return new JsonResult(this.administracionBO.EstadoCategoriaRecurso(id));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            //return NoContent();
        }
    }
}