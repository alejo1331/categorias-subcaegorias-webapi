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


namespace Api.Controllers
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

        [HttpGet("Total/{id}")]
        public IActionResult getTotalId(int id)
        {
            return new JsonResult(administracionBO.ObtenerVncCategoriaRecursoTotal(id));
        }
    }
}