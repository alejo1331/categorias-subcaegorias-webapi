using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceBitacora<Bitacora>
    {
        IList<Bitacora> All(int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<Bitacora> All();
        long Total(int tipo, string filtro);
        void Add(Bitacora objeto);
        Bitacora GetId(int id);
    }
}