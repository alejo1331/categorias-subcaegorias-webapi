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
    public class TipoRecursoController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TipoRecursoController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosTipoRecurso());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoRecursoAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return new JsonResult(this.administracionBO.AgregarTipoRecurso(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            JsonResult response = new JsonResult(false);

            TipoRecursoAM tipo = administracionBO.ObtenerTipoRecurso(id);
            if (tipo != null)
            {
                return new JsonResult(tipo);
            }
            return response;
        }
    }
}