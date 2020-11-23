using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVncTercerNvlRecurso<VncTercerNvlRecurso>
    {
        IList<VncTercerNvlRecurso> All();
        void Add(VncTercerNvlRecurso objeto);
        VncTercerNvlRecurso GetId(int id);
    }
}