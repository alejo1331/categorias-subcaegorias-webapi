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
    }
}