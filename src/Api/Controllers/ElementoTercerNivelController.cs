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
    public class ElementoTercerNivelController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public ElementoTercerNivelController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id, [FromBody] ElementoTercerNivelAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarElementoTercerNivel(objeto));
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

        [HttpGet("SedeElectronica/{id}")]
        public IActionResult getSedeElectronicaId(int id)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelSedeElectronicaId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("VentanillaUnica/{id}")]
        public IActionResult getVentanillaUnicaId(int id)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelVentanillaUnicaId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("TramiteServicio/{id}")]
        public IActionResult getTramiteServicioId(int id)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelTramisteServicioId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("PortalTransversal/{id}")]
        public IActionResult getPortalTransversalId(int id)
        {
            ElementoTercerNivelAM objeto = administracionBO.ElementoTercerNivelPortalTransversalId(id);

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
            return new JsonResult(administracionBO.VinculadasRecursoTercerNivel(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularRecurso")]
        public IActionResult getVincularRecurso(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularRecursoTercerNivel(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpGet("Vincular/Recurso/Total/{id}")]
        public IActionResult GetVincularRecursoTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularRecursoTercerNivelsTotal(id));
        }

        [HttpGet("Vinculadas/Recurso/Total/{id}")]
        public IActionResult GetVinculadasRecursoTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasRecursoTercerNivelsTotal(id));
        }

        [HttpPost("TodosElementos")]
        public IActionResult GetTodosElementos(PaginateVincular objeto)
        {
            return new JsonResult(this.administracionBO.TodoTercerNivels(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd));
        }

        [HttpGet("TodosElementos/{id}")]
        public IActionResult GetTodosElementos(int id)
        {
            return new JsonResult(this.administracionBO.TodoTercerNivels(id));
        }

        [HttpGet("TodosElementos/Total/{id}")]
        public IActionResult GetTodosElementosTotal(int id)
        {
            return new JsonResult(this.administracionBO.TodoTotalTercerNivels(id));
        }
    }
}
