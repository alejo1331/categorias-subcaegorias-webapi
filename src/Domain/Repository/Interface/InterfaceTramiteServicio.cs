using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceTramiteServicio<TramiteServicio>
    {
        IList<TramiteServicio> All();
        TramiteServicio GetId(string id);
    }
}