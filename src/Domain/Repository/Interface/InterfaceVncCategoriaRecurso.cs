using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVncCategoriaRecurso<VncCategoriaRecurso>
    {
        IList<VncCategoriaRecurso> All();
        void Add(VncCategoriaRecurso objeto);
        VncCategoriaRecurso GetId(int id);
        long getTotalId(int id);
    }
}