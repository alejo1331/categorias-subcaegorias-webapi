using Categorias.Domain.CategoriasDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.CategoriasDomain.IRepositories
{
    public interface ITramiteCategoriaRepository
    {
        List<TramiteCategoriaEntity> ObtenerListadoCategoriaTramite(Expression<Func<TramiteCategoriaEntity, bool>> predicado);
    }
}
