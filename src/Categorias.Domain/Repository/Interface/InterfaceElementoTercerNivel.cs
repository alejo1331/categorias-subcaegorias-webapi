using Categorias.Domain.Models;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceElementoTercerNivel<ElementoTercerNivel>
    {
        void update(int id);
        IList<ElementoTercerNivel> All();
        ElementoTercerNivel GetId(int id);
        ElementoTercerNivel GetSedeElectronicaId(int id, int padre);
        ElementoTercerNivel GetVentanillaUnicaId(int id, int padre);
        ElementoTercerNivel GetTramiteServicioId(string id, int padre);
        ElementoTercerNivel GetPortalTransversalId(int id, int padre);
        void Add(ElementoTercerNivel objeto);
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
        IList<Recurso> VinculadasRecurso(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<Recurso> VincularRecurso(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ElementosUnion> TodosElementos(int id);
        IList<ElementosUnion> TodosElementos(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<string> AgruparTipoElemento(int id);
        IList<string> AgruparTipoRecursovinculadas(int id);
        IList<string> AgruparTipoRecursovincular(int id);
        long totalTodos(int id, int tipo, string filtro);
        long VincularSedeElectronicaTotal(int id);
        long VincularSedeElectronicaTotal(int id, int tipo, string filtro);
        long VinculadasSedeElectronicaTotal(int id, int tipo, string filtro);
        long VinculadasSedeElectronicaTotal(int id);
        long VincularVentanillaUnicaTotal(int id);
        long VincularVentanillaUnicaTotal(int id, int tipo, string filtro);
         long VinculadasVentanillaUnicaTotal(int id, int tipo, string filtro);
        long VinculadasVentanillaUnicaTotal(int id);
        long VincularTramiteServicioTotal(int id);
        long VincularTramiteServicioTotal(int id, int tipo, string filtro);
        long VinculadasTramiteServicioTotal(int id, int tipo, string filtro);
        long VinculadasTramiteServicioTotal(int id);
        long VincularPortalTransversalTotal(int id);
        long VincularPortalTransversalTotal(int id, int tipo, string filtro);
        long VinculadasPortalTransversalTotal(int id, int tipo, string filtro);
        long VinculadasPortalTransversalTotal(int id);
        long VincularRecursoTotal(int id, int tipo, string filtro);
        long VinculadasRecursoTotal(int id, int tipo, string filtro);
    }
}