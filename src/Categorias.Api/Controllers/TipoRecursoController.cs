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
using Categorias.Domain.Categorias.AplicationModel;


namespace Categorias.Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
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
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto nulo");
                }
                return new JsonResult(this.administracionBO.AgregarTipoRecurso(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            TipoRecursoAM tipo = administracionBO.ObtenerTipoRecurso(id);
            if (tipo != null)
            {
                return new JsonResult(tipo);
            }
            return NotFound();
        }

        [HttpGet("Sigla/{sigla}")]
        public IActionResult getSubcategoriaSigla(string sigla)
        {
            TipoRecursoAM tipo = administracionBO.ObtenerTipoRecursoSigla(sigla);
            if (tipo != null)
            {
                return new JsonResult(tipo);
            }
            return NotFound();
        }
    }
}