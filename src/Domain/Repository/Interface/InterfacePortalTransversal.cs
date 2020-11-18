using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfacePortalTransversal<PortalTransversal>
    {
        IList<PortalTransversal> All();
        PortalTransversal GetId(int id);
        IList<ParametrosUnion> ListaParametros(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        long ListaParametrosTotal(int id);
        IList<string> AgruparEstado(int id);
        IList<string> AgruparTipo(int id);
    }
}