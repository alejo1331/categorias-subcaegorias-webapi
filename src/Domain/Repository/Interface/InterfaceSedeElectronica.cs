using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceSedeElectronica<SedeElectronica>
    {
        IList<SedeElectronica> All();
        SedeElectronica GetId(int id);
    }
}