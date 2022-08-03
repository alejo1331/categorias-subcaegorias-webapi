using Categorias.Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;

namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceTipoRecurso<TipoRecurso>
    {
        IList<TipoRecurso> All();
        void Add(TipoRecurso objeto);
        TipoRecurso GetId(int id);
        TipoRecurso GetSigla(string sigla);
    }
}