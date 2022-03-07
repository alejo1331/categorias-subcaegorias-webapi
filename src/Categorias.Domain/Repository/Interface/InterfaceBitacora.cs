using Categorias.Domain.Models;
using System.Collections.Generic;
using System;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceBitacora<Bitacora>
    {
        IList<Bitacora> All(int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<Bitacora> All();
        long Total(int tipo, string filtro);
        long Total();
        void Add(Bitacora objeto);
        void Remove(DateTime fechaInicio);
        Bitacora GetId(int id);
        IList<string> AgruparTipoConfiguracion();
        IList<string> AgruparTipoParametro();
    }
}