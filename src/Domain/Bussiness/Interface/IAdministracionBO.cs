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
        IList<CategoriaAM> TodosVncCategorias(int id, int page, int size);
        VncCategoriaTipoCtgAM DesvncCategoriaTipoCtg(int idpadre, int idhijo);
        void DesvncCategoriaTipo(DvcCategoriaTipoCtg objeto);
        void VincularCategoriaTipo(DvcCategoriaTipoCtg objeto);
        IList<CategoriaAM> VincularCategorias(int id, int page, int size);
        long VincularCategoriasTotal(int id);
        long DesvincularCategoriasTotal(int id);



        //Categoria ----- Subcategoria
        IList<VncSubcategoriaCategoriaAM> TodosVncCategoriaSubcategoria();
        VncSubcategoriaCategoriaAM AgregarVncCategoriaSubcategoria(VncSubcategoriaCategoriaAM objeto);
        VncSubcategoriaCategoriaAM ObtenerVncCategoriaSubcategoria(int id);
        IList<SubcategoriaAM> TodosVncSubcategoria(int id);
        VncSubcategoriaCategoriaAM DesvncSubcategoriasCategoria(int idpadre, int idhijo);
        void VincularSubcategoriasCategoria(DvcSubcategoriaCategoria objeto);
        void DesvncSubcategoriasCategoria(DvcSubcategoriaCategoria objeto);
        IList<SubcategoriaAM> VinculadasSubcategoria(int id, int page, int size);
        long VinculadasSubcategoriasTotal(int id);


        //Subcategoria ---- Tercer Nivel
        IList<VncTercerNvlSubcategoriaAM> TodosVncTercerNvlSubcategoria();
        VncTercerNvlSubcategoriaAM AgregarVncTercerNvlSubcategoria(VncTercerNvlSubcategoriaAM objeto);
        VncTercerNvlSubcategoriaAM ObtenerVncTercerNvlSubcategoria(int id);
        IList<TercerNivelAM> TodosVncTercerNivel(int id);
        VncTercerNvlSubcategoriaAM DesvncTercerNvlSubcategoria(int idpadre, int idhijo);
        void DesvncTercerNvlSbc(DvcTercerNivelSct objeto);
        void VincularTercerNvlSbc(DvcTercerNivelSct objeto);
        IList<TercerNivelAM> VinculadasTercerNivel(int id, int page, int size);
        long VinculadasTercerNivelTotal(int id);

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
        IList<ElementoCategoriaAM> TodasElementoCategoria();
        ElementoCategoriaAM ElementoCategoriaId(int id);
        ElementoCategoriaAM AgregarElementoCategoria(ElementoCategoriaAM objeto);
        IList<PPTAM> VinculadasPPT(int id, int page, int size);
        IList<PPTAM> VincularPPT(int id, int page, int size);
        IList<SedeElectronicaAM> VinculadasSedeElectronica(int id, int page, int size);
        IList<SedeElectronicaAM> VincularSedeElectronica(int id, int page, int size);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnica(int id, int page, int size);
        IList<VentanillaUnicaAM> VincularVentanillaUnica(int id, int page, int size);
        IList<TramiteServicioAM> VinculadasTramiteServicio(int id, int page, int size);
        IList<TramiteServicioAM> VincularTramiteServicio(int id, int page, int size);

        //Elemento Subcategoria
        IList<ElementoSubcategoriaAM> TodasElementoSubcategoria();
        ElementoSubcategoriaAM ElementoSubcategoriaId(int id);
        ElementoSubcategoriaAM AgregarElementoSubcategoria(ElementoSubcategoriaAM objeto);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaSubcategoria(int id, int page, int size);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaSubcategoria(int id, int page, int size);


        //Elemento Tercer Nivel
        IList<ElementoTercerNivelAM> TodasElementoTercerNivel();
        ElementoTercerNivelAM ElementoTercerNivelId(int id);
        ElementoTercerNivelAM AgregarElementoTercerNivel(ElementoTercerNivelAM objeto);
        IList<VentanillaUnicaAM> VinculadasVentanillaUnicaTercerNivel(int id, int page, int size);
        IList<SedeElectronicaAM> VinculadasSedeElectronicaTercerNivel(int id, int page, int size);
    }
}