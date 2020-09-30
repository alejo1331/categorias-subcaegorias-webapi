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
    public class VncTercerNvlSubcategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VncTercerNvlSubcategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosVncTercerNvlSubcategoria());
        }

        [HttpPost]
        public IActionResult Post([FromBody] VncTercerNvlSubcategoriaAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return new JsonResult(this.administracionBO.AgregarVncTercerNvlSubcategoria(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getVncTercerNvlSubcategoria(int id)
        {
            JsonResult response = new JsonResult(false);

            VncTercerNvlSubcategoriaAM vinculo = administracionBO.ObtenerVncTercerNvlSubcategoria(id);
            if (vinculo != null)
            {
                return new JsonResult(vinculo);
            }
            return response;
        }
    }
}