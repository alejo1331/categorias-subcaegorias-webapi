using Categorias.Domain.Models;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfacePPT<PPT>
    {
        IList<PPT> All();
        PPT GetId(int id);
    }
}