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
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto nulo");
                }
                return new JsonResult(this.administracionBO.AgregarTipoParametro(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getTipoParametroId(int id)
        {
            TipoParametroAM parametro = administracionBO.ObtenerTipoParametro(id);
            if (parametro != null)
            {
                return new JsonResult(parametro);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutTipoParametro(int id, [FromBody] TipoParametroAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarTipoParametro(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }
}