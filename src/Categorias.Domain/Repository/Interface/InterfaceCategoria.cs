using Categorias.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceCategoria<Categoria>
    {
        IList<Categoria> All();
        void Add(Categoria objeto);
        Categoria GetId(int id);
        TipoCategoria getIdCategoria(int id);
        void update(Categoria objeto);
        IList<Categoria> Search(string data);
        IList<Categoria> SonsTipoCategoria(int id);
        void ChangeState(int id);
        IList<string> Agrupar();
        bool Existe(string data, int padre);
        IList<Categoria> Activas();
        IList<Categoria> ActivasOrden();
        int Count(int orden);


        //Paginacion
        int Count(Expression<Func<Categoria, bool>> predicate);
        ICollection<Categoria> Get(Expression<Func<Categoria, bool>> predicate, int page, int size, Expression<Func<Categoria, object>> selector, bool descending);
    }
}