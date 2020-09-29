using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceTercerNivel<TercerNivel>
    {
        IList<TercerNivel> All();
        void Add(TercerNivel objeto);
        TercerNivel GetId(int id);
        Subcategoria GetSubcategoria(int id);
        void Update(TercerNivel objeto);
    }
}