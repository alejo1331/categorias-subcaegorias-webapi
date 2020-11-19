using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceSedeElectronica<SedeElectronica>
    {
        IList<SedeElectronica> All();
        SedeElectronica GetId(int id);
        IList<ParametrosUnion> ListaParametros(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ParametrosUnion> ListaParametros(int id);
        long ListaParametrosTotal(int id);
        IList<string> AgruparEstado(int id);
        IList<string> AgruparTipo(int id);
    }
}