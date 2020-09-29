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
    public class TipoParametroController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TipoParametroController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosTipoParamtero());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoParametroAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return new JsonResult(this.administracionBO.AgregarTipoParametro(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getTipoParametroId(int id)
        {
            JsonResult response = new JsonResult(false);

            TipoParametroAM parametro = administracionBO.ObtenerTipoParametro(id);
            if (parametro != null)
            {
                return new JsonResult(parametro);
            }
            return response;
        }

        [HttpPut("{id}")]
        public IActionResult PutTipoParametro(int id, [FromBody] TipoParametroAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            return new JsonResult(this.administracionBO.ActualizarTipoParametro(objeto));
        }
    }
}