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
    public class VncSubcategoriactgController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncSubcategoriactgController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncCategoriaSubcategoria());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncSubcategoriaCategoriaAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return new JsonResult(this.administracionBO.AgregarVncCategoriaSubcategoria(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            JsonResult response = new JsonResult(false);

            VncSubcategoriaCategoriaAM vinculo = administracionBO.ObtenerVncCategoriaSubcategoria(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return response;
        }
    }
}