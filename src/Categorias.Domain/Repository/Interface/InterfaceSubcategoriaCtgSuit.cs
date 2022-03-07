using Categorias.Domain.Models;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit>
    {
        IList<SubcategoriaCtgSuit> All();
        void Add(SubcategoriaCtgSuit objeto);
        SubcategoriaCtgSuit GetId(int id);
        SubcategoriaCtgSuit GetId(int idSubcategoria, int idCategoriaSuit);
        IList<SubcategoriaCtgSuit> GetSubcategoriasSuit(int idSubcategoria);
        void update(SubcategoriaCtgSuit objeto);
    }
}