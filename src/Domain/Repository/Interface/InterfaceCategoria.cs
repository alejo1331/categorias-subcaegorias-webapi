using Domain.Models;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceCategoria<Categoria>
    {
        IList<Categoria> All();
        void Add(Categoria objeto);
        Categoria GetId(int id);
        TipoCategoria getIdCategoria(int id);
        void update(Categoria objeto);
        IList<Categoria> Search(string data);
    }
}