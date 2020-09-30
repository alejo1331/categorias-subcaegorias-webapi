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
    public class CategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public CategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.AllCategorias());
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return Ok(this.administracionBO.Add(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getCategoriaId(int id)
        {
            JsonResult response = new JsonResult(false);

            CategoriaAM categoria = administracionBO.GetCategoria(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return response;

        }

        [HttpGet("TipoCategoria/{id}")]
        public IActionResult getTipoCategoriaId(int id)
        {
            JsonResult response = new JsonResult(false);

            TipoCategoriaAM tipo = administracionBO.ObtenerCategoriaTipoCtg(id);
            if (tipo != null)
            {
                return new JsonResult(tipo);
            }
            return response;

        }

        [HttpPut("{id}")]
        public IActionResult PuttipoCategoria(int id, [FromBody] CategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            return new JsonResult(this.administracionBO.ActualizarCategoria(objeto));
        }
    }
}
