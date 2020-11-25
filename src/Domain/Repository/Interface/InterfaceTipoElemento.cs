using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceTipoElemento<TipoElemento>
    {
        IList<TipoElemento> All();
        TipoElemento GetId(int id);
        TipoElemento GetSigla(string sigla);
    }
}