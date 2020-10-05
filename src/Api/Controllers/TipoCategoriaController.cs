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
    public class TipoCategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TipoCategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.AllTiposCtg());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoCategoriaAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto nulo");
                }
                return new JsonResult(this.administracionBO.Add(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {

            TipoCategoriaAM subcategoria = administracionBO.getTipoCtgId(id);
            if (subcategoria != null)
            {
                return new JsonResult(subcategoria);
            }
            return NotFound();
        }

        [HttpGet("Buscar/{data}")]
        public IActionResult getData(string data)
        {
            return new JsonResult(this.administracionBO.SearchTiposCtg(data));
        }

        [HttpPut("{id}")]
        public IActionResult PuttipoCategoria(int id, [FromBody] TipoCategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarTipoCategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }
}