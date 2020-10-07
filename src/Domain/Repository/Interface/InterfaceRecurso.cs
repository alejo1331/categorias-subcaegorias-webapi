using Domain.Models;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Domain.Repository.Interface
{
    public interface InterfaceRecurso<Recurso>
    {
        IList<Recurso> All();
        void Add(Recurso objeto);
        Recurso GetId(int id);
        void Update(Recurso objeto);

        //Paginacion
        int Count(Expression<Func<Recurso, bool>> predicate);
        ICollection<Recurso> Get(Expression<Func<Recurso, bool>> predicate, int page, int size, Expression<Func<Recurso, object>> selector, bool descending);
    }
}