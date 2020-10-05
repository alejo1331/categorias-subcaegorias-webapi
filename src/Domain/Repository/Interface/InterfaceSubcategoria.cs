using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceSubcategoria<Subcategoria>
    {
        IList<Subcategoria> All();
        void Add(Subcategoria objeto);
        Subcategoria GetId(int id);
        Categoria GetCategoria(int id);
        void Update(Subcategoria objeto);
        IList<Subcategoria> Search(string data);
    }
}