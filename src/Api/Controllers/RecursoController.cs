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
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return Ok(this.administracionBO.AgregarRecurso(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            JsonResult response = new JsonResult(false);

            RecursoAM recurso = administracionBO.ObtenerRecurso(id);
            if (recurso != null)
            {
                return new JsonResult(recurso);
            }
            return response;

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RecursoAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            return new JsonResult(this.administracionBO.ActualizarRecurso(objeto));
        }
    }
}