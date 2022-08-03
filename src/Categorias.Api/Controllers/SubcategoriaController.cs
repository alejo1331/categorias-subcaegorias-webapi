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
    public class SubcategoriaController : ControllerBase
    {
        private readonly IAdministracionBO administracionBO;

        public SubcategoriaController(Context context)
        {
            administracionBO = new AdministracionBO(context);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetSubcategoriaPaginated([FromBody] PaginateHelper paginateHelper)
        {
            JsonResult response = new JsonResult(false);
            var serializer = new ExpressionSerializer(new BinarySerializer());

            var predicateDeserialized = serializer.DeserializeBinary(paginateHelper.predicate);
            var selectorDeserialized = serializer.DeserializeBinary(paginateHelper.selector);
            try
            {

                var tipos = administracionBO.ObtenerSubcategoria(predicateDeserialized as Expression<Func<SubcategoriaAM, bool>>, paginateHelper.page, paginateHelper.size, selectorDeserialized as Expression<Func<SubcategoriaAM, object>>, paginateHelper.descending);
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
        public IActionResult GetSubcategoriaTotal([FromBody] PaginateHelper paginateHelper)
        {

            JsonResult response = new JsonResult(false);
            var serializer = new ExpressionSerializer(new BinarySerializer());

            var predicateDeserialized = serializer.DeserializeBinary(paginateHelper.predicate);

            try
            {

                var total = administracionBO.ObtenerTotalSubcategoria(predicateDeserialized as Expression<Func<SubcategoriaAM, bool>>);
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
            return new JsonResult(this.administracionBO.TodosSubcategoria());
        }

        [HttpPost]
        public IActionResult Post([FromBody] SubcategoriaAM objeto)
        {
            if (objeto == null)
            {
                return BadRequest("Objeto es nulo");
            }
            return new JsonResult(this.administracionBO.AgregarSubcategoria(objeto));
        }

        [HttpGet("{id}")]
        public IActionResult getSubcategoriaId(int id)
        {
            SubcategoriaAM subcategoria = administracionBO.GetSubCategoria(id);
            if (subcategoria != null)
            {
                return new JsonResult(subcategoria);
            }
            return NotFound();
        }

        [HttpGet("Categoria/{id}")]
        public IActionResult getTipoCategoriaId(int id)
        {
            CategoriaAM categoria = administracionBO.GetCategoriaSubcatgoria(id);
            if (categoria != null)
            {
                return new JsonResult(categoria);
            }
            return NotFound();
        }

        [HttpGet("Buscar/{data}")]
        public IActionResult getTipoCategoriaId(string data)
        {
            return new JsonResult(this.administracionBO.SearchSubcategoria(data));
        }

        [HttpPut("{id}")]
        public IActionResult PuttipoCategoria(int id, [FromBody] SubcategoriaAM objeto)
        {
            if (id != objeto.id)
            {
                return BadRequest();
            }

            try
            {
                return new JsonResult(this.administracionBO.ActualizarSubCategoria(objeto));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            //return NoContent();
        }

        [HttpGet("Categoria/Subcategorias/{idCategoria}")]
        public IActionResult GetSonsCategoria(int idCategoria)
        {
            return new JsonResult(this.administracionBO.SonsCategoria(idCategoria));
        }

        [HttpGet("Categoria/Subcategorias/Activas/{idCategoria}")]
        public IActionResult GetSonsCategoriaActivas(int idCategoria)
        {
            return new JsonResult(this.administracionBO.SonsCategoriaActivas(idCategoria));
        }

        [HttpPut("Estado/{id}")]
        public IActionResult PutSubcategoria(int id)
        {
            SubcategoriaAM objeto = this.administracionBO.CambioEstadoSubcategoria(id);
            return new JsonResult(objeto);
        }

        [HttpGet("Agrupar")]
        public IActionResult GetCategoria()
        {
            return new JsonResult(this.administracionBO.AgruparCtg());
        }

        [HttpGet("Existe/{data}/{padre}")]
        public IActionResult Existe(string data, int padre)
        {
            bool objeto = this.administracionBO.ExisteSubcategoria(data, padre);
            return new JsonResult(objeto);
        }

        [HttpGet("ContarOden/{orden}")]
        public IActionResult Count(int orden)
        {
            return new JsonResult(this.administracionBO.CountOrdenSbtg(orden));
        }
    }
}