using Categorias.Domain.Models;
using System.Collections.Generic;
using System;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceTramiteServicio<TramiteServicio>
    {
        IList<TramiteServicio> All();
        TramiteServicio GetId(string id);
        IList<ParametrosUnion> ListaParametros(string id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ParametrosUnion> ListaParametros(string id);
        IList<TramiteServicio> ListaTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicio> ListaTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal);
        IList<TramiteServicio> ListaTramitesServicios(int page, int size, int orden, bool ascd,string filtro, int tipo);
        long TotalTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal, int tipo, string filtro);
        long TotalTramitesServicios(int tipo, string filtro);
        long ListaParametrosTotal(string id);
        long ListaParametrosTotal(string id, int tipo, string filtro);
        IList<string> AgruparEstado(string id);
        IList<string> AgruparTipo(string id);
    }
}