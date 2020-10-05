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
                return BadRequest("Objeto es nulo");
            }
            return new JsonResult(this.administracionBO.AgregarSubcategoria(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            SubcategoriaAM subcategoria = administracionBO.GetSubCategoria(id);
            if (subcategoria != null)
            {
                return new JsonResult(subcategoria);
            }
            return NotFound();
        }

        [HttpGet("Categoria/{id}")]
        public IActionResult getTipoCategoriaId(int id)
        {
            CategoriaAM categoria = administracionBO.GetCategoriaSubcatgoria(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return NotFound();
        }

        [HttpGet("Buscar/{data}")]
        public IActionResult getTipoCategoriaId(string data)
        {
            return new JsonResult(this.administracionBO.SearchSubcategoria(data));
        }

        [HttpPut("{id}")]
        public IActionResult PuttipoCategoria(int id, [FromBody] SubcategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarSubCategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }
}