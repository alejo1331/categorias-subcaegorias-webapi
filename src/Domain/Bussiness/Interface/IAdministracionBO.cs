using System.Collections.Generic;
using Domain.AplicationModel;

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

        //Categoria
        IList<CategoriaAM> AllCategorias();
        CategoriaAM Add(CategoriaAM objeto);
        CategoriaAM GetCategoria(int id);
        TipoCategoriaAM ObtenerCategoriaTipoCtg(int id);
        CategoriaAM ActualizarCategoria(CategoriaAM objeto);

        //Subcategoria
        IList<SubcategoriaAM> TodosSubcategoria();
        SubcategoriaAM AgregarSubcategoria(SubcategoriaAM objeto);
        SubcategoriaAM GetSubCategoria(int id);
        CategoriaAM GetCategoriaSubcatgoria(int id);
        SubcategoriaAM ActualizarSubCategoria(SubcategoriaAM objeto);

        //Tercer Nivel
        IList<TercerNivelAM> TodosTercerNivel();
        TercerNivelAM AgregarTercerNivel(TercerNivelAM objeto);
        TercerNivelAM ObtenerTercerNivel(int id);
        SubcategoriaAM GetSubcategoriaTercerNvl(int id);
        TercerNivelAM ActualizarTercerNivel(TercerNivelAM objeto);


        //Tipo Recurso
        IList<TipoRecursoAM> TodosTipoRecurso();
        TipoRecursoAM AgregarTipoRecurso(TipoRecursoAM objeto);
        TipoRecursoAM ObtenerTipoRecurso(int id);

        //Recurso
        IList<RecursoAM> TodosRecurso();
        RecursoAM AgregarRecurso(RecursoAM objeto);

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


        //Categoria ----- Subcategoria
        IList<VncSubcategoriaCategoriaAM> TodosVncCategoriaSubcategoria();
        VncSubcategoriaCategoriaAM AgregarVncCategoriaSubcategoria(VncSubcategoriaCategoriaAM objeto);
        VncSubcategoriaCategoriaAM ObtenerVncCategoriaSubcategoria(int id);


        //Subcategoria ---- Tercer Nivel
        IList<VncTercerNvlSubcategoriaAM> TodosVncTercerNvlSubcategoria();
        VncTercerNvlSubcategoriaAM AgregarVncTercerNvlSubcategoria(VncTercerNvlSubcategoriaAM objeto);
        VncTercerNvlSubcategoriaAM ObtenerVncTercerNvlSubcategoria(int id);

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