using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Serialize.Linq.Serializers;
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
    public class TercerNivelController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TercerNivelController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetTercerNivelPaginated([FromBody] PaginateHelper paginateHelper)
        {
            JsonResult response = new JsonResult(false);
            var serializer = new ExpressionSerializer(new BinarySerializer());

            var predicateDeserialized = serializer.DeserializeBinary(paginateHelper.predicate);
            var selectorDeserialized = serializer.DeserializeBinary(paginateHelper.selector);
            try
            {

                var tipos = administracionBO.ObtenerTercerNivel(predicateDeserialized as Expression<Func<TercerNivelAM, bool>>, paginateHelper.page, paginateHelper.size, selectorDeserialized as Expression<Func<TercerNivelAM, object>>, paginateHelper.descending);
                response = new JsonResult(tipos);
                return response;

            }
            catch (ArgumentException)
            {
                //TODO: log error
                return response;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetTercerNivelTotal([FromBody] PaginateHelper paginateHelper)
        {

            JsonResult response = new JsonResult(false);
            var serializer = new ExpressionSerializer(new BinarySerializer());

            var predicateDeserialized = serializer.DeserializeBinary(paginateHelper.predicate);

            try
            {

                var total = administracionBO.ObtenerTotalTercerNivel(predicateDeserialized as Expression<Func<TercerNivelAM, bool>>);
                response = new JsonResult(total);
                return response;

            }
            catch
            {
                //TODO: log error
                return response;
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.administracionBO.TodosTercerNivel());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TercerNivelAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Objeto nulo");
            }
            return new JsonResult(this.administracionBO.AgregarTercerNivel(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            TercerNivelAM tercer = administracionBO.ObtenerTercerNivel(id);
            if (tercer != null)
            {
                return new JsonResult(tercer);
            }
            return NotFound();
        }

        [HttpGet("Subcategoria/{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            SubcategoriaAM categoria = administracionBO.GetSubcategoriaTercerNvl(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return NotFound();
        }

        [HttpGet("Buscar/{data}")]
        public IActionResult getData(string data)
        {
            return new JsonResult(this.administracionBO.SearchTercerNivel(data));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TercerNivelAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarTercerNivel(objeto));

            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            //return NoContent();
        }

        [HttpGet("Subcategoria/TercerNivels/{idSubcategoria}")]
        public IActionResult GetSonsSubcategoria(int idSubcategoria)
        {
            return new JsonResult(this.administracionBO.SonsSubcategoria(idSubcategoria));
        }

        [HttpPut("Estado/{id}")]
        public IActionResult PutTercerNivel(int id)
        {
            TercerNivelAM objeto = this.administracionBO.CambioEstadoTercerNivel(id);
            return new JsonResult(objeto);
        }

        [HttpGet("Agrupar")]
        public IActionResult GetPaddres()
        {
            return new JsonResult(this.administracionBO.AgruparScgtTCr());
        }

        [HttpGet("Existe/{data}/{padre}")]
        public IActionResult Existe(string data, int padre)
        {
            bool objeto = this.administracionBO.ExisteTercerNivel(data, padre);
            return new JsonResult(objeto);
        }

        [HttpGet("ContarOden/{orden}")]
        public IActionResult Count(int orden)
        {
            return new JsonResult(this.administracionBO.CountOrdenTercerNivel(orden));
        }
        
    }
}