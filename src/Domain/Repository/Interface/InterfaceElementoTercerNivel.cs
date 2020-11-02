using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceElementoTercerNivel<ElementoTercerNivel>
    {
        IList<ElementoTercerNivel> All();
        ElementoTercerNivel GetId(int id);
        void Add(ElementoTercerNivel objeto);
        IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size);
        IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size);
        /*IList<PPT> VinculadasPPT(int id, int page, int size);
        IList<PPT> VincularPPT(int id, int page, int size);
        
        IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size);
        
        IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size);
        IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size);
        IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size);*/
        
    }
}