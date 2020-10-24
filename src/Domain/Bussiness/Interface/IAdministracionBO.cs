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
        long ObtenerTotalTipoCategoria(Expression<Func<TipoCategoriaAM, bool>> predicate);
        IList<TipoCategoriaAM> ObtenerTipoCategoria(Expression<Func<TipoCategoriaAM, bool>> predicate, int page, int size, Expression<Func<TipoCategoriaAM, object>> selector, bool descending);

        //Categoria
        IList<CategoriaAM> AllCategorias();
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
        IList<CategoriaAM> TodosVncCategorias(int id);
        VncCategoriaTipoCtgAM DesvncCategoriaTipoCtg(int idpadre, int idhijo);
        void DesvncCategoriaTipo(DvcCategoriaTipoCtg objeto);
        void VincularCategoriaTipo(DvcCategoriaTipoCtg objeto);



        //Categoria ----- Subcategoria
        IList<VncSubcategoriaCategoriaAM> TodosVncCategoriaSubcategoria();
        VncSubcategoriaCategoriaAM AgregarVncCategoriaSubcategoria(VncSubcategoriaCategoriaAM objeto);
        VncSubcategoriaCategoriaAM ObtenerVncCategoriaSubcategoria(int id);
        IList<SubcategoriaAM> TodosVncSubcategoria(int id);
        VncSubcategoriaCategoriaAM DesvncSubcategoriasCategoria(int idpadre, int idhijo);
        void VincularSubcategoriasCategoria(DvcSubcategoriaCategoria objeto);
        void DesvncSubcategoriasCategoria(DvcSubcategoriaCategoria objeto);


        //Subcategoria ---- Tercer Nivel
        IList<VncTercerNvlSubcategoriaAM> TodosVncTercerNvlSubcategoria();
        VncTercerNvlSubcategoriaAM AgregarVncTercerNvlSubcategoria(VncTercerNvlSubcategoriaAM objeto);
        VncTercerNvlSubcategoriaAM ObtenerVncTercerNvlSubcategoria(int id);
        IList<TercerNivelAM> TodosVncTercerNivel(int id);
        VncTercerNvlSubcategoriaAM DesvncTercerNvlSubcategoria(int idpadre, int idhijo);
        void DesvncTercerNvlSbc(DvcTercerNivelSct objeto);
        void VincularTercerNvlSbc(DvcTercerNivelSct objeto);

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

    }
}