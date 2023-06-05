using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.CategoriasDomain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.CategoriasDomain.Services
{
    public class ParametroService
    {
        private readonly IParametroRepository _parametroRepository;
        public ParametroService(IParametroRepository parametroRepository)
        {
            this._parametroRepository = parametroRepository;
        }

        public ParametroEntity ObtenerValorParametro(string sigla)
        {
            try
            {
                return _parametroRepository.ObtenerValorParametro(sigla);
               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
