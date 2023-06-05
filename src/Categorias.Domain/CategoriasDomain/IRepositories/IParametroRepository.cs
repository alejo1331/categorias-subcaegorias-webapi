using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Categorias.Domain.CategoriasDomain.IRepositories
{
    public interface IParametroRepository
    {
        ParametroEntity ObtenerValorParametro(string sigla);
    }
}
