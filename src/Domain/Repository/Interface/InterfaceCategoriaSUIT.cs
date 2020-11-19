using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceCategoriaSUIT<CategoriaSUIT>
    {
        IList<CategoriaSUIT> All();
        CategoriaSUIT GetId(int id);
    }
}