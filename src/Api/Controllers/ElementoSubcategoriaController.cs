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
            return new JsonResult(administracionBO.VinculadasVentanillaUnicaSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularVentanillaUnica")]
        public IActionResult getVincularVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularVentanillaUnicaSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpGet("Vincular/VentanillaUnica/Total/{id}")]
        public IActionResult GetVincularVentanillaUnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularVentanillaUnicaSubcategoriaTotal(id));
        }

        [HttpGet("Vinculadas/VentanillaUnica/Total/{id}")]
        public IActionResult GetVinculadasVentanillaUnicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasVentanillaUnicaSubcategoriaTotal(id));
        }

        
        [HttpPost("TodosElementos")]
        public IActionResult GetTodosElementos(PaginateVincular objeto)
        {
            return new JsonResult(this.administracionBO.TodoSubcategorias(objeto.idParametro, objeto.page, objeto.size));
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
            return new JsonResult(administracionBO.VinculadasSedeElectronicaSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularSedeElectronica")]
        public IActionResult getVincularSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularSedeElectronicaSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpGet("Vincular/SedeElectronica/Total/{id}")]
        public IActionResult GetVincularSedeElectronicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularSedeElectronicaSubcategoriaTotal(id));
        }

        [HttpGet("Vinculadas/SedeElectronica/Total/{id}")]
        public IActionResult GetVinculadasSedeElectronicaTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasSedeElectronicaSubcategoriaTotal(id));
        }

        [HttpPost("VinculadasTramiteServicio")]
        public IActionResult getVinculadasTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasTramiteServicioSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularTramiteServicio")]
        public IActionResult getVincularTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularTramiteServicioSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpGet("Vincular/TramiteServicio/Total/{id}")]
        public IActionResult GetVincularTramiteServicioTotal(int id)
        {
            return new JsonResult(this.administracionBO.VincularTramiteServicioSubcategoriaTotal(id));
        }

        [HttpGet("Vinculadas/TramiteServicio/Total/{id}")]
        public IActionResult GetVinculadasTramiteServicioTotal(int id)
        {
            return new JsonResult(this.administracionBO.VinculadasTramiteServicioSubcategoriaTotal(id));
        }

        [HttpPost("VinculadasPortalTransversal")]
        public IActionResult getVinculadasPortalTransversal(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasPortalTransversalSubcategoria(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularPortalTransversal")]
        public IActionResult getVincularPortalTransversal(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularPortalTransversalSubcategoria(objeto.idParametro, objeto.page, objeto.size));
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
