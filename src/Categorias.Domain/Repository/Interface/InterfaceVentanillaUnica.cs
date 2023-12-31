using Categorias.Domain.Models;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceVentanillaUnica<VentanillaUnica>
    {
        IList<VentanillaUnica> All();
        VentanillaUnica GetId(int id);
        IList<ParametrosUnion> ListaParametros(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ParametrosUnion> ListaParametros(int id);
        long ListaParametrosTotal(int id);
        long ListaParametrosTotal(int id, int tipo, string filtro);
        IList<string> AgruparEstado(int id);
        IList<string> AgruparTipo(int id);
    }
}