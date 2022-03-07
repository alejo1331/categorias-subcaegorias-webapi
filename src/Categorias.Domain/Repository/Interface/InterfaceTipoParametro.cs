using Categorias.Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceTipoParametro<TipoParametro>
    {
        IList<TipoParametro> All();
        void Add(TipoParametro objeto);
        TipoParametro GetId(int id);
        TipoParametro GetSigla(string sigla);
        void Update(TipoParametro objeto);
    }
}