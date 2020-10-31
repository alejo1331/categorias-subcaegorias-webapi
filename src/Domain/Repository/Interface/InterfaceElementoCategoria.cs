using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceElementoCategoria<ElementoCategoria>
    {
        IList<ElementoCategoria> All();
        ElementoCategoria GetId(int id);
        void Add(ElementoCategoria objeto);
        
    }
}