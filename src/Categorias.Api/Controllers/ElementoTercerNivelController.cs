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
using Categorias.Domain.Categorias.AplicationModel;
using Categorias.Api.Helpers;

namespace Categorias.Api.Controllers
{
    [ApiController]
    [Route("api/CategoriasSubcategorias/[controller]")]
    public class ElementoTercerNivelController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public ElementoTercerNivelController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id)
        {

            try
            {
                return new JsonResult(this.administracionBO.ActualizarElementoTercerNivel(id));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            //return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodasElementoTercerNivel());
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("SedeElectronica/{id}/{padre}")]
        public IActionResult getSedeElectronicaId(int id, int padre)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelSedeElectronicaId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("VentanillaUnica/{id}/{padre}")]
        public IActionResult getVentanillaUnicaId(int id, int padre)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelVentanillaUnicaId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("TramiteServicio/{id}/{padre}")]
        public IActionResult getTramiteServicioId(string id, int padre)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelTramisteServicioId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("PortalTransversal/{id}/{padre}")]
        public IActionResult getPortalTransversalId(int id, int padre)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelPortalTransversalId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ElementoTercerNivelAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto Nulo");
                }
                return Ok(this.administracionBO.AgregarElementoTercerNivel(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpPost("VinculadasVentanillaUnica")]
        public IActionResult getVinculadasVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasVentanillaUnicaTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasVentanillaUnica/{id}")]
        public IActionResult getVinculadasVentanillaUnica(int id)
        {
            return new JsonResult(administracionBO.VinculadasVentanillaUnicaTercerNivel(id));
        }

        [HttpPost("VincularVentanillaUnica")]
        public IActionResult getVincularVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularVentanillaUnicaTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularVentanillaUnica/{id}")]
        public IActionResult getVincularVentanillaUnica(int id)
        {
            return new JsonResult(administracionBO.VincularVentanillaUnicaTercerNivel(id));
        }

        [HttpGet("Vincular/VentanillaUnica/Total/{id}")]
        public IActionResult GetVincularVentanillaUnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularVentanillaUnicaTercerNivelsTotal(id));
        }

        [HttpGet("Vincular/VentanillaUnica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularVentanillaUnicaTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/VentanillaUnica/Total/{id}")]
        public IActionResult GetVinculadasVentanillaUnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasVentanillaUnicaTercerNivelsTotal(id));
        }

        [HttpGet("Vinculadas/VentanillaUnica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasVentanillaUnicaTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpPost("VinculadasSedeElectronica")]
        public IActionResult getVinculadasSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasSedeElectronicaTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasSedeElectronica/{id}")]
        public IActionResult getVinculadasSedeElectronica(int id)
        {
            return new JsonResult(administracionBO.VinculadasSedeElectronicaTercerNivel(id));
        }

        [HttpPost("VincularSedeElectronica")]
        public IActionResult getVincularSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularSedeElectronicaTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularSedeElectronica/{id}")]
        public IActionResult getVincularSedeElectronica(int id)
        {
            return new JsonResult(administracionBO.VincularSedeElectronicaTercerNivel(id));
        }

        [HttpGet("Vincular/SedeElectronica/Total/{id}")]
        public IActionResult GetVincularSedeElectronicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularSedeElectronicaTercerNivelsTotal(id));
        }

        [HttpGet("Vincular/SedeElectronica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularSedeElectronicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularSedeElectronicaTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/SedeElectronica/Total/{id}")]
        public IActionResult GetVinculadasSedeElectronicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasSedeElectronicaTercerNivelsTotal(id));
        }

        [HttpGet("Vinculadas/SedeElectronica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasSedeElectronicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasSedeElectronicaTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpPost("VinculadasTramiteServicio")]
        public IActionResult getVinculadasTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasTramiteServicioTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasTramiteServicio/{id}")]
        public IActionResult getVinculadasTramiteServicio(int id)
        {
            return new JsonResult(administracionBO.VinculadasTramiteServicioTercerNivel(id));
        }

        [HttpPost("VincularTramiteServicio")]
        public IActionResult getVincularTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularTramiteServicioTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularTramiteServicio/{id}")]
        public IActionResult getVincularTramiteServicio(int id)
        {
            return new JsonResult(administracionBO.VincularTramiteServicioTercerNivel(id));
        }

        [HttpGet("Vincular/TramiteServicio/Total/{id}")]
        public IActionResult GetVincularTramiteServicioTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularTramiteServicioTercerNivelsTotal(id));
        }

        [HttpGet("Vincular/TramiteServicio/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularTramiteServicioTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularTramiteServicioTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/TramiteServicio/Total/{id}")]
        public IActionResult GetVinculadasTramiteServicioTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasTramiteServicioTercerNivelsTotal(id));
        }

        [HttpGet("Vinculadas/TramiteServicio/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasTramiteServicioTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasTramiteServicioTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpPost("VinculadasPortalTransversal")]
        public IActionResult getVinculadasPortalTransversal(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasPortalTransversalTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasPortalTransversal/{id}")]
        public IActionResult getVinculadasPortalTransversal(int id)
        {
            return new JsonResult(administracionBO.VinculadasPortalTransversalTercerNivel(id));
        }

        [HttpPost("VincularPortalTransversal")]
        public IActionResult getVincularPortalTransversal(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularPortalTransversalTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularPortalTransversal/{id}")]
        public IActionResult getVincularPortalTransversal(int id)
        {
            return new JsonResult(administracionBO.VincularPortalTransversalTercerNivel(id));
        }

        [HttpGet("Vincular/PortalTransversal/Total/{id}")]
        public IActionResult GetVincularPortalTransversalTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularPortalTransversalTercerNivelsTotal(id));
        }

        [HttpGet("Vincular/PortalTransversal/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularPortalTransversalTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularPortalTransversalTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/PortalTransversal/Total/{id}")]
        public IActionResult GetVinculadasPortalTransversalTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasPortalTransversalTercerNivelsTotal(id));
        }

        [HttpGet("Vinculadas/PortalTransversal/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasPortalTransversalTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasPortalTransversalTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpPost("VinculadasRecurso")]
        public IActionResult getVinculadasRecurso(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasRecursoTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpPost("VincularRecurso")]
        public IActionResult getVincularRecurso(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularRecursoTercerNivel(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("Vincular/Recurso/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularRecursoTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularRecursoTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/Recurso/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasRecursoTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasRecursoTercerNivelsTotal(id, tipo, filtro));
        }

        [HttpPost("TodosElementos")]
        public IActionResult GetTodosElementos(PaginateVincular objeto)
        {
            return new JsonResult(this.administracionBO.TodoTercerNivels(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("TodosElementos/{id}")]
        public IActionResult GetTodosElementos(int id)
        {
            return new JsonResult(this.administracionBO.TodoTercerNivels(id));
        }

        [HttpGet("TodosElementos/Agrupar/{id}")]
        public IActionResult GetTodosElementosGrupo(int id)
        {
            return new JsonResult(this.administracionBO.AgruparTipoElementoTercerNivel(id));
        }

        [HttpGet("TodosElementos/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetTodosElementosTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.TodoTotalTercerNivels(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/Recurso/Agrupar/{id}")]
        public IActionResult GetVinculadasRecursoTotalAgruparVinculadas(int id)
        {
            return new JsonResult(this.administracionBO.AgruparTipoRecursoTercerNivelVinculadas(id));
        }

        [HttpGet("Vincular/Recurso/Agrupar/{id}")]
        public IActionResult GetVinculadasRecursoTotalAgruparVincular(int id)
        {
            return new JsonResult(this.administracionBO.AgruparTipoRecursoTercerNivelVincular(id));
        }
    }
}
