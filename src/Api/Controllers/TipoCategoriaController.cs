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
            if (objeto == null)
            {
                return BadRequest("Owner object is null");
            }
            return new JsonResult(this.administracionBO.Add(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            JsonResult response = new JsonResult(false);

            TipoCategoriaAM subcategoria = administracionBO.getTipoCtgId(id);
            if (subcategoria != null)
            {
                return new JsonResult(subcategoria);
            }
            return response;
        }
    }
}