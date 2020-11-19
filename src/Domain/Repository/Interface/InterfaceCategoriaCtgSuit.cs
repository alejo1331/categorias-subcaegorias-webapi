using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceCategoriaCtgSuit<CategoriaCtgSuit>
    {
        IList<CategoriaCtgSuit> All();
        void Add(CategoriaCtgSuit objeto);
        CategoriaCtgSuit GetId(int id);
    }
}