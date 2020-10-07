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
        VncCategoriaTipoCtg GetId(int id);
        VncCategoriaTipoCtg GetId(int idpadre, int idhijo);
        void Update(VncCategoriaTipoCtg objeto);
        IList<Categoria> getCategory(int id);
    }
}