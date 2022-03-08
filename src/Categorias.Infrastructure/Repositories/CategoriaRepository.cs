using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.CategoriasDomain.IRepositories;
using Categorias.Domain.CategoriasDomain.Models;
using Categorias.Infrastructure.Context;
using Categorias.Infrastructure.Helpers;
using Categorias.Infrastructure.Models;
using Categorias.Infrastructure.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Categorias.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository, IDisposable
    {
        private readonly IMapper _mapper;
        public CategoriaRepository()
        {

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });
            this._mapper = new Mapper(mapConfig);

        }

        public void Dispose() { }

        public List<CategoriaEntity> ObtenerListadoCategorias()
        {
            try
            {
                using (var context = new CategoriasContext())
                {

                    var categorias = context.Categoria.ToList();
                    var listaMapped = _mapper.Map<List<CategoriaEntity>>(categorias);
                    return listaMapped;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<CategoriaEntity> ObtenerListadoCategoriasPaginado(PaginateModelDomain paginateModel)
        {
            try
            {
                using (var context = new CategoriasContext())
                {
                    var predicate = this.ObtenerPredicadoCategoria(paginateModel);
                    var selector = this.ObtenerSelectorCategoria(paginateModel);

                    var categorias = context.Categoria
                                        .Where(predicate)
                                        .OrderBy(selector + (paginateModel.Descending ? " descending" : ""))
                                        .ThenBy(c => c.Orden)
                                        .Skip(paginateModel.pageSize * paginateModel.pageNumber)
                                        .Take(paginateModel.pageSize)
                                        .ToList();

                    var listaMapped = _mapper.Map<List<CategoriaEntity>>(categorias);
                    return listaMapped;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private Expression<Func<Categoria, bool>> ObtenerPredicadoCategoria(PaginateModelDomain model)
        {
            Expression<Func<Categoria, bool>> predicate = e => e.Id != 0;
            Expression<Func<Categoria, bool>> predicateColumn = null;
            model.searchFilter = model.searchFilter == null ? "" : model.searchFilter;

            #region Predicado base

            if (!String.IsNullOrEmpty(model.searchFilter))
            {
                switch (model.searchField)
                {

                    case "Nombre":
                        predicate = e => e.Nombre.ToUpper().Contains(model.searchFilter.ToUpper());
                        break;

                    case "Descripción larga":
                        predicate = e => e.DescripcionLarga.ToUpper().Contains(model.searchFilter.ToUpper());
                        break;

                    case "Descripción corta":
                        predicate = e => e.DescripcionCorta.ToUpper().Contains(model.searchFilter.ToUpper());
                        break;


                    default:
                        predicate = e => e.Nombre.ToUpper().Contains(model.searchFilter.ToUpper())
                                        || e.DescripcionCorta.ToUpper().Contains(model.searchFilter.ToUpper())
                                        || e.DescripcionLarga.ToUpper().Contains(model.searchFilter.ToUpper());
                        break;
                }
            }
            #endregion

            #region Predicado si hay columna parametrica seleccionada

            if (!String.IsNullOrEmpty(model.ColumnValue))
            {
                //switch (model.ColumnValue)
                //{
                //    case "Estado":
                //        Boolean estado = model.ColumnFilter == "Activo" ? true : false;

                //        predicateColumn = e => e.Estado == estado;

                //        break;

                //}

                #region Concatenación de predicados

                predicate = Expression.Lambda<Func<Categoria, bool>>(Expression.AndAlso(
                new SwapVisitor(predicate.Parameters[0], predicateColumn.Parameters[0]).Visit(predicate.Body),
                predicateColumn.Body), predicateColumn.Parameters);

                #endregion

            }

            #endregion



            return predicate;
        }

        private string ObtenerSelectorCategoria(PaginateModelDomain model)
        {
            string selector = model.orden;
            switch (model.orden)
            {
                case "Nombre":
                    selector = "Nombre";
                    break;

                case "Orden":
                    selector = "Orden";
                    break;

                case "Descripción larga":
                    selector = "DescripcionLarga";
                    break;

                case "Descripción corta":
                    selector = "DescripcionCorta";
                    break;


                default:
                    selector = "Orden";
                    break;
            }

            return selector;
        }
    }
}
