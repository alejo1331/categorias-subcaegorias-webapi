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
    public class CategoriaCtgSuitController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public CategoriaCtgSuitController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.AllCategoriaCtgSuit());
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaCtgSuitAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return Ok(this.administracionBO.AddCategoriaCtgSuit(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            CategoriaCtgSuitAM CategoriaCtgSuit = administracionBO.GetCategoriaCtgSuitId(id);

            if (CategoriaCtgSuit != null)
            {
                return new JsonResult(CategoriaCtgSuit);
            }
            return NotFound();
        }

        [HttpGet("Categorias/{idCategoria}")]
        public IActionResult IdCategoria(int idCategoria)
        {
            return new JsonResult(this.administracionBO.AllCategoriaCtgSuitIdCtg(idCategoria));
        }

        [HttpGet("Categorias/{idCategoria}/{idCategoriaSuit}")]
        public IActionResult IdCategoria(int idCategoria, int idCategoriaSuit)
        {
            return new JsonResult(this.administracionBO.GetCategoriaCtgSuitId(idCategoria, idCategoriaSuit));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] CategoriaCtgSuitAM objeto, int id)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }

            if (objeto.id != id)
            {
                return BadRequest("Owner object is null");
            }
            
            return Ok(this.administracionBO.updateCategoriaCtgSuitAM(objeto));
        }
    }
}
