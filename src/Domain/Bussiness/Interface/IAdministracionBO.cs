using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Domain.Categorias.AplicationModel;

using Microsoft.AspNetCore.Mvc;


namespace Domain.Bussiness.Interface
{
    public interface IAdministracionBO
    {
        // Principales

        //Estado
        IList<EstadoAM> All();
        EstadoAM AddEstado(EstadoAM objeto);
        EstadoAM getIdEstado(int id);

        //TipoCategoria
        IList<TipoCategoriaAM> AllTiposCtg();
        TipoCategoriaAM Add(TipoCategoriaAM objeto);
        TipoCategoriaAM getTipoCtgId(int id);
        TipoCategoriaAM ActualizarTipoCategoria(TipoCategoriaAM objeto);
        IList<TipoCategoriaAM> SearchTiposCtg(string data);
        TipoCategoriaAM CambioEstadoTipoCategoria(int id);
        bool ExisteTipoCategoria(string data);
        long CountOrdenTipoCtg(int orden);
        long ObtenerTotalTipoCategoria(Expression<Func<TipoCategoriaAM, bool>> predicate);
        IList<TipoCategoriaAM> ObtenerTipoCategoria(Expression<Func<TipoCategoriaAM, bool>> predicate, int page, int size, Expression<Func<TipoCategoriaAM, object>> selector, bool descending);

        //Categoria
        IList<CategoriaAM> AllCategorias();
        long CountOrdenCtg(int orden);
        IList<CategoriaAM> ActivasCategorias();
        CategoriaAM Add(CategoriaAM objeto);
        CategoriaAM GetCategoria(int id);
        TipoCategoriaAM ObtenerCategoriaTipoCtg(int id);
        CategoriaAM ActualizarCategoria(CategoriaAM objeto);
        IList<CategoriaAM> SearchCategorias(string data);
        IList<CategoriaAM> SonsTipoCategoria(int id);
        CategoriaAM CambioEstadoCategoria(int id);
        IList<string> AgruparTiposCtg();
        bool ExisteCategoria(string data);
        long ObtenerTotalCategoria(Expression<Func<CategoriaAM, bool>> predicate);
        ICollection<CategoriaAM> ObtenerCategoria(Expression<Func<CategoriaAM, bool>> predicate, int page, int size, Expression<Func<CategoriaAM, object>> selector, bool descending);

        //Subcategoria
        IList<SubcategoriaAM> TodosSubcategoria();
        long CountOrdenSbtg(int orden);
        SubcategoriaAM AgregarSubcategoria(SubcategoriaAM objeto);
        SubcategoriaAM GetSubCategoria(int id);
        CategoriaAM GetCategoriaSubcatgoria(int id);
        SubcategoriaAM ActualizarSubCategoria(SubcategoriaAM objeto);
        IList<SubcategoriaAM> SearchSubcategoria(string data);
        IList<SubcategoriaAM> SonsCategoria(int id);
        SubcategoriaAM CambioEstadoSubcategoria(int id);
        IList<string> AgruparCtg();
        bool ExisteSubcategoria(string data);
        long ObtenerTotalSubcategoria(Expression<Func<SubcategoriaAM, bool>> predicate);
        ICollection<SubcategoriaAM> ObtenerSubcategoria(Expression<Func<SubcategoriaAM, bool>> predicate, int page, int size, Expression<Func<SubcategoriaAM, object>> selector, bool descending);

        //Tercer Nivel
        long CountOrdenTercerNivel(int orden);
        bool ExisteTercerNivel(string data);
        IList<TercerNivelAM> TodosTercerNivel();
        TercerNivelAM AgregarTercerNivel(TercerNivelAM objeto);
        TercerNivelAM ObtenerTercerNivel(int id);
        SubcategoriaAM GetSubcategoriaTercerNvl(int id);
        TercerNivelAM ActualizarTercerNivel(TercerNivelAM objeto);
        IList<TercerNivelAM> SearchTercerNivel(string data);
        IList<TercerNivelAM> SonsSubcategoria(int id);
        TercerNivelAM CambioEstadoTercerNivel(int id);
        IList<string> AgruparScgtTCr();
        long ObtenerTotalTercerNivel(Expression<Func<TercerNivelAM, bool>> predicate);
        ICollection<TercerNivelAM> ObtenerTercerNivel(Expression<Func<TercerNivelAM, bool>> predicate, int page, int size, Expression<Func<TercerNivelAM, object>> selector, bool descending);


        //Tipo Recurso
        IList<TipoRecursoAM> TodosTipoRecurso();
        TipoRecursoAM AgregarTipoRecurso(TipoRecursoAM objeto);
        TipoRecursoAM ObtenerTipoRecurso(int id);

        //Recurso
        IList<RecursoAM> TodosRecurso();
        RecursoAM AgregarRecurso(RecursoAM objeto);
        RecursoAM ObtenerRecurso(int id);
        RecursoAM ActualizarRecurso(RecursoAM objeto);
        long ObtenerTotalRecurso(Expression<Func<RecursoAM, bool>> predicate);
        ICollection<RecursoAM> ObtenerRecurso(Expression<Func<RecursoAM, bool>> predicate, int page, int size, Expression<Func<RecursoAM, object>> selector, bool descending);

        //Tipo Paramtero
        IList<TipoParametroAM> TodosTipoParamtero();
        TipoParametroAM AgregarTipoParametro(TipoParametroAM objeto);
        TipoParametroAM ObtenerTipoParametro(int id);
        TipoParametroAM ActualizarTipoParametro(TipoParametroAM objeto);


        //Vinculaciones
        //Tipo categoria ---- Categoria
        IList<VncCategoriaTipoCtgAM> TodosVncCategoriaTipoCtg();
        VncCategoriaTipoCtgAM AgregarVncCategoriaTipoCtg(VncCategoriaTipoCtgAM objeto);
        VncCategoriaTipoCtgAM ObtenerVncCategoriaTipoCtg(int id);
        IList<CategoriaAM> TodosVncCategorias(int id, int page, int size, int orden, bool ascd);
        IList<CategoriaAM> TodosVncCategoriasActivas(int id, int page, int size, int orden, bool ascd);
        IList<CategoriaAM> TodosVncCategoriasInactivas(int id, int page, int size, int orden, bool ascd);
        VncCategoriaTipoCtgAM DesvncCategoriaTipoCtg(int idpadre, int idhijo);
        void DesvncCategoriaTipo(DvcCategoriaTipoCtg objeto);
        void VincularCategoriaTipo(DvcCategoriaTipoCtg objeto);
        IList<CategoriaAM> VincularCategorias(int id, int page, int size);
        IList<CategoriaAM> TodosVncCategorias(int id);
        long VincularCategoriasTotal(int id);
        long DesvincularCategoriasTotal(int id);
        long DesvincularCategoriasTotalActivas(int id);
        long DesvincularCategoriasTotalInactivas(int id);



        //Categoria ----- Subcategoria
        IList<VncSubcategoriaCategoriaAM> TodosVncCategoriaSubcategoria();
        VncSubcategoriaCategoriaAM AgregarVncCategoriaSubcategoria(VncSubcategoriaCategoriaAM objeto);
        VncSubcategoriaCategoriaAM ObtenerVncCategoriaSubcategoria(int id);
        IList<SubcategoriaAM> TodosVncSubcategoria(int id);
        VncSubcategoriaCategoriaAM DesvncSubcategoriasCategoria(int idpadre, int idhijo);
        void VincularSubcategoriasCategoria(DvcSubcategoriaCategoria objeto);
        void DesvncSubcategoriasCategoria(DvcSubcategoriaCategoria objeto);
        IList<SubcategoriaAM> VinculadasSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<SubcategoriaAM> VinculadasSubcategoriaActivas(int id, int page, int size, int orden, bool ascd);
        IList<SubcategoriaAM> VinculadasSubcategoriaInactivas(int id, int page, int size, int orden, bool ascd);
        IList<SubcategoriaAM> VinculadasSubcategoria(int id);
        IList<SubcategoriaAM> VincularSubcategoria(int id);
        IList<SubcategoriaAM> VincularSubcategoria(int id, int page, int size);
        long VinculadasSubcategoriasTotal(int id);
        long VinculadasSubcategoriasTotalActivas(int id);
        long VinculadasSubcategoriasTotalInactivas(int id);
        long VincularSubcategoriasTotal(int id);


        //Subcategoria ---- Tercer Nivel
        IList<VncTercerNvlSubcategoriaAM> TodosVncTercerNvlSubcategoria();
        VncTercerNvlSubcategoriaAM AgregarVncTercerNvlSubcategoria(VncTercerNvlSubcategoriaAM objeto);
        VncTercerNvlSubcategoriaAM ObtenerVncTercerNvlSubcategoria(int id);
        IList<TercerNivelAM> TodosVncTercerNivel(int id);
        VncTercerNvlSubcategoriaAM DesvncTercerNvlSubcategoria(int idpadre, int idhijo);
        void DesvncTercerNvlSbc(DvcTercerNivelSct objeto);
        void VincularTercerNvlSbc(DvcTercerNivelSct objeto);
        IList<TercerNivelAM> VinculadasTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivelAM> VinculadasTercerNivelActivas(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivelAM> VinculadasTercerNivelInactivas(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivelAM> VinculadasTercerNivel(int id);
        long VinculadasTercerNivelTotal(int id);
        long VinculadasTercerNivelTotalActivas(int id);
        long VinculadasTercerNivelTotalInactivas(int id);
        IList<TercerNivelAM> VincularTercerNivel(int id, int page, int size);
        long VincularTercerNivelTotal(int id);

        //Tipo Categoria ---- Recurso
        IList<VncTipoCtgRecursoAM> TodosVncTipoCtgRecurso();
        VncTipoCtgRecursoAM AgregarVncTipoCtgRecurso(VncTipoCtgRecursoAM objeto);
        VncTipoCtgRecursoAM ObtenerVncTipoCtgRecurso(int id);


        //Categoria ---- Recurso
        IList<VncCategoriaRecursoAM> TodosVncCategoriaRecurso();
        VncCategoriaRecursoAM AgregarVncCategoriaRecurso(VncCategoriaRecursoAM objeto);
        VncCategoriaRecursoAM ObtenerVncCategoriaRecurso(int id);

        //Subcategoria ---- Recurso
        IList<VncSubcategoriaRecursoAM> TodosVncSubcategoriaRecurso();
        VncSubcategoriaRecursoAM AgregarVncSubcategoriaRecurso(VncSubcategoriaRecursoAM objeto);
        VncSubcategoriaRecursoAM ObtenerVncSubcategoriaRecurso(int id);

        //Tercer Nivel ---- Recurso
        IList<VncTercerNvlRecursoAM> TodosVncTercerNvlRecurso();
        VncTercerNvlRecursoAM AgregarVncTercerNvlRecurso(VncTercerNvlRecursoAM objeto);
        VncTercerNvlRecursoAM ObtenerVncTercerNvlRecurso(int id);


        //Elemento 
        //PPT
        IList<PPTAM> TodasPPT();
        PPTAM PPTId(int id);

        //TramiteServicio
        IList<TramiteServicioAM> TodasTramiteServicio();
        TramiteServicioAM TramiteServicioId(string id);

        //Ventanilla Unica
        IList<VentanillaUnicaAM> TodasVentanillaUnica();
        VentanillaUnicaAM VentanillaUnicaId(int id);

        //Sede electronica
        IList<SedeElectronicaAM> TodasSedeElectronica();
        SedeElectronicaAM SedeElectronicaId(int id);

        //Tipo Elemento
        IList<TipoElementoAM> TodasTipoElemento();
        TipoElementoAM TipoElementoId(int id);

        //Elemento Categoria
        ElementoCategoriaAM ActualizarElementoCategoria(ElementoCategoriaAM objeto);
        IList<ElementoCategoriaAM> TodasElementoCategoria();
        ElementoCategoriaAM ElementoCategoriaId(int id);
        ElementoCategoriaAM ElementoCategoriaSedeElectronicaId(int id);
        ElementoCategoriaAM ElementoCategoriaVentanillaUnicaId(int id);
        ElementoCategoriaAM ElementoCategoriaTramisteServicioId(int id);
        ElementoCategoriaAM ElementoCategoriaPortalTransversalId(int id);
        ElementoCategoriaAM AgregarElementoCategoria(ElementoCategoriaAM objeto);
        IList<PPTAM> VinculadasPPT(int id, int page, int size);
        IList<PPTAM> VincularPPT(int id, int page, int size);
        IList<SedeElectronicaAM> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd);
        IList<SedeElectronicaAM> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd);
        IList<SedeElectronicaAM> VinculadasSedeElectronica(int id);
        IList<SedeElectronicaAM> VincularSedeElectronica(int id);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd);
        IList<VentanillaUnicaAM> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnica(int id);
        IList<VentanillaUnicaAM> VincularVentanillaUnica(int id);
        IList<TramiteServicioAM> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd);
        IList<TramiteServicioAM> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd);
        IList<TramiteServicioAM> VinculadasTramiteServicio(int id);
        IList<TramiteServicioAM> VincularTramiteServicio(int id);
        IList<PortalTransversalAM> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd);
        IList<PortalTransversalAM> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd);
        IList<PortalTransversalAM> VincularPortalTransversal(int id);
        IList<PortalTransversalAM> VinculadasPortalTransversal(int id);
        IList<RecursoAM> VincularRecurso(int id, int page, int size);
        IList<RecursoAM> VinculadasRecurso(int id, int page, int size);
        long VincularSedeElectronicaCategoriaTotal(int id);
        long VinculadasSedeElectronicaCategoriaTotal(int id);
        long VincularVentanillaUnicaCategoriaTotal(int id);
        long VinculadasVentanillaUnicaCategoriaTotal(int id);
        long VincularTramiteServicioCategoriaTotal(int id);
        long VinculadasTramiteServicioCategoriaTotal(int id);
        long VincularPortalTransversalCategoriaTotal(int id);
        long VinculadasPortalTransversalCategoriaTotal(int id);
        long VincularRecursoCategoriaTotal(int id);
        long VinculadasRecursoCategoriaTotal(int id);

        //Elemento Subcategoria
        ElementoSubcategoriaAM ElementoSubcategoriaSedeElectronicaId(int id);
        ElementoSubcategoriaAM ElementoSubcategoriaVentanillaUnicaId(int id);
        ElementoSubcategoriaAM ElementoSubcategoriaTramisteServicioId(int id);
        ElementoSubcategoriaAM ElementoSubcategoriaPortalTransversalId(int id);
        ElementoSubcategoriaAM ActualizarElementoSubcategoria(ElementoSubcategoriaAM objeto);
        IList<ElementoSubcategoriaAM> TodasElementoSubcategoria();
        ElementoSubcategoriaAM ElementoSubcategoriaId(int id);
        ElementoSubcategoriaAM AgregarElementoSubcategoria(ElementoSubcategoriaAM objeto);
        IList<SedeElectronicaAM> VincularSedeElectronicaSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<SedeElectronicaAM> VincularSedeElectronicaSubcategoria(int id);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaSubcategoria(int id);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<VentanillaUnicaAM> VincularVentanillaUnicaSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaSubcategoria(int id);
        IList<VentanillaUnicaAM> VincularVentanillaUnicaSubcategoria(int id);
        IList<TramiteServicioAM> VincularTramiteServicioSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<TramiteServicioAM> VinculadasTramiteServicioSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<TramiteServicioAM> VincularTramiteServicioSubcategoria(int id);
        IList<TramiteServicioAM> VinculadasTramiteServicioSubcategoria(int id);
        IList<PortalTransversalAM> VincularPortalTransversalSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<PortalTransversalAM> VinculadasPortalTransversalSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<PortalTransversalAM> VincularPortalTransversalSubcategoria(int id);
        IList<PortalTransversalAM> VinculadasPortalTransversalSubcategoria(int id);
        IList<RecursoAM> VincularRecursoSubcategoria(int id, int page, int size);
        IList<RecursoAM> VinculadasRecursoSubcategoria(int id, int page, int size);
        long VincularSedeElectronicaSubcategoriaTotal(int id);
        long VinculadasSedeElectronicaSubcategoriaTotal(int id);
        long VincularVentanillaUnicaSubcategoriaTotal(int id);
        long VinculadasVentanillaUnicaSubcategoriaTotal(int id);
        long VincularTramiteServicioSubcategoriaTotal(int id);
        long VinculadasTramiteServicioSubcategoriaTotal(int id);
        long VincularPortalTransversalSubcategoriaTotal(int id);
        long VinculadasPortalTransversalSubcategoriaTotal(int id);
        long VincularRecursoSubcategoriaTotal(int id);
        long VinculadasRecursoSubcategoriaTotal(int id);


        //Elemento Tercer Nivel
        ElementoTercerNivelAM ElementoTercerNivelSedeElectronicaId(int id);
        ElementoTercerNivelAM ElementoTercerNivelVentanillaUnicaId(int id);
        ElementoTercerNivelAM ElementoTercerNivelTramisteServicioId(int id);
        ElementoTercerNivelAM ElementoTercerNivelPortalTransversalId(int id);
        ElementoTercerNivelAM ActualizarElementoTercerNivel(ElementoTercerNivelAM objeto);
        IList<ElementoTercerNivelAM> TodasElementoTercerNivel();
        ElementoTercerNivelAM ElementoTercerNivelId(int id);
        ElementoTercerNivelAM AgregarElementoTercerNivel(ElementoTercerNivelAM objeto);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<VentanillaUnicaAM> VincularVentanillaUnicaTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaTercerNivel(int id);
        IList<VentanillaUnicaAM> VincularVentanillaUnicaTercerNivel(int id);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<SedeElectronicaAM> VincularSedeElectronicaTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaTercerNivel(int id);
        IList<SedeElectronicaAM> VincularSedeElectronicaTercerNivel(int id);

        IList<TramiteServicioAM> VincularTramiteServicioTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<TramiteServicioAM> VinculadasTramiteServicioTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<TramiteServicioAM> VincularTramiteServicioTercerNivel(int id);
        IList<TramiteServicioAM> VinculadasTramiteServicioTercerNivel(int id);
        IList<PortalTransversalAM> VincularPortalTransversalTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<PortalTransversalAM> VinculadasPortalTransversalTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<PortalTransversalAM> VincularPortalTransversalTercerNivel(int id);
        IList<PortalTransversalAM> VinculadasPortalTransversalTercerNivel(int id);
        IList<RecursoAM> VincularRecursoTercerNivel(int id, int page, int size);
        IList<RecursoAM> VinculadasRecursoTercerNivel(int id, int page, int size);


        IList<ElementosUnionAM> Todo(int id, int page, int size);
        IList<ElementosUnionAM> Todo(int id);
        IList<ElementosUnionAM> TodoSubcategorias(int id);
        IList<ElementosUnionAM> TodoSubcategorias(int id, int page, int size);
        IList<ElementosUnionAM> TodoTercerNivels(int id);
        IList<ElementosUnionAM> TodoTercerNivels(int id, int page, int size);
        long TodoTotal(int id);
        long TodoTotalSubcategorias(int id);
        long TodoTotalTercerNivels(int id);

        long VincularSedeElectronicaTercerNivelsTotal(int id);
        long VinculadasSedeElectronicaTercerNivelsTotal(int id);

        long VincularVentanillaUnicaTercerNivelsTotal(int id);
        long VinculadasVentanillaUnicaTercerNivelsTotal(int id);
        long VincularTramiteServicioTercerNivelsTotal(int id);
        long VinculadasTramiteServicioTercerNivelsTotal(int id);
        long VincularPortalTransversalTercerNivelsTotal(int id);
        long VinculadasPortalTransversalTercerNivelsTotal(int id);
        long VincularRecursoTercerNivelsTotal(int id);
        long VinculadasRecursoTercerNivelsTotal(int id);



        //Porta Transversal
        IList<PortalTransversalAM> TodasPortalTransversal();
        PortalTransversalAM PortalTransversalId(int id);
    }
}