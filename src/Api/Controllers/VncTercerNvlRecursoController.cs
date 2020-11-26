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
    public class VncTercerNvlRecursoController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncTercerNvlRecursoController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncTercerNvlRecurso());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncTercerNvlRecursoAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto nulo");
                }
                return new JsonResult(this.administracionBO.AgregarVncTercerNvlRecurso(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            VncTercerNvlRecursoAM vinculo = administracionBO.ObtenerVncTercerNvlRecurso(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("Total/{id}")]
        public IActionResult getTotalId(int id)
        {
            return new JsonResult(administracionBO.ObtenerVncTercerNvlRecursoTotal(id));
        }
    }
}