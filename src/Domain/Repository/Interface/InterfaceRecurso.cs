using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceRecurso<Recurso>
    {
        IList<Recurso> All();
        void Add(Recurso objeto);
        Recurso GetId(int id);
        void Update(Recurso objeto);
    }
}