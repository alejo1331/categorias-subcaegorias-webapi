using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.CategoriasDomain.IRepositories;
using Categorias.Infrastructure.Context;
using Categorias.Infrastructure.Models;
using Categorias.Infrastructure.Profiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Repositories
{
    public class TramiteCategoriaRepository : ITramiteCategoriaRepository, IDisposable
    {
        private readonly IMapper _mapper;
        public TramiteCategoriaRepository()
        {

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });
            this._mapper = new Mapper(mapConfig);

        }

        public void Dispose() { }

        public List<TramiteCategoriaEntity> ObtenerListadoCategoriaTramite(Expression<Func<TramiteCategoriaEntity, bool>> predicado)
        {
            try
            {
                using (var context = new CategoriasContext())
                {
                    var predicadoMapped = _mapper.Map<Expression<Func<TramiteCategoria, bool>>>(predicado);
                    List<TramiteCategoria> categorias = context.TramiteCategoria
                                                        .Include(r => r.TipoElemento)
                                                        .Include(r => r.Categoria)
                                                        .Where(predicadoMapped)
                                                        .ToList();

                    return _mapper.Map<List<TramiteCategoriaEntity>>(categorias);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
