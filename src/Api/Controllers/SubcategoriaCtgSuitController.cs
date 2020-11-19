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
    }
}
