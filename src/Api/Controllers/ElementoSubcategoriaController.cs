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
    public class ElementoSubcategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public ElementoSubcategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id, [FromBody] ElementoSubcategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarElementoSubcategoria(objeto));
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
            return new JsonResult(this.administracionBO.TodasElementoSubcategoria());
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            ElementoSubcategoriaAM objeto = administracionBO.ElementoSubcategoriaId(id);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("SedeElectronica/{id}/{padre}")]
        public IActionResult getSedeElectronicaId(int id, int padre)
        {
            ElementoSubcategoriaAM objeto = administracionBO.ElementoSubcategoriaSedeElectronicaId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("VentanillaUnica/{id}/{padre}")]
        public IActionResult getVentanillaUnicaId(int id, int padre)
        {
            ElementoSubcategoriaAM objeto = administracionBO.ElementoSubcategoriaVentanillaUnicaId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("TramiteServicio/{id}/{padre}")]
        public IActionResult getTramiteServicioId(int id, int padre)
        {
            ElementoSubcategoriaAM objeto = administracionBO.ElementoSubcategoriaTramisteServicioId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpGet("PortalTransversal/{id}/{padre}")]
        public IActionResult getPortalTransversalId(int id, int padre)
        {
            ElementoSubcategoriaAM objeto = administracionBO.ElementoSubcategoriaPortalTransversalId(id, padre);

            if (objeto != null)
            {
                return new JsonResult(objeto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ElementoSubcategoriaAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto Nulo");
                }
                return Ok(this.administracionBO.AgregarElementoSubcategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpPost("VinculadasVentanillaUnica")]
        public IActionResult getVinculadasVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasVentanillaUnicaSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasVentanillaUnica/{id}")]
        public IActionResult getVinculadasVentanillaUnica(int id)
        {
            return new JsonResult(administracionBO.VinculadasVentanillaUnicaSubcategoria(id));
        }

        /*[HttpPost("VincularVentanillaUnica")]
        public IActionResult getVincularVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularVentanillaUnicaSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd));
        }*/

        [HttpPost("VincularVentanillaUnica")]
        public IActionResult getVincularVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularVentanillaUnicaSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularVentanillaUnica/{id}")]
        public IActionResult getVincularVentanillaUnica(int id)
        {
            return new JsonResult(administracionBO.VinculadasVentanillaUnicaSubcategoria(id));
        }

        [HttpGet("Vincular/VentanillaUnica/Total/{id}")]
        public IActionResult GetVincularVentanillaUnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularVentanillaUnicaSubcategoriaTotal(id));
        }

        [HttpGet("Vincular/VentanillaUnica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularSedeElectrocnicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularVentanillaUnicaSubcategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/VentanillaUnica/Total/{id}")]
        public IActionResult GetVinculadasVentanillaUnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasVentanillaUnicaSubcategoriaTotal(id));
        }

        [HttpGet("Vinculadas/VentanillaUnica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasSedeElectrocnicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasVentanillaUnicaSubcategoriaTotal(id, tipo, filtro));
        }

        
        [HttpPost("TodosElementos")]
        public IActionResult GetTodosElementos(PaginateVincular objeto)
        {
            return new JsonResult(this.administracionBO.TodoSubcategorias(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd));
        }

        [HttpGet("TodosElementos/{id}")]
        public IActionResult GetTodosElementos(int id)
        {
            return new JsonResult(this.administracionBO.TodoSubcategorias(id));
        }

        [HttpGet("TodosElementos/Total/{id}")]
        public IActionResult GetTodosElementosTotal(int id)
        {
            return new JsonResult(this.administracionBO.TodoTotalSubcategorias(id));
        }

        [HttpPost("VinculadasSedeElectronica")]
        public IActionResult getVinculadasSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasSedeElectronicaSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasSedeElectronica/{id}")]
        public IActionResult getVinculadasSedeElectronica(int id)
        {
            return new JsonResult(administracionBO.VinculadasSedeElectronicaSubcategoria(id));
        }

        [HttpPost("VincularSedeElectronica")]
        public IActionResult getVincularSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularSedeElectronicaSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularSedeElectronica/{id}")]
        public IActionResult getVincularSedeElectronica(int id)
        {
            return new JsonResult(administracionBO.VincularSedeElectronicaSubcategoria(id));
        }

        [HttpGet("Vincular/SedeElectronica/Total/{id}")]
        public IActionResult GetVincularSedeElectronicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularSedeElectronicaSubcategoriaTotal(id));
        }

        [HttpGet("Vincular/SedeElectronica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularSedeElectronicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularSedeElectronicaSubcategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/SedeElectronica/Total/{id}")]
        public IActionResult GetVinculadasSedeElectronicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasSedeElectronicaSubcategoriaTotal(id));
        }

        [HttpGet("Vinculadas/SedeElectronica/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasSedeElectronicaTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasSedeElectronicaSubcategoriaTotal(id, tipo, filtro));
        }

        [HttpPost("VinculadasTramiteServicio")]
        public IActionResult getVinculadasTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasTramiteServicioSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasTramiteServicio/{id}")]
        public IActionResult getVinculadasTramiteServicio(int id)
        {
            return new JsonResult(administracionBO.VinculadasTramiteServicioSubcategoria(id));
        }

        [HttpPost("VincularTramiteServicio")]
        public IActionResult getVincularTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularTramiteServicioSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularTramiteServicio/{id}")]
        public IActionResult getVincularTramiteServicio(int id)
        {
            return new JsonResult(administracionBO.VincularTramiteServicioSubcategoria(id));
        }

        [HttpGet("Vincular/TramiteServicio/Total/{id}")]
        public IActionResult GetVincularTramiteServicioTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularTramiteServicioSubcategoriaTotal(id));
        }

        [HttpGet("Vincular/TramiteServicio/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularTramiteServicioTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularTramiteServicioSubcategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/TramiteServicio/Total/{id}")]
        public IActionResult GetVinculadasTramiteServicioTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasTramiteServicioSubcategoriaTotal(id));
        }

        [HttpGet("Vinculadas/TramiteServicio/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasTramiteServicioTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasTramiteServicioSubcategoriaTotal(id, tipo, filtro));
        }

        [HttpPost("VinculadasPortalTransversal")]
        public IActionResult getVinculadasPortalTransversal(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasPortalTransversalSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VinculadasPortalTransversal/{id}")]
        public IActionResult getVinculadasPortalTransversal(int id)
        {
            return new JsonResult(administracionBO.VinculadasPortalTransversalSubcategoria(id));
        }

        [HttpPost("VincularPortalTransversal")]
        public IActionResult getVincularPortalTransversal(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularPortalTransversalSubcategoria(objeto.idParametro, objeto.page, objeto.size, objeto.orden, objeto.ascd, objeto.tipo, objeto.filtro));
        }

        [HttpGet("VincularPortalTransversal/{id}")]
        public IActionResult getVincularPortalTransversal(int id)
        {
            return new JsonResult(administracionBO.VincularPortalTransversalSubcategoria(id));
        }

        [HttpGet("Vincular/PortalTransversal/Total/{id}")]
        public IActionResult GetVincularPortalTransversalTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularPortalTransversalSubcategoriaTotal(id));
        }

        [HttpGet("Vinculadas/PortalTransversal/Total/{id}")]
        public IActionResult GetVinculadasPortalTransversalTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasPortalTransversalSubcategoriaTotal(id));
        }

        [HttpGet("Vincular/PortalTransversal/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVincularPortalTransversalTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VincularPortalTransversalSubcategoriaTotal(id, tipo, filtro));
        }

        [HttpGet("Vinculadas/PortalTransversal/Total/{id}/{tipo}/{filtro}")]
        public IActionResult GetVinculadasPortalTransversalTotal(int id, int tipo, string filtro)
        {
            return new JsonResult(this.administracionBO.VinculadasPortalTransversalSubcategoriaTotal(id, tipo, filtro));
        }

        [HttpPost("VinculadasRecurso")]
        public IActionResult getVinculadasRecurso(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasRecursoSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularRecurso")]
        public IActionResult getVincularRecurso(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularRecursoSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpGet("Vincular/Recurso/Total/{id}")]
        public IActionResult GetVincularRecursoTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularRecursoSubcategoriaTotal(id));
        }

        [HttpGet("Vinculadas/Recurso/Total/{id}")]
        public IActionResult GetVinculadasRecursoTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasRecursoSubcategoriaTotal(id));
        }
        
    }
}
