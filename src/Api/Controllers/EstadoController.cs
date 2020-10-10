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
    public class EstadoController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public EstadoController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.All());
        }

        [HttpPost]
        public IActionResult Post([FromBody] EstadoAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return Ok(this.administracionBO.AddEstado(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getPersonId(int id)
        {
            EstadoAM estado = administracionBO.getIdEstado(id);

            if (estado != null)
            {
                return new JsonResult(estado);
            }
            return NotFound();
        }
    }
}
