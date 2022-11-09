using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.CategoriasDomain.IRepositories;
using Categorias.Domain.Models;
using Categorias.Infrastructure.Context;
using Categorias.Infrastructure.Models;
using Categorias.Infrastructure.Profiles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Repositories
{
    
    public class ParametroRepository : IParametroRepository, IDisposable
    {
        private readonly IMapper _mapper;
        public ParametroRepository()
        {

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });
            this._mapper = new Mapper(mapConfig);

        }

        public void Dispose() { }

        public ParametroEntity ObtenerValorParametro(string sigla)
        {
            try
            {
                using (var context = new ParametrosContext())
                {
                    var parametro = context.Parametro
                                    .Where(c => c.sigla == sigla).First();
                                    
                   
                    Console.WriteLine(context);
                    return _mapper.Map<ParametroEntity>(parametro);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

    }
}
