using Domain.Models;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Domain.Repository.Interface
{
    public interface InterfaceTercerNivel<TercerNivel>
    {
        IList<TercerNivel> All();
        void Add(TercerNivel objeto);
        TercerNivel GetId(int id);
        Subcategoria GetSubcategoria(int id);
        void Update(TercerNivel objeto);
        IList<TercerNivel> Search(string data);
        IList<TercerNivel> SonsSubcategoria(int id);
        void ChangeState(int id);
        IList<string> Agrupar();


        //Paginacion
        int Count(Expression<Func<TercerNivel, bool>> predicate);
        ICollection<TercerNivel> Get(Expression<Func<TercerNivel, bool>> predicate, int page, int size, Expression<Func<TercerNivel, object>> selector, bool descending);
    }
}