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
    public class TramiteServicioController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TramiteServicioController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodasTramiteServicio());
        }

        [HttpGet("{id}")]
        public IActionResult getId(string id)
        {
            TramiteServicioAM objeto = administracionBO.TramiteServicioId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpPost("Post/{id}")]
        public IActionResult getIdPost(string id)
        {
            TramiteServicioAM objeto = administracionBO.TramiteServicioId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpPost("Parametros")]
        public IActionResult getParametrosId(PaginateVincular vincular)
        {
            return new JsonResult(this.administracionBO.TodosParametrosTramitesServicios(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd, vincular.tipo, vincular.filtro));
        }

        [HttpPost("Tramites")]
        public IActionResult getTramites(HistorialHelper historial)
        {            
            return new JsonResult(this.administracionBO.ListaTramitesServicios(historial.fechaInicio, historial.fechaFinal, historial.page, historial.size, historial.orden, historial.ascd, historial.tipo, historial.filtro));
        }

        [HttpPost("Tramites/Consulta")]
        public IActionResult getTramites(PaginateVincular vincular)
        {            
            return new JsonResult(this.administracionBO.ListaTramitesServicios(vincular.page, vincular.size, vincular.orden, vincular.ascd, vincular.filtro, vincular.tipo));
        }

        [HttpPost("Tramites/SinPaginacion")]
        public IActionResult getTramitesPaginado(HistorialHelper historial)
        {            
            return new JsonResult(this.administracionBO.ListaTramitesServicios(historial.fechaInicio, historial.fechaFinal));
        }

        [HttpPost("Tramites/Total")]
        public IActionResult getTramitesTotal(HistorialHelper historial)
        {            
            return new JsonResult(this.administracionBO.TotalTramitesServicios(historial.fechaInicio, historial.fechaFinal, historial.tipo, historial.filtro));
        }

        [HttpPost("Tramites/Total/Consulta")]
        public IActionResult getTramitesTotalConsulta(HistorialHelper historial)
        {            
            return new JsonResult(this.administracionBO.TotalTramitesServicios(historial.tipo, historial.filtro));
        }

        [HttpGet("Parametros/{id}")]
        public IActionResult getParametrosId(int id)
        {
            return new JsonResult(this.administracionBO.TodosParametrosTramitesServicios(id));
        }

        [HttpGet("Parametros/Total/{id}")]
        public IActionResult getParametrosTotal(int id)
        {
            return new JsonResult(this.administracionBO.TodosParametrosTramitesServiciosTotal(id));
        }

        [HttpGet("Parametros/Total/{id}/{tipo}/{filtro}")]
        public IActionResult getParametrosTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.TodosParametrosTramitesServiciosTotal(id, tipo, filtro));
        }

        [HttpGet("Agrupacion/{id}")]
        public IActionResult GetAgrupacionEstado(int id)
        {
            return new JsonResult(this.administracionBO.AgruparEstadoTramitesServicios(id));
        }

        [HttpGet("Agrupacion/Tipo/{id}")]
        public IActionResult GetAgrupacionTipo(int id)
        {
            return new JsonResult(this.administracionBO.AgruparTipoTramitesServicios(id));
        }
        
    }
}
