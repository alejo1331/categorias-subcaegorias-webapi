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
            return new JsonResult(administracionBO.VinculadasVentanillaUnicaTercerNivel(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VinculadasSedeElectronica")]
        public IActionResult getVinculadasSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasSedeElectronicaTercerNivel(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("TodosElementos")]
        public IActionResult GetTodosElementos(PaginateVincular objeto)
        {
            return new JsonResult(this.administracionBO.TodoTercerNivels(objeto.idParametro, objeto.page, objeto.size));
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

        /*[HttpPost("VinculadasPPT")]
        public IActionResult getVinculadasPPT(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasPPT(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularPPT")]
        public IActionResult getVincularPPT(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularPPT(objeto.idParametro, objeto.page, objeto.size));
        }
        
        

        [HttpPost("VincularSedeElectronica")]
        public IActionResult getVincularSedeElectronica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularSedeElectronica(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VinculadasVentanillaUnica")]
        public IActionResult getVinculadasVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasVentanillaUnica(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularVentanillaUnica")]
        public IActionResult getVincularVentanillaUnica(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularVentanillaUnica(objeto.idParametro, objeto.page, objeto.size));
        }
        
        [HttpPost("VinculadasTramiteServicio")]
        public IActionResult getVinculadasTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VinculadasTramiteServicio(objeto.idParametro, objeto.page, objeto.size));
        }

        [HttpPost("VincularTramiteServicio")]
        public IActionResult getVincularTramiteServicio(PaginateVincular objeto)
        {
            return new JsonResult(administracionBO.VincularTramiteServicio(objeto.idParametro, objeto.page, objeto.size));
        }*/
    }
}
