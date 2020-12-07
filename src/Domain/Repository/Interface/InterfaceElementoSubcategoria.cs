using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceElementoSubcategoria<ElementoSubcategoria>
    {
        void update(int id);
        IList<ElementoSubcategoria> All();
        ElementoSubcategoria GetId(int id);
        ElementoSubcategoria GetSedeElectronicaId(int id, int padre);
        ElementoSubcategoria GetVentanillaUnicaId(int id, int padre);
        ElementoSubcategoria GetTramiteServicioId(string id, int padre);
        ElementoSubcategoria GetPortalTransversalId(int id, int padre);
        void Add(ElementoSubcategoria objeto);
        IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnica> VinculadasVentanillaUnica(int id);
        IList<VentanillaUnica> VincularVentanillaUnica(int id);
        IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronica> VinculadasSedeElectronica(int id);
        IList<SedeElectronica> VincularSedeElectronica(int id);
        IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicio> VinculadasTramiteServicio(int id);
        IList<TramiteServicio> VincularTramiteServicio(int id);
        IList<PortalTransversal> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversal> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversal> VincularPortalTransversal(int id);
        IList<PortalTransversal> VinculadasPortalTransversal(int id);
        IList<Recurso> VinculadasRecurso(int id, int page, int size);
        IList<Recurso> VincularRecurso(int id, int page, int size);
        IList<ElementosUnion> TodosElementos(int id);
        IList<ElementosUnion> TodosElementos(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<string> AgruparTipoElemento(int id); 
        long totalTodos(int id, int tipo, string filtro);
        long VincularSedeElectronicaTotal(int id);
        long VincularSedeElectronicaTotal(int id, int tipo, string filtro);
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
        long VinculadasPortalTransversalTotal(int id);
        long VinculadasPortalTransversalTotal(int id, int tipo, string filtro);
        long VincularRecursoTotal(int id);
        long VinculadasRecursoTotal(int id);
    }
}