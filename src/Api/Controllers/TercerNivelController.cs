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
                return BadRequest("Owner object is null");
            }
            return new JsonResult(this.administracionBO.AgregarTercerNivel(objeto));
        }

        [HttpGet("Subcategoria/{id}")]
        public IActionResult getTipoCategoriaId(int id)
        {
            JsonResult response = new JsonResult(false);

            SubcategoriaAM categoria = administracionBO.GetSubcategoriaTercerNvl(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return response;

        }

        [HttpPut("{id}")]
        public IActionResult PuttipoCategoria(int id, [FromBody] TercerNivelAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            return new JsonResult(this.administracionBO.ActualizarTercerNivel(objeto));
        }
    }
}