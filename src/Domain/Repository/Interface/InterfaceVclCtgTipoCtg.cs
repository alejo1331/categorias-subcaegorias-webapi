using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg>
    {
        IList<VncCategoriaTipoCtg> All();
        void Add(VncCategoriaTipoCtg objeto);
        void update(VncCategoriaTipoCtg objeto);
        VncCategoriaTipoCtg GetId(int id);
        VncCategoriaTipoCtg GetId(int idpadre, int idhijo);
        void Update(VncCategoriaTipoCtg objeto);
        IList<Categoria> getCategory(int id, int page, int size, int orden, bool ascd);
        IList<Categoria> getCategoryDesvincular(int id, int page, int size, int orden, bool ascd);
        IList<Categoria> getCategoryActivos(int id, int page, int size, int orden, bool ascd);
        IList<Categoria> getCategoryInactivos(int id, int page, int size, int orden, bool ascd);
        IList<Categoria> getCategory(int id);
        IList<Categoria> Vincular(int id, int page, int size);
        long VincularTotal(int id);
        long DesvincularTotal(int id);
        long DesvincularTotalVinculadas(int id);
        long DesvincularTotalActivas(int id);
        long DesvincularTotalInactivas(int id);
    }
}