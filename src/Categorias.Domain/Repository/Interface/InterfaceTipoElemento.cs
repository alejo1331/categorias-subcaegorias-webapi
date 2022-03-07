using Categorias.Domain.Models;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceTipoElemento<TipoElemento>
    {
        IList<TipoElemento> All();
        TipoElemento GetId(int id);
        TipoElemento GetSigla(string sigla);
    }
}