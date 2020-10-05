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
    public class VncCategoriaTipoCtgController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncCategoriaTipoCtgController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriaTipoCtg());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncCategoriaTipoCtgAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Owner object is null");
                }
                return new JsonResult(this.administracionBO.AgregarVncCategoriaTipoCtg(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            VncCategoriaTipoCtgAM vinculo = administracionBO.ObtenerVncCategoriaTipoCtg(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return NotFound();
        }

        [HttpGet("Categorias/{id}")]
        public IActionResult getCategoriaId(int id)
        {
            return new JsonResult(this.administracionBO.TodosVncCategorias(id));
        }
    }
}