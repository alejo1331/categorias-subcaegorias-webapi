using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Serialize.Linq.Serializers;
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
    public class TipoCategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public TipoCategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPost("Paginado")]
        public IActionResult GetTipoCategoriaPaginated([FromBody] PaginateHelper paginateHelper)
        {
            JsonResult response = new JsonResult(false);
            var serializer = new ExpressionSerializer(new BinarySerializer());

            var predicateDeserialized = serializer.DeserializeBinary(paginateHelper.predicate);
            var selectorDeserialized = serializer.DeserializeBinary(paginateHelper.selector);
            try
            {

                var tipos = administracionBO.ObtenerTipoCategoria(predicateDeserialized as Expression<Func<TipoCategoriaAM, bool>>, paginateHelper.page, paginateHelper.size, selectorDeserialized as Expression<Func<TipoCategoriaAM, object>>, paginateHelper.descending);
                response = new JsonResult(tipos);
                return response;

            }
            catch (ArgumentException e)
            {
                //TODO: log error
                return response;
            }
        }

        [HttpPost("Total")]
        public IActionResult GetTipoCategoriaTotal([FromBody] PaginateHelper paginateHelper)
        {

            JsonResult response = new JsonResult(false);
            var serializer = new ExpressionSerializer(new BinarySerializer());

            var predicateDeserialized = serializer.DeserializeBinary(paginateHelper.predicate);

            try
            {

                var total = administracionBO.ObtenerTotalTipoCategoria(predicateDeserialized as Expression<Func<TipoCategoriaAM, bool>>);
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
            return new JsonResult(this.administracionBO.AllTiposCtg());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoCategoriaAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto nulo");
                }
                return new JsonResult(this.administracionBO.Add(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {

            TipoCategoriaAM subcategoria = administracionBO.getTipoCtgId(id);
            if (subcategoria != null)
            {
                return new JsonResult(subcategoria);
            }
            return NotFound();
        }

        [HttpGet("Buscar/{data}")]
        public IActionResult getData(string data)
        {
            return new JsonResult(this.administracionBO.SearchTiposCtg(data));
        }

        [HttpPut("{id}")]
        public IActionResult PuttipoCategoria(int id, [FromBody] TipoCategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarTipoCategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }

        [HttpPut("Estado/{id}")]
        public IActionResult PuttipoCategoria(int id)
        {
            TipoCategoriaAM objeto = this.administracionBO.CambioEstadoTipoCategoria(id);
            return new JsonResult(objeto);
        }
    }
}