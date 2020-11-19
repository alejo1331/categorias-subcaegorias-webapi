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
    public class CategoriaSUITController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public CategoriaSUITController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.AllCategoriasSuit());
        }

        [HttpGet("{id}")]
        public IActionResult getPersonId(int id)
        {
            CategoriaSUITAM CategoriaSUIT = administracionBO.GetCategoriaSuitId(id);

            if (CategoriaSUIT != null)
            {
                return new JsonResult(CategoriaSUIT);
            }
            return NotFound();
        }
    }
}
