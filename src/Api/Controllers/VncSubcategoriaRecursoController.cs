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
using Domain.AplicationModel;



namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}