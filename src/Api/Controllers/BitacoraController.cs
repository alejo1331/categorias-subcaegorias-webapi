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
using Api.Helpers;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
    public class BitacoraController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public BitacoraController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.AllBitacora());
        }

        [HttpGet("Total/{tipo}/{filtro}")]
        public IActionResult GetTodos(int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.TotalBitacora(tipo, filtro));
        }

        [HttpPost("Todos")]
        public IActionResult GetTotal(PaginateVincular objeto)
        {
            return new JsonResult(this.administracionBO.AllBitacora(objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BitacoraCategoriasAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return Ok(this.administracionBO.AddBitacora(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getPersonId(int id)
        {
            BitacoraCategoriasAM Bitacora = administracionBO.GetBitacoraId(id);

            if (Bitacora != null)
            {
                return new JsonResult(Bitacora);
            }
            return NotFound();
        }
    }
}
