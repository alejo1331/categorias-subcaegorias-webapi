using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfacePPT<PPT>
    {
        IList<PPT> All();
        PPT GetId(int id);
    }
}