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
    public class TercerNivelController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TercerNivelController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosTercerNivel());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TercerNivelAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Objeto nulo");
            }
            return new JsonResult(this.administracionBO.AgregarTercerNivel(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            TercerNivelAM tercer = administracionBO.ObtenerTercerNivel(id);
            if (tercer != null)
            {
                return new JsonResult(tercer);
            }
            return NotFound();
        }

        [HttpGet("Subcategoria/{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            SubcategoriaAM categoria = administracionBO.GetSubcategoriaTercerNvl(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TercerNivelAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarTercerNivel(objeto));

            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }
}