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
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return new JsonResult(this.administracionBO.AgregarVncTercerNvlRecurso(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            JsonResult response = new JsonResult(false);

            VncTercerNvlRecursoAM vinculo = administracionBO.ObtenerVncTercerNvlRecurso(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return response;
        }
    }
}