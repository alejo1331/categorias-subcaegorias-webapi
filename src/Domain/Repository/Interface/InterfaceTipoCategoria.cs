using Domain.Models;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.Interface
{
    public interface InterfaceTipoCategoria<TipoCategoria>
    {
        IList<TipoCategoria> All();
        void Add(TipoCategoria objeto);
        TipoCategoria GetId(int id);
        void update(TipoCategoria objeto);
        IList<TipoCategoria> Search(string data);
        void ChangeState(int id);
        bool Existe(string data);


        //Paginacion
        int Count(Expression<Func<TipoCategoria, bool>> predicate);
        IList<TipoCategoria> Get(Expression<Func<TipoCategoria, bool>> predicate, int page, int size, Expression<Func<TipoCategoria, object>> selector, bool descending);
    }
}