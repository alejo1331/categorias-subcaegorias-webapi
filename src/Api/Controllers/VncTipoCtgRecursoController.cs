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
    public class VncTipoCtgRecursoController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncTipoCtgRecursoController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncTipoCtgRecurso());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncTipoCtgRecursoAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Owner object is null");
                }
                return new JsonResult(this.administracionBO.AgregarVncTipoCtgRecurso(objeto));
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

            VncTipoCtgRecursoAM vinculo = administracionBO.ObtenerVncTipoCtgRecurso(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return response;
        }
    }
}