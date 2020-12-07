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
    public class ElementoCategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public ElementoCategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id)
        {
            try
            {
                return new JsonResult(this.administracionBO.ActualizarElementoCategoria(id));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodasElementoCategoria());
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            ElementoCategoriaAM objeto = administracionBO.ElementoCategoriaId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("SedeElectronica/{id}/{padre}")]
        public IActionResult getSedeElectronicaId(int id, int padre)
        {
            ElementoCategoriaAM objeto = administracionBO.ElementoCategoriaSedeElectronicaId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("VentanillaUnica/{id}/{padre}")]
        public IActionResult getVentanillaUnicaId(int id, int padre)
        {
            ElementoCategoriaAM objeto = administracionBO.ElementoCategoriaVentanillaUnicaId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("TramiteServicio/{id}/{padre}")]
        public IActionResult getTramiteServicioId(string id, int padre)
        {
            ElementoCategoriaAM objeto = administracionBO.ElementoCategoriaTramisteServicioId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("PortalTransversal/{id}/{padre}")]
        public IActionResult getPortalTransversalId(int id, int padre)
        {
            ElementoCategoriaAM objeto = administracionBO.ElementoCategoriaPortalTransversalId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ElementoCategoriaAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto Nulo");
                }
                return Ok(this.administracionBO.AgregarElementoCategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpPost("VinculadasPPT")]
        public IActionResult getVinculadasPPT(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasPPT(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularPPT")]
        public IActionResult getVincularPPT(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularPPT(objeto.idParametro, objeto.page, objeto.size));
        }
        
        [HttpPost("VinculadasSedeElectronica")]
        public IActionResult getVinculadasSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasSedeElectronica(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasSedeElectronica/{id}")]
        public IActionResult getVinculadasSedeElectronica(int id)
        {
            return new JsonResult(administracionBO.VinculadasSedeElectronica(id));
        }

        [HttpPost("VincularSedeElectronica")]
        public IActionResult getVincularSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularSedeElectronica(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularSedeElectronica/{id}")]
        public IActionResult getVincularSedeElectronica(int id)
        {
            return new JsonResult(administracionBO.VincularSedeElectronica(id));
        }

        [HttpPost("VinculadasVentanillaUnica")]
        public IActionResult getVinculadasVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasVentanillaUnica(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasVentanillaUnica/{id}")]
        public IActionResult getVinculadasVentanillaUnica(int id)
        {
            return new JsonResult(administracionBO.VinculadasVentanillaUnica(id));
        }

        [HttpPost("VincularVentanillaUnica")]
        public IActionResult getVincularVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularVentanillaUnica(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularVentanillaUnica/{id}")]
        public IActionResult getVincularVentanillaUnica(int id)
        {
            return new JsonResult(administracionBO.VincularVentanillaUnica(id));
        }
        
        [HttpPost("VinculadasTramiteServicio")]
        public IActionResult getVinculadasTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasTramiteServicio(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasTramiteServicio/{id}")]
        public IActionResult getVinculadasTramiteServicio(int id)
        {
            return new JsonResult(administracionBO.VinculadasTramiteServicio(id));
        }

        [HttpPost("VincularTramiteServicio")]
        public IActionResult getVincularTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularTramiteServicio(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularTramiteServicio/{id}")]
        public IActionResult getVincularTramiteServicio(int id)
        {
            return new JsonResult(administracionBO.VincularTramiteServicio(id));
        }

        [HttpPost("TodosElementos")]
        public IActionResult GetTodosElementos(PaginateVincular objeto)
        {
            return new JsonResult(this.administracionBO.Todo(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpPost("TodosElementos/{id}")]
        public IActionResult GetTodosElementos(int id)
        {
            return new JsonResult(this.administracionBO.Todo(id));
        }

        [HttpGet("TodosElementos/Agrupar/{id}")]
        public IActionResult GetTodosElementosGrupos(int id)
        {
            return new JsonResult(this.administracionBO.AgruparTipoElementoCategoria(id));
        }

        [HttpPost("TodosElementos/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetTodosElementosTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.TodoTotal(id, tipo, filtro));
        }

        [HttpPost("VincularPortalTransversal")]
        public IActionResult getVincularPortalTransversal(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularPortalTransversal(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularPortalTransversal/{id}")]
        public IActionResult getVincularPortalTransversal(int id)
        {
            return new JsonResult(administracionBO.VincularPortalTransversal(id));
        }

        [HttpPost("VinculadasPortalTransversal")]
        public IActionResult getVinculadasPortalTransversal(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasPortalTransversal(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasPortalTransversal/{id}")]
        public IActionResult getVinculadasPortalTransversal(int id)
        {
            return new JsonResult(administracionBO.VinculadasPortalTransversal(id));
        }

        [HttpPost("VincularRecurso")]
        public IActionResult getVincularRecurso(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularRecurso(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VinculadasRecurso")]
        public IActionResult getVinculadasRecurso(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasRecurso(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpGet("Vincular/SedeElectrocnica/Total/{id}")]
        public IActionResult GetVincularSedeElectrocnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularSedeElectronicaCategoriaTotal(id));
        }

        [HttpGet("Vincular/SedeElectrocnica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularSedeElectrocnicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularSedeElectronicaCategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/SedeElectrocnica/Total/{id}")]
        public IActionResult GetVinculadasSedeElectrocnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasSedeElectronicaCategoriaTotal(id));
        }

        [HttpGet("Vinculadas/SedeElectrocnica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasSedeElectrocnicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasSedeElectronicaCategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vincular/VentanillaUnica/Total/{id}")]
        public IActionResult GetVincularVentanillaUnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularVentanillaUnicaCategoriaTotal(id));
        }

        [HttpGet("Vincular/VentanillaUnica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularVentanillaUnicaCategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/VentanillaUnica/Total/{id}")]
        public IActionResult GetVinculadasVentanillaUnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasVentanillaUnicaCategoriaTotal(id));
        }

        [HttpGet("Vinculadas/VentanillaUnica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasVentanillaUnicaCategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/TramiteServicio/Total/{id}")]
        public IActionResult GetVinculadasTramiteServicioTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasTramiteServicioCategoriaTotal(id));
        }

        [HttpGet("Vinculadas/TramiteServicio/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasTramiteServicioTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasTramiteServicioCategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vincular/TramiteServicio/Total/{id}")]
        public IActionResult GetVincularTramiteServicioTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularTramiteServicioCategoriaTotal(id));
        }

        [HttpGet("Vincular/TramiteServicio/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularTramiteServicioTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularTramiteServicioCategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vincular/PortalTransversal/Total/{id}")]
        public IActionResult GetVincularPortalTransversalTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularPortalTransversalCategoriaTotal(id));
        }

        [HttpGet("Vincular/PortalTransversal/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularPortalTransversalTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularPortalTransversalCategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/PortalTransversal/Total/{id}")]
        public IActionResult GetVinculadasPortalTransversalTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasPortalTransversalCategoriaTotal(id));
        }

        [HttpGet("Vinculadas/PortalTransversal/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasPortalTransversalTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasPortalTransversalCategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vincular/Recurso/Total/{id}")]
        public IActionResult GetVincularRecursoTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularRecursoCategoriaTotal(id));
        }

        [HttpGet("Vinculadas/Recurso/Total/{id}")]
        public IActionResult GetVinculadasRecursoTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasRecursoCategoriaTotal(id));
        }
    }
}
