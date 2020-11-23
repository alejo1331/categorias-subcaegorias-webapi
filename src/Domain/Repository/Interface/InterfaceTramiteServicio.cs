using Domain.Models;
using System.Collections.Generic;
using System;


namespace Domain.Repository.Interface
{
    public interface InterfaceTramiteServicio<TramiteServicio>
    {
        IList<TramiteServicio> All();
        TramiteServicio GetId(string id);
        IList<ParametrosUnion> ListaParametros(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ParametrosUnion> ListaParametros(int id);
        IList<TramiteServicio> ListaTramitesServicios(DateTime fehcaIncial, DateTime? fechaFinal, int page, int size, int orden, bool ascd);
        long TotalTramitesServicios(DateTime fehcaIncial, DateTime? fechaFinal);
        long ListaParametrosTotal(int id);
        long ListaParametrosTotal(int id, int tipo, string filtro);
        IList<string> AgruparEstado(int id);
        IList<string> AgruparTipo(int id);
    }
}