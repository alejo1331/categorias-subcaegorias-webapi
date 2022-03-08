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
using Domain.Categorias.AplicationModel;

namespace Categorias.Api.Controllers
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

        [HttpGet("Descripcion/{texto}")]
        public IActionResult getTexto(string texto)
        {
            EstadoAM estado = administracionBO.GetDescripcionEstado(texto);

            if (estado != null)
            {
                return new JsonResult(estado);
            }
            return NotFound();
        }
    }
}
