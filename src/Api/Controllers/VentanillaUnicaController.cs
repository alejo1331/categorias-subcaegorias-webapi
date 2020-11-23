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
    public class VentanillaUnicaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public VentanillaUnicaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodasVentanillaUnica());
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            VentanillaUnicaAM objeto = administracionBO.VentanillaUnicaId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpPost("Parametros")]
        public IActionResult getParametrosId(PaginateVincular vincular)
        {
            return new JsonResult(this.administracionBO.TodosParametrosVentanillaUnica(vincular.idParametro, vincular.page, vincular.size, vincular.orden, vincular.ascd, vincular.tipo, vincular.filtro));
        }

        [HttpGet("Parametros/{id}")]
        public IActionResult getParametrosId(int id)
        {
            return new JsonResult(this.administracionBO.TodosParametrosVentanillaUnica(id));
        }

        [HttpGet("Parametros/Total/{id}")]
        public IActionResult getParametrosTotal(int id)
        {
            return new JsonResult(this.administracionBO.TodosParametrosVentanillaUnicaTotal(id));
        }

        [HttpGet("Parametros/Total/{id}/{tipo}/{filtro}")]
        public IActionResult getParametrosTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.TodosParametrosVentanillaUnicaTotal(id, tipo, filtro));
        }

        [HttpGet("Agrupacion/{id}")]
        public IActionResult GetAgrupacionEstado(int id)
        {
            return new JsonResult(this.administracionBO.AgruparEstadoVentanillaUnica(id));
        }

        [HttpGet("Agrupacion/Tipo/{id}")]
        public IActionResult GetAgrupacionTipo(int id)
        {
            return new JsonResult(this.administracionBO.AgruparTipoVentanillaUnica(id));
        }
    }
}
