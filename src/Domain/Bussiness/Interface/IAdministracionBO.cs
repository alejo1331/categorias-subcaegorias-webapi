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
        bool ExisteCategoria(string data, int padre);
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
        IList<SubcategoriaAM> SonsCategoriaActivas(int id);
        SubcategoriaAM CambioEstadoSubcategoria(int id);
        IList<string> AgruparCtg();
        bool ExisteSubcategoria(string data, int padre);
        long ObtenerTotalSubcategoria(Expression<Func<SubcategoriaAM, bool>> predicate);
        ICollection<SubcategoriaAM> ObtenerSubcategoria(Expression<Func<SubcategoriaAM, bool>> predicate, int page, int size, Expression<Func<SubcategoriaAM, object>> selector, bool descending);

        //Tercer Nivel
        long CountOrdenTercerNivel(int orden);
        bool ExisteTercerNivel(string data, int padre);
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
        VncCategoriaTipoCtgAM ActualizarVncCategoriaTipoCtg(VncCategoriaTipoCtgAM objeto);
        VncCategoriaTipoCtgAM ObtenerVncCategoriaTipoCtg(int id);
        VncCategoriaTipoCtgAM ObtenerVncCategoriaTipoCtg(int padre, int id);
        IList<CategoriaAM> TodosVncCategorias(int id, int page, int size, int orden, bool ascd);
        IList<CategoriaAM> TodosVncCategoriasVinculadas(int id, int page, int size, int orden, bool ascd);
        IList<CategoriaAM> TodosVncCategoriasActivas(int id, int page, int size, int orden, bool ascd);
        IList<CategoriaAM> TodosVncCategoriasInactivas(int id, int page, int size, int orden, bool ascd);
        VncCategoriaTipoCtgAM DesvncCategoriaTipoCtg(int idpadre, int idhijo);
        void DesvncCategoriaTipo(DvcCategoriaTipoCtg objeto);
        void VincularCategoriaTipo(DvcCategoriaTipoCtg objeto);
        IList<CategoriaAM> VincularCategorias(int id, int page, int size, int orden, bool ascd);
        IList<CategoriaAM> TodosVncCategorias(int id);
        long VincularCategoriasTotal(int id);
        long DesvincularCategoriasTotal(int id);
        long DesvincularCategoriasVinculadasTotal(int id);
        long DesvincularCategoriasTotalActivas(int id);
        long DesvincularCategoriasTotalInactivas(int id);



        //Categoria ----- Subcategoria
        IList<VncSubcategoriaCategoriaAM> TodosVncCategoriaSubcategoria();
        VncSubcategoriaCategoriaAM AgregarVncCategoriaSubcategoria(VncSubcategoriaCategoriaAM objeto);
        VncSubcategoriaCategoriaAM ObtenerVncCategoriaSubcategoria(int id);
        VncSubcategoriaCategoriaAM ActualizarVncCategoriaSubcategoria(VncSubcategoriaCategoriaAM objeto);
        VncSubcategoriaCategoriaAM ObtenerVncCategoriaSubcategoria(int padre, int id);
        IList<SubcategoriaAM> TodosVncSubcategoria(int id);
        VncSubcategoriaCategoriaAM DesvncSubcategoriasCategoria(int idpadre, int idhijo);
        void VincularSubcategoriasCategoria(DvcSubcategoriaCategoria objeto);
        void DesvncSubcategoriasCategoria(DvcSubcategoriaCategoria objeto);
        IList<SubcategoriaAM> VinculadasSubcategoria(int id, int page, int size, int orden, bool ascd);
        IList<SubcategoriaAM> VinculadasSubcategoriaTipoCero(int id, int page, int size, int orden, bool ascd);
        IList<SubcategoriaAM> VinculadasSubcategoriaActivas(int id, int page, int size, int orden, bool ascd);
        IList<SubcategoriaAM> VinculadasSubcategoriaInactivas(int id, int page, int size, int orden, bool ascd);
        IList<SubcategoriaAM> VinculadasSubcategoria(int id);
        IList<SubcategoriaAM> VincularSubcategoria(int id);
        IList<SubcategoriaAM> VincularSubcategoria(int id, int page, int size, int orden, bool ascd);
        long VinculadasSubcategoriasTotal(int id);
        long VinculadasSubcategoriasTipoCeroTotal(int id);
        long VinculadasSubcategoriasTotalActivas(int id);
        long VinculadasSubcategoriasTotalInactivas(int id);
        long VincularSubcategoriasTotal(int id);


        //Subcategoria ---- Tercer Nivel
        IList<VncTercerNvlSubcategoriaAM> TodosVncTercerNvlSubcategoria();
        VncTercerNvlSubcategoriaAM AgregarVncTercerNvlSubcategoria(VncTercerNvlSubcategoriaAM objeto);
        VncTercerNvlSubcategoriaAM ObtenerVncTercerNvlSubcategoria(int id);
        VncTercerNvlSubcategoriaAM ActualizarVncTercerNvlSubcategoria(VncTercerNvlSubcategoriaAM objeto);
        VncTercerNvlSubcategoriaAM ObtenerVncTercerNvlSubcategoria(int padre, int id);
        IList<TercerNivelAM> TodosVncTercerNivel(int id);
        VncTercerNvlSubcategoriaAM DesvncTercerNvlSubcategoria(int idpadre, int idhijo);
        void DesvncTercerNvlSbc(DvcTercerNivelSct objeto);
        void VincularTercerNvlSbc(DvcTercerNivelSct objeto);
        IList<TercerNivelAM> VinculadasTercerNivel(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivelAM> VinculadasTercerNivelTipoCero(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivelAM> VinculadasTercerNivelActivas(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivelAM> VinculadasTercerNivelInactivas(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivelAM> VinculadasTercerNivel(int id);
        long VinculadasTercerNivelTotal(int id);
        long VinculadasTercerNivelTipoCeroTotal(int id);
        long VinculadasTercerNivelTotalActivas(int id);
        long VinculadasTercerNivelTotalInactivas(int id);
        IList<TercerNivelAM> VincularTercerNivel(int id, int page, int size, int orden, bool ascd);
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
        TipoElementoAM TipoElementoSigla(string sigla);

        //Elemento Categoria
        ElementoCategoriaAM ActualizarElementoCategoria(ElementoCategoriaAM objeto);
        IList<ElementoCategoriaAM> TodasElementoCategoria();
        ElementoCategoriaAM ElementoCategoriaId(int id);
        ElementoCategoriaAM ElementoCategoriaSedeElectronicaId(int id, int padre);
        ElementoCategoriaAM ElementoCategoriaVentanillaUnicaId(int id, int padre);
        ElementoCategoriaAM ElementoCategoriaTramisteServicioId(int id, int padre);
        ElementoCategoriaAM ElementoCategoriaPortalTransversalId(int id, int padre);
        ElementoCategoriaAM AgregarElementoCategoria(ElementoCategoriaAM objeto);
        IList<PPTAM> VinculadasPPT(int id, int page, int size);
        IList<PPTAM> VincularPPT(int id, int page, int size);
        IList<SedeElectronicaAM> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronicaAM> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronicaAM> VinculadasSedeElectronica(int id);
        IList<SedeElectronicaAM> VincularSedeElectronica(int id);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnicaAM> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnica(int id);
        IList<VentanillaUnicaAM> VincularVentanillaUnica(int id);
        IList<TramiteServicioAM> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicioAM> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicioAM> VinculadasTramiteServicio(int id);
        IList<TramiteServicioAM> VincularTramiteServicio(int id);
        IList<PortalTransversalAM> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversalAM> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversalAM> VincularPortalTransversal(int id);
        IList<PortalTransversalAM> VinculadasPortalTransversal(int id);
        IList<RecursoAM> VincularRecurso(int id, int page, int size);
        IList<RecursoAM> VinculadasRecurso(int id, int page, int size);
        long VincularSedeElectronicaCategoriaTotal(int id, int tipo, string filtro);
        long VincularSedeElectronicaCategoriaTotal(int id);
        long VinculadasSedeElectronicaCategoriaTotal(int id);
        long VinculadasSedeElectronicaCategoriaTotal(int id, int tipo, string filtro);
        long VincularVentanillaUnicaCategoriaTotal(int id);
        long VincularVentanillaUnicaCategoriaTotal(int id, int tipo, string filtro);
        long VinculadasVentanillaUnicaCategoriaTotal(int id);
        long VinculadasVentanillaUnicaCategoriaTotal(int id, int tipo, string filtro);
        long VincularTramiteServicioCategoriaTotal(int id);
        long VincularTramiteServicioCategoriaTotal(int id, int tipo, string filtro);
        long VinculadasTramiteServicioCategoriaTotal(int id);
        long VinculadasTramiteServicioCategoriaTotal(int id, int tipo, string filtro);
        long VincularPortalTransversalCategoriaTotal(int id);
        long VincularPortalTransversalCategoriaTotal(int id, int tipo, string filtro);
        long VinculadasPortalTransversalCategoriaTotal(int id);
        long VinculadasPortalTransversalCategoriaTotal(int id, int tipo, string filtro);
        long VincularRecursoCategoriaTotal(int id);
        long VinculadasRecursoCategoriaTotal(int id);

        //Elemento Subcategoria
        ElementoSubcategoriaAM ElementoSubcategoriaSedeElectronicaId(int id, int padre);
        ElementoSubcategoriaAM ElementoSubcategoriaVentanillaUnicaId(int id, int padre);
        ElementoSubcategoriaAM ElementoSubcategoriaTramisteServicioId(int id, int padre);
        ElementoSubcategoriaAM ElementoSubcategoriaPortalTransversalId(int id, int padre);
        ElementoSubcategoriaAM ActualizarElementoSubcategoria(ElementoSubcategoriaAM objeto);
        IList<ElementoSubcategoriaAM> TodasElementoSubcategoria();
        ElementoSubcategoriaAM ElementoSubcategoriaId(int id);
        ElementoSubcategoriaAM AgregarElementoSubcategoria(ElementoSubcategoriaAM objeto);
        IList<SedeElectronicaAM> VincularSedeElectronicaSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronicaAM> VincularSedeElectronicaSubcategoria(int id);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaSubcategoria(int id);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnicaAM> VincularVentanillaUnicaSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaSubcategoria(int id);
        IList<VentanillaUnicaAM> VincularVentanillaUnicaSubcategoria(int id);
        IList<TramiteServicioAM> VincularTramiteServicioSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicioAM> VinculadasTramiteServicioSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicioAM> VincularTramiteServicioSubcategoria(int id);
        IList<TramiteServicioAM> VinculadasTramiteServicioSubcategoria(int id);
        IList<PortalTransversalAM> VincularPortalTransversalSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversalAM> VinculadasPortalTransversalSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversalAM> VincularPortalTransversalSubcategoria(int id);
        IList<PortalTransversalAM> VinculadasPortalTransversalSubcategoria(int id);
        IList<RecursoAM> VincularRecursoSubcategoria(int id, int page, int size);
        IList<RecursoAM> VinculadasRecursoSubcategoria(int id, int page, int size);
        long VincularSedeElectronicaSubcategoriaTotal(int id);
        long VincularSedeElectronicaSubcategoriaTotal(int id, int tipo, string filtro);
        long VinculadasSedeElectronicaSubcategoriaTotal(int id);
        long VinculadasSedeElectronicaSubcategoriaTotal(int id, int tipo, string filtro);
        long VincularVentanillaUnicaSubcategoriaTotal(int id);
        long VincularVentanillaUnicaSubcategoriaTotal(int id, int tipo, string filtro);
        long VinculadasVentanillaUnicaSubcategoriaTotal(int id);
        long VinculadasVentanillaUnicaSubcategoriaTotal(int id, int tipo, string filtro);
        long VincularTramiteServicioSubcategoriaTotal(int id);
        long VincularTramiteServicioSubcategoriaTotal(int id, int tipo, string filtro);
        long VinculadasTramiteServicioSubcategoriaTotal(int id);
        long VinculadasTramiteServicioSubcategoriaTotal(int id, int tipo, string filtro);
        long VincularPortalTransversalSubcategoriaTotal(int id);
        long VincularPortalTransversalSubcategoriaTotal(int id, int tipo, string filtrar);
        long VinculadasPortalTransversalSubcategoriaTotal(int id);
        long VinculadasPortalTransversalSubcategoriaTotal(int id, int tipo, string filtro);
        long VincularRecursoSubcategoriaTotal(int id);
        long VinculadasRecursoSubcategoriaTotal(int id);


        //Elemento Tercer Nivel
        ElementoTercerNivelAM ElementoTercerNivelSedeElectronicaId(int id, int padre);
        ElementoTercerNivelAM ElementoTercerNivelVentanillaUnicaId(int id, int padre);
        ElementoTercerNivelAM ElementoTercerNivelTramisteServicioId(int id, int padre);
        ElementoTercerNivelAM ElementoTercerNivelPortalTransversalId(int id, int padre);
        ElementoTercerNivelAM ActualizarElementoTercerNivel(ElementoTercerNivelAM objeto);
        IList<ElementoTercerNivelAM> TodasElementoTercerNivel();
        ElementoTercerNivelAM ElementoTercerNivelId(int id);
        ElementoTercerNivelAM AgregarElementoTercerNivel(ElementoTercerNivelAM objeto);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnicaAM> VincularVentanillaUnicaTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaTercerNivel(int id);
        IList<VentanillaUnicaAM> VincularVentanillaUnicaTercerNivel(int id);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronicaAM> VincularSedeElectronicaTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaTercerNivel(int id);
        IList<SedeElectronicaAM> VincularSedeElectronicaTercerNivel(int id);

        IList<TramiteServicioAM> VincularTramiteServicioTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicioAM> VinculadasTramiteServicioTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicioAM> VincularTramiteServicioTercerNivel(int id);
        IList<TramiteServicioAM> VinculadasTramiteServicioTercerNivel(int id);
        IList<PortalTransversalAM> VincularPortalTransversalTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversalAM> VinculadasPortalTransversalTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<PortalTransversalAM> VincularPortalTransversalTercerNivel(int id);
        IList<PortalTransversalAM> VinculadasPortalTransversalTercerNivel(int id);
        IList<RecursoAM> VincularRecursoTercerNivel(int id, int page, int size);
        IList<RecursoAM> VinculadasRecursoTercerNivel(int id, int page, int size);


        IList<ElementosUnionAM> Todo(int id, int page, int size, int orden, bool ascd);
        IList<ElementosUnionAM> Todo(int id);
        IList<ElementosUnionAM> TodoSubcategorias(int id);
        IList<ElementosUnionAM> TodoSubcategorias(int id, int page, int size, int orden, bool ascd);
        IList<ElementosUnionAM> TodoTercerNivels(int id);
        IList<ElementosUnionAM> TodoTercerNivels(int id, int page, int size, int orden, bool ascd);
        long TodoTotal(int id);
        long TodoTotalSubcategorias(int id);
        long TodoTotalTercerNivels(int id);

        long VincularSedeElectronicaTercerNivelsTotal(int id);
        long VincularSedeElectronicaTercerNivelsTotal(int id, int tipo, string filtro);
        long VinculadasSedeElectronicaTercerNivelsTotal(int id);
        long VinculadasSedeElectronicaTercerNivelsTotal(int id, int tipo, string filtro);

        long VincularVentanillaUnicaTercerNivelsTotal(int id);
        long VincularVentanillaUnicaTercerNivelsTotal(int id, int tipo, string filtro);
        long VinculadasVentanillaUnicaTercerNivelsTotal(int id);
        long VinculadasVentanillaUnicaTercerNivelsTotal(int id, int tipo, string filtro);

        long VincularTramiteServicioTercerNivelsTotal(int id);
        long VincularTramiteServicioTercerNivelsTotal(int id, int tipo, string filtro);
        long VinculadasTramiteServicioTercerNivelsTotal(int id);
        long VinculadasTramiteServicioTercerNivelsTotal(int id, int tipo, string filtro);

        long VincularPortalTransversalTercerNivelsTotal(int id);
        long VincularPortalTransversalTercerNivelsTotal(int id, int tipo, string filtro);
        long VinculadasPortalTransversalTercerNivelsTotal(int id);
        long VinculadasPortalTransversalTercerNivelsTotal(int id, int tipo, string filtro);
        
        long VincularRecursoTercerNivelsTotal(int id);
        long VinculadasRecursoTercerNivelsTotal(int id);



        //Portal Transversal
        IList<PortalTransversalAM> TodasPortalTransversal();
        PortalTransversalAM PortalTransversalId(int id);

        //Sedes Electronicas
        IList<ParametrosUnionAM> TodosParametrosSedesElectronicas(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ParametrosUnionAM> TodosParametrosSedesElectronicas(int id);
        long TodosParametrosSedesElectronicasTotal(int id);
        long TodosParametrosSedesElectronicasTotal(int id, int tipo, string filtro);
        IList<string> AgruparEstadoSedesElectronicas(int id);
        IList<string> AgruparTipoSedesElectronicas(int id);

        //Ventanilla Unica
        IList<ParametrosUnionAM> TodosParametrosVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ParametrosUnionAM> TodosParametrosVentanillaUnica(int id);
        long TodosParametrosVentanillaUnicaTotal(int id);
        long TodosParametrosVentanillaUnicaTotal(int id, int tipo, string filtro);
        IList<string> AgruparEstadoVentanillaUnica(int id);
        IList<string> AgruparTipoVentanillaUnica(int id);

        //Portal Transversal
        IList<ParametrosUnionAM> TodosParametrosPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ParametrosUnionAM> TodosParametrosPortalTransversal(int id);
        long TodosParametrosPortalTransversalTotal(int id);
        long TodosParametrosPortalTransversalTotal(int id, int tipo, string filtro);
        IList<string> AgruparEstadoPortalTransversal(int id); 
        IList<string> AgruparTipoPortalTransversal(int id);
        

        //Tramites y servicios
        IList<ParametrosUnionAM> TodosParametrosTramitesServicios(int id, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<ParametrosUnionAM> TodosParametrosTramitesServicios(int id);
        long TodosParametrosTramitesServiciosTotal(int id);
        long TodosParametrosTramitesServiciosTotal(int id, int tipo, string filtro);
        IList<string> AgruparEstadoTramitesServicios(int id); 
        IList<string> AgruparTipoTramitesServicios(int id);  
        IList<TramiteServicioAM> ListaTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal, int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<TramiteServicioAM> ListaTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal); 
        long TotalTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal, int tipo, string filtro); 

        //Categoria Suit
        IList<CategoriaSUITAM> AllCategoriasSuit();
        CategoriaSUITAM GetCategoriaSuitId(int id);   

        //Vinculo Categoria a Categoria SUIT
        IList<CategoriaCtgSuitAM> AllCategoriaCtgSuit();
        CategoriaCtgSuitAM AddCategoriaCtgSuit(CategoriaCtgSuitAM objeto);
        CategoriaCtgSuitAM GetCategoriaCtgSuitId(int id); 
        CategoriaCtgSuitAM GetCategoriaCtgSuitId(int idCategoria, int idCategoriaSuit); 
        IList<CategoriaCtgSuitAM> AllCategoriaCtgSuitIdCtg(int idCategoria);
        CategoriaCtgSuitAM updateCategoriaCtgSuitAM(CategoriaCtgSuitAM objeto);

        //Vinculo Subcategoria a Categoria SUIT
        IList<SubcategoriaCtgSuitAM> AllSubcategoriaCtgSuit();
        SubcategoriaCtgSuitAM AddSubcategoriaCtgSuit(SubcategoriaCtgSuitAM objeto);
        SubcategoriaCtgSuitAM GetSubcategoriaCtgSuitId(int id); 
        SubcategoriaCtgSuitAM GetSubcategoriaCtgSuitId(int idSubcategoria, int idCategoriaSuit);
        IList<SubcategoriaCtgSuitAM> AllSubcategoriaCtgSuitIdCtg(int idSubcategoria); 
        SubcategoriaCtgSuitAM updateSubcategoriaCtgSuitAM(SubcategoriaCtgSuitAM objeto);


        //Tipo Configuracion
        IList<TipoConfiguracionAM> AllTiposConfiguracion();
        TipoConfiguracionAM GetTipoConfiguracionId(int id);

        //Bitacora
        IList<BitacoraCategoriasAM> AllBitacora(int page, int size, int orden, bool ascd, int tipo, string filtro);
        IList<BitacoraCategoriasAM> AllBitacora();
        long TotalBitacora(int tipo, string filtro);
        BitacoraCategoriasAM AddBitacora(BitacoraCategoriasAM objeto);
        BitacoraCategoriasAM GetBitacoraId(int id);
        
    }
}