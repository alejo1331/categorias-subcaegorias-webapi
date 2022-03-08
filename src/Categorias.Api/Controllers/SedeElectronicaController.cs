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
using Categorias.Api.Helpers;

namespace Categorias.Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
    public class SedeElectronicaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public SedeElectronicaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodasSedeElectronica());
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            SedeElectronicaAM objeto = administracionBO.SedeElectronicaId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpPost("Post/{id}")]
        public IActionResult getIdPost(int id)
        {
            SedeElectronicaAM objeto = administracionBO.SedeElectronicaId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpPost("Parametros")]
        public IActionResult getParametrosId(PaginateVincular vincular)
        {
            return new JsonResult(this.administracionBO.TodosParametrosSedesElectronicas(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd, vincular.tipo, vincular.filtro));
        }

        [HttpGet("Parametros/{id}")]
        public IActionResult getParametrosId(int id)
        {
            return new JsonResult(this.administracionBO.TodosParametrosSedesElectronicas(id));
        }

        [HttpGet("Parametros/Total/{id}")]
        public IActionResult GetTotal(int id)
        {
            return new JsonResult(this.administracionBO.TodosParametrosSedesElectronicasTotal(id));
        }

        [HttpGet("Parametros/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.TodosParametrosSedesElectronicasTotal(id, tipo, filtro));
        }

        [HttpGet("Agrupacion/{id}")]
        public IActionResult GetAgrupacionEstado(int id)
        {
            return new JsonResult(this.administracionBO.AgruparEstadoSedesElectronicas(id));
        }

        [HttpGet("Agrupacion/Tipo/{id}")]
        public IActionResult GetAgrupacionTipo(int id)
        {
            return new JsonResult(this.administracionBO.AgruparTipoSedesElectronicas(id));
        }
        
    }
}
