using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceEstado<Estado>
    {
        IList<Estado> All();
        void Add(Estado objeto);
        Estado GetId(int id);
    }
}