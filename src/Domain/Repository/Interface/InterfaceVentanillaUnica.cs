using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVentanillaUnica<VentanillaUnica>
    {
        IList<VentanillaUnica> All();
        VentanillaUnica GetId(int id);
    }
}