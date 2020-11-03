using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfacePortalTransversal<PortalTransversal>
    {
        IList<PortalTransversal> All();
        PortalTransversal GetId(int id);
    }
}