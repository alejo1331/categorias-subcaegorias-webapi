using Categorias.Domain.Models;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceTipoConfiguracion<TipoConfiguracion>
    {
        IList<TipoConfiguracion> All();
        TipoConfiguracion GetId(int id);
        TipoConfiguracion GetSiglaId(string sigla);
    }
}