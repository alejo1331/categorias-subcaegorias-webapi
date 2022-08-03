using Categorias.Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceVncCategoriaRecurso<VncCategoriaRecurso>
    {
        IList<VncCategoriaRecurso> All();
        void Add(VncCategoriaRecurso objeto);
        VncCategoriaRecurso GetId(int id);
        VncCategoriaRecurso GetIdPadre(int id, int padre);
        long getTotalId(int id);
        void Estado(int id);
    }
}