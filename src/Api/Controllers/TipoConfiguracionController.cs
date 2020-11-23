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

namespace Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
    public class TipoConfiguracionController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TipoConfiguracionController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.AllTiposConfiguracion());
        }

        
        [HttpGet("{id}")]
        public IActionResult getPersonId(int id)
        {
            TipoConfiguracionAM TipoConfiguracion = administracionBO.GetTipoConfiguracionId(id);

            if (TipoConfiguracion != null)
            {
                return new JsonResult(TipoConfiguracion);
            }
            return NotFound();
        }
    }
}
