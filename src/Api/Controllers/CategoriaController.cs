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
    public class CategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public CategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetCategoriaPaginated([FromBody] PaginateHelper paginateHelper)
        {
            JsonResult response = new JsonResult(false);
            var serializer = new ExpressionSerializer(new BinarySerializer());

            var predicateDeserialized = serializer.DeserializeBinary(paginateHelper.predicate);
            var selectorDeserialized = serializer.DeserializeBinary(paginateHelper.selector);
            try
            {

                var tipos = administracionBO.ObtenerCategoria(predicateDeserialized as Expression<Func<CategoriaAM, bool>>, paginateHelper.page, paginateHelper.size, selectorDeserialized as Expression<Func<CategoriaAM, object>>, paginateHelper.descending);
                response = new JsonResult(tipos);
                return response;

            }
            catch (ArgumentException e)
            {
                //TODO: log error
                return response;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetCategoriaTotal([FromBody] PaginateHelper paginateHelper)
        {

            JsonResult response = new JsonResult(false);
            var serializer = new ExpressionSerializer(new BinarySerializer());

            var predicateDeserialized = serializer.DeserializeBinary(paginateHelper.predicate);

            try
            {

                var total = administracionBO.ObtenerTotalCategoria(predicateDeserialized as Expression<Func<CategoriaAM, bool>>);
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
            return new JsonResult(this.administracionBO.AllCategorias());
        }

        [HttpGet("Activas")]
        public IActionResult GetActivas()
        {
            return new JsonResult(this.administracionBO.ActivasCategorias());
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaAM objeto)
        {
            try
            {
                if (objeto == null)
                {
                    return BadRequest("Objeto Nulo");
                }
                return Ok(this.administracionBO.Add(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            CategoriaAM categoria = administracionBO.GetCategoria(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return NotFound();
        }

        [HttpGet("TipoCategoria/{id}")]
        public IActionResult getTipoCategoriaId(int id)
        {
            TipoCategoriaAM tipo = administracionBO.ObtenerCategoriaTipoCtg(id);
            if (tipo != null)
            {
                return new JsonResult(tipo);
            }
            return NotFound();
        }

        [HttpGet("Buscar/{data}")]
        public IActionResult getTipoCategoriaId(string data)
        {
            return new JsonResult(this.administracionBO.SearchCategorias(data));
        }

        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id, [FromBody] CategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarCategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return NoContent();
        }

        [HttpGet("TipoCategoria/Categorias/{idTipoCategoria}")]
        public IActionResult GetSonsTipoCategoria(int idTipoCategoria)
        {
            return new JsonResult(this.administracionBO.SonsTipoCategoria(idTipoCategoria));
        }

        [HttpPut("Estado/{id}")]
        public IActionResult PutCategoria(int id)
        {
            CategoriaAM objeto = this.administracionBO.CambioEstadoCategoria(id);
            return new JsonResult(objeto);
        }

        [HttpGet("Agrupar")]
        public IActionResult GetTipoCategoria()
        {
            return new JsonResult(this.administracionBO.AgruparTiposCtg());
        }

        [HttpGet("Existe/{data}/{padre}")]
        public IActionResult Existe(string data, int padre)
        {
            bool objeto = this.administracionBO.ExisteCategoria(data, padre);
            return new JsonResult(objeto);
        }

        [HttpGet("ContarOden/{orden}")]
        public IActionResult Count(int orden)
        {
            return new JsonResult(this.administracionBO.CountOrdenCtg(orden));
        }
    }
}
