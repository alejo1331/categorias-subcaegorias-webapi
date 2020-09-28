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
        CategoriaAM Add(CategoriaAM objeto, int id);
        CategoriaAM GetCategoria(int id);
        TipoCategoriaAM ObtenerCategoriaTipoCtg(int id);    
        CategoriaAM ActualizarCategoria(CategoriaAM objeto);    

        //Subcategoria
        IList<SubcategoriaAM> TodosSubcategoria();
        SubcategoriaAM AgregarSubcategoria(SubcategoriaAM objeto);
        SubcategoriaAM GetSubCategoria(int id);

        //Tercer Nivel
        IList<TercerNivelAM> TodosTercerNivel();
        TercerNivelAM AgregarTercerNivel(TercerNivelAM objeto);
        TercerNivelAM ObtenerTercerNivel(int id);


        //Tipo Recurso
        IList<TipoRecursoAM> TodosTipoRecurso();
        TipoRecursoAM AgregarTipoRecurso(TipoRecursoAM objeto);
        TipoRecursoAM ObtenerTipoRecurso(int id);

        //Recurso
        IList<RecursoAM> TodosRecurso();


        //Vinculaciones
        IList<VncCategoriaTipoCtgAM> TodosVncCategoriaTipoCtg();
        VncCategoriaTipoCtgAM AgregarVncCategoriaTipoCtg(VncCategoriaTipoCtgAM objeto);
        VncCategoriaTipoCtgAM ObtenerVncCategoriaTipoCtg(int id);
    }
}