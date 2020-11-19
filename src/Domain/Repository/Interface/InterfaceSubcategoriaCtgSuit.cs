using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit>
    {
        IList<SubcategoriaCtgSuit> All();
        void Add(SubcategoriaCtgSuit objeto);
        SubcategoriaCtgSuit GetId(int id);
    }
}