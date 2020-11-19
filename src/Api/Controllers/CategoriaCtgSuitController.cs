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
    }
}
