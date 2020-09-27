using System.Collections.Generic;
using Domain.AplicationModel;

using Microsoft.AspNetCore.Mvc;


namespace Domain.Bussiness.Interface
{
    public interface IAdministracionBO
    {

        //Estado
        IList<EstadoAM> All();
        EstadoAM AddEstado(EstadoAM objeto);
        EstadoAM getIdEstado(int id);

        /*//TipoCategoria
        IList<TipoCategoriaAM> AllTiposCtg();
        void Add(TipoCategoriaAM objeto);
        TipoCategoriaAM getTipoCtgId(int id);*/

        //Categoria
        IList<CategoriaAM> AllCategorias();
        CategoriaAM Add(CategoriaAM objeto);
        CategoriaAM GetCategoria(int id);
    }
}