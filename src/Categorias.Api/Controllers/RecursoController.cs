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
using Categorias.Domain.Categorias.AplicationModel;


namespace Categorias.Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
    public class RecursoController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public RecursoController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosRecurso());
        }

        [HttpPost]
        public IActionResult Post([FromBody] RecursoAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto nulo");
                }
                return Ok(this.administracionBO.AgregarRecurso(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            RecursoAM recurso = administracionBO.ObtenerRecurso(id);
            if (recurso != null)
            {
                return new JsonResult(recurso);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RecursoAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarRecurso(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }

        [HttpPut("Estado/{id}")]
        public IActionResult Estado(int id)
        {
            RecursoAM recurso = this.administracionBO.ObtenerRecurso(id);

            if (recurso == null)
            {
                return BadRequest("El objeto es nulo");
            }

            try
            {
                return new JsonResult(this.administracionBO.EstadoRecurso(id));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }
}