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
    public class TramiteCategoriaService
    {
        private readonly ITramiteCategoriaRepository _tramiteCategoriaRepository;

        public TramiteCategoriaService(ITramiteCategoriaRepository tramiteCategoriaRepository)
        {
            this._tramiteCategoriaRepository = tramiteCategoriaRepository;
        }
        public List<TramiteCategoriaEntity> ObtenerListadoCategoriaTramite(Expression<Func<TramiteCategoriaEntity, bool>> predicado)
        {
            try
            {
                return _tramiteCategoriaRepository.ObtenerListadoCategoriaTramite(predicado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
