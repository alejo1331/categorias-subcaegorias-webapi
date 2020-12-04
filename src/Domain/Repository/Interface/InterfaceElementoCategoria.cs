using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceElementoCategoria<ElementoCategoria>
    {
        void update(int id);
        IList<ElementoCategoria> All();
        ElementoCategoria GetId(int id);
        ElementoCategoria GetSedeElectronicaId(int id, int padre);
        ElementoCategoria GetVentanillaUnicaId(int id, int padre);
        ElementoCategoria GetTramiteServicioId(string id, int padre);
        ElementoCategoria GetPortalTransversalId(int id, int padre);
        void Add(ElementoCategoria objeto);
        IList<PPT> VinculadasPPT(int id, int page, int size);
        IList<PPT> VincularPPT(int id, int page, int size);
        IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronica> VinculadasSedeElectronica(int id);
        IList<SedeElectronica> VincularSedeElectronica(int id);
        IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnica> VinculadasVentanillaUnica(int id);
        IList<VentanillaUnica> VincularVentanillaUnica(int id);
        IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicio> VinculadasTramiteServicio(int id);
        IList<TramiteServicio> VincularTramiteServicio(int id);
        IList<PortalTransversal> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversal> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversal> VincularPortalTransversal(int id);
        IList<PortalTransversal> VinculadasPortalTransversal(int id);
        IList<Recurso> VincularRecurso(int id, int page, int size);
        IList<Recurso> VinculadasRecurso(int id, int page, int size);
        IList<ElementosUnion> TodosElementos(int id, int page, int size, int orden, bool ascd);   
        IList<ElementosUnion> TodosElementos(int id);   
        long totalTodos(int id);
        long VincularSedeElectronicaTotal(int id, int tipo, string filtro);
        long VincularSedeElectronicaTotal(int id);   
        long VinculadasSedeElectronicaTotal(int id);
        long VinculadasSedeElectronicaTotal(int id, int tipo, string filtro);
        long VincularVentanillaUnicaTotal(int id);
        long VincularVentanillaUnicaTotal(int id, int tipo, string filtro);
        long VinculadasVentanillaUnicaTotal(int id);
        long VinculadasVentanillaUnicaTotal(int id, int tipo, string filtro);
        long VincularTramiteServicioTotal(int id);
        long VincularTramiteServicioTotal(int id, int tipo, string filtro);
        long VinculadasTramiteServicioTotal(int id);
        long VinculadasTramiteServicioTotal(int id, int tipo, string filtro);
        long VincularPortalTransversalTotal(int id);
        long VincularPortalTransversalTotal(int id, int tipo, string filtro);
        long VinculadasPortalTransversalTotal(int id, int tipo, string filtro);
        long VinculadasPortalTransversalTotal(int id);
        long VincularRecursoTotal(int id);
        long VinculadasRecursoTotal(int id);
    }
}