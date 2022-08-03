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
    public class VncSubcategoriaRecursoController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncSubcategoriaRecursoController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncSubcategoriaRecurso());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncSubcategoriaRecursoAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto modelo");
                }
                return new JsonResult(this.administracionBO.AgregarVncSubcategoriaRecurso(objeto));
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

            VncSubcategoriaRecursoAM vinculo = administracionBO.ObtenerVncSubcategoriaRecurso(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("{id}/{Padre}")]
        public IActionResult getId(int id, int padre)
        {
            JsonResult response = new JsonResult(false);

            VncSubcategoriaRecursoAM vinculo = administracionBO.ObtenerVncSubcategoriaRecurso(id, padre);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("Total/{id}")]
        public IActionResult getTotalId(int id)
        {
            return new JsonResult(administracionBO.ObtenerVncSubcategoriaRecursoTotal(id));
        }
        
        [HttpPut("Estado/{id}")]
        public IActionResult Estado(int id)
        {
            VncSubcategoriaRecursoAM recurso = this.administracionBO.ObtenerVncSubcategoriaRecurso(id);

            if (recurso == null)
            {
                return BadRequest("El objeto es nulo");
            }

            try
            {
                return new JsonResult(this.administracionBO.EstadoSubcategoriaRecurso(id));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            //return NoContent();
        }
    }
}