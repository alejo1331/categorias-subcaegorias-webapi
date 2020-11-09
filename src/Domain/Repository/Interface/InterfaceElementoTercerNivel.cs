using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceElementoTercerNivel<ElementoTercerNivel>
    {
        void update(ElementoTercerNivel objeto);
        IList<ElementoTercerNivel> All();
        ElementoTercerNivel GetId(int id);
        ElementoTercerNivel GetSedeElectronicaId(int id);
        ElementoTercerNivel GetVentanillaUnicaId(int id);
        ElementoTercerNivel GetTramiteServicioId(int id);
        ElementoTercerNivel GetPortalTransversalId(int id);
        void Add(ElementoTercerNivel objeto);
        IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd);
        IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd);
        IList<SedeElectronica> VinculadasSedeElectronica(int id);
        IList<SedeElectronica> VincularSedeElectronica(int id);
        IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd);
        IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd);
        IList<VentanillaUnica> VinculadasVentanillaUnica(int id);
        IList<VentanillaUnica> VincularVentanillaUnica(int id);
        IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd);
        IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd);
        IList<TramiteServicio> VinculadasTramiteServicio(int id);
        IList<TramiteServicio> VincularTramiteServicio(int id);
        IList<PortalTransversal> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd);
        IList<PortalTransversal> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd);
        IList<PortalTransversal> VincularPortalTransversal(int id);
        IList<PortalTransversal> VinculadasPortalTransversal(int id);
        IList<Recurso> VinculadasRecurso(int id, int page, int size);
        IList<Recurso> VincularRecurso(int id, int page, int size);
        IList<ElementosUnion> TodosElementos(int id);
        IList<ElementosUnion> TodosElementos(int id, int page, int size);
        long totalTodos(int id);
        long VincularSedeElectronicaTotal(int id);
        long VinculadasSedeElectronicaTotal(int id);
        long VincularVentanillaUnicaTotal(int id);
        long VinculadasVentanillaUnicaTotal(int id);
        long VincularTramiteServicioTotal(int id);
        long VinculadasTramiteServicioTotal(int id);
        long VincularPortalTransversalTotal(int id);
        long VinculadasPortalTransversalTotal(int id);
        long VincularRecursoTotal(int id);
        long VinculadasRecursoTotal(int id);
    }
}