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
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto Nulo");
                }
                return Ok(this.administracionBO.Add(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            CategoriaAM categoria = administracionBO.GetCategoria(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return NotFound();
        }

        [HttpGet("TipoCategoria/{id}")]
        public IActionResult getTipoCategoriaId(int id)
        {
            TipoCategoriaAM tipo = administracionBO.ObtenerCategoriaTipoCtg(id);
            if (tipo != null)
            {
                return new JsonResult(tipo);
            }
            return NotFound();
        }

        [HttpGet("Buscar/{data}")]
        public IActionResult getTipoCategoriaId(string data)
        {
            return new JsonResult(this.administracionBO.SearchCategorias(data));
        }

        [HttpPut("{id}")]
        public IActionResult PuttipoCategoria(int id, [FromBody] CategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarCategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }
}
