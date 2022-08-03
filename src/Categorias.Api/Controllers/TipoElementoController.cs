using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;


using Categorias.Domain.Bussiness.Interface;
using Categorias.Domain.Bussiness.BO;
using Categorias.Domain.Data;
using Domain.Categorias.AplicationModel;

namespace Categorias.Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
    public class TipoElementoController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TipoElementoController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodasTipoElemento());
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            TipoElementoAM objeto = administracionBO.TipoElementoId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("Sigla/{sigla}")]
        public IActionResult getSigla(string sigla)
        {
            TipoElementoAM objeto = administracionBO.TipoElementoSigla(sigla);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        
    }
}
