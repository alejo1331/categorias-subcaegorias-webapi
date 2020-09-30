using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Repository.Interface
{
    public interface InterfaceTipoCategoria<TipoCategoria>
    {
        IList<TipoCategoria> All();
        void Add(TipoCategoria objeto);
        TipoCategoria GetId(int id);
        void update(TipoCategoria objeto);
    }
}