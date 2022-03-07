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
    public class SubcategoriaCtgSuitController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public SubcategoriaCtgSuitController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.AllSubcategoriaCtgSuit());
        }

        [HttpPost]
        public IActionResult Post([FromBody] SubcategoriaCtgSuitAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return Ok(this.administracionBO.AddSubcategoriaCtgSuit(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            SubcategoriaCtgSuitAM SubcategoriaCtgSuit = administracionBO.GetSubcategoriaCtgSuitId(id);

            if (SubcategoriaCtgSuit != null)
            {
                return new JsonResult(SubcategoriaCtgSuit);
            }
            return NotFound();
        }

        [HttpGet("Subcategorias/{idSubcategoria}")]
        public IActionResult idSubcategoria(int idSubcategoria)
        {
            return new JsonResult(this.administracionBO.AllSubcategoriaCtgSuitIdCtg(idSubcategoria));
        }

        [HttpGet("Subcategorias/{idSubcategoria}/{idCategoriaSuit}")]
        public IActionResult idSubcategoria(int idSubcategoria, int idCategoriaSuit)
        {
            return new JsonResult(this.administracionBO.GetSubcategoriaCtgSuitId(idSubcategoria, idCategoriaSuit));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] SubcategoriaCtgSuitAM objeto, int id)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }

            if (objeto.id != id)
            {
                return BadRequest("Owner object is null");
            }
            
            return Ok(this.administracionBO.updateSubcategoriaCtgSuitAM(objeto));
        }
    }
}
