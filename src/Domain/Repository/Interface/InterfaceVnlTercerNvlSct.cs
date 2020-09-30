using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria>
    {
        IList<VncTercerNvlSubcategoria> All();
        void Add(VncTercerNvlSubcategoria objeto);
        VncTercerNvlSubcategoria GetId(int id);
    }
}