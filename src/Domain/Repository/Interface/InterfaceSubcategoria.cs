using Domain.Models;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Domain.Repository.Interface
{
    public interface InterfaceSubcategoria<Subcategoria>
    {
        IList<Subcategoria> All();
        void Add(Subcategoria objeto);
        Subcategoria GetId(int id);
        Categoria GetCategoria(int id);
        void Update(Subcategoria objeto);
        IList<Subcategoria> Search(string data);


        //Paginacion
        int Count(Expression<Func<Subcategoria, bool>> predicate);
        ICollection<Subcategoria> Get(Expression<Func<Subcategoria, bool>> predicate, int page, int size, Expression<Func<Subcategoria, object>> selector, bool descending);
    }
}