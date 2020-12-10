using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVncSubcategoriaRecurso<VncSubcategoriaRecurso>
    {
        IList<VncSubcategoriaRecurso> All();
        void Add(VncSubcategoriaRecurso objeto);
        VncSubcategoriaRecurso GetId(int id);
        VncSubcategoriaRecurso GetIdPadre(int id, int padre);
        long GetTotalId(int id);
        void Estado(int id);
    }
}