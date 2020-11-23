using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVncTipoCtgRecurso<VncTipoCtgRecurso>
    {
        IList<VncTipoCtgRecurso> All();
        void Add(VncTipoCtgRecurso objeto);
        VncTipoCtgRecurso GetId(int id);
    }
}