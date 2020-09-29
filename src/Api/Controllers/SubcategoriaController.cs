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
    public class SubcategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public SubcategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosSubcategoria());
        }

        [HttpPost]
        public IActionResult Post([FromBody] SubcategoriaAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return new JsonResult(this.administracionBO.AgregarSubcategoria(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            JsonResult response = new JsonResult(false);

            SubcategoriaAM subcategoria = administracionBO.GetSubCategoria(id);
            if (subcategoria != null)
            {
                return new JsonResult(subcategoria);
            }
            return response;
        }

        [HttpGet("Categoria/{id}")]
        public IActionResult getTipoCategoriaId(int id)
        {
            JsonResult response = new JsonResult(false);

            CategoriaAM categoria = administracionBO.GetCategoriaSubcatgoria(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return response;

        }

        [HttpPut("{id}")]
        public IActionResult PuttipoCategoria(int id, [FromBody] SubcategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            return new JsonResult(this.administracionBO.ActualizarSubCategoria(objeto));
        }
    }
}