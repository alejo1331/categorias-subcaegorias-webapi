using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceTipoConfiguracion<TipoConfiguracion>
    {
        IList<TipoConfiguracion> All();
        TipoConfiguracion GetId(int id);
    }
}