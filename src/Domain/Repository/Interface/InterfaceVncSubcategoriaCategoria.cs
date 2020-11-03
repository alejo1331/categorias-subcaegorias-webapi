using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria>
    {
        IList<VncSubcategoriaCategoria> All();
        void Add(VncSubcategoriaCategoria objeto);
        VncSubcategoriaCategoria GetId(int id);
        VncSubcategoriaCategoria GetId(int idpadre, int idhijo);
        IList<Subcategoria> getSubcategory(int id);
        void Update(VncSubcategoriaCategoria objeto);
        IList<Subcategoria> Vinculadas(int id, int page, int size);
        IList<Subcategoria> Vinculadas(int id);
        long VinculadasTotal(int id);
    }
}