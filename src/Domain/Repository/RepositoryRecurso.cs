using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;

using System.Linq;
using System.Linq.Expressions;


namespace Domain.Repository
{
    public class RepositoryRecurso : InterfaceRecurso<Recurso>
    {
        protected readonly Context context;
        public RepositoryRecurso(Context context)
        {
            this.context = context;
        }

        public IList<Recurso> All()
        {
            return this.context.Recursos.ToList();
        }

        public void Add(Recurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Recursos.Add(objeto);
        }

        public Recurso GetId(int id)
        {
            return this.context.Recursos.Where(s => s.id == id).FirstOrDefault();
        }

        public void Update(Recurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Recursos.Update(objeto);
        }


        //Paginacion
        public int Count(Expression<Func<Recurso, bool>> predicate)
        {
            return context.Recursos.Count(predicate);
        }

        public ICollection<Recurso> Get(Expression<Func<Recurso, bool>> predicate, int page, int size, Expression<Func<Recurso, object>> selector, bool descending)
        {
            try
            {
                if (descending)
                    return context.Recursos
                           .Include(s => s.Estado)
                           .Include(s => s.Tipo)
                           .Include(s => s.TipoParametro)
                           .Where(predicate).OrderByDescending(selector).Skip(page).Take(size).ToList();
                return context.Recursos
                        .Include(s => s.Estado)
                        .Include(s => s.Tipo)
                        .Include(s => s.TipoParametro)
                      .Where(predicate).OrderBy(selector).Skip(page).Take(size).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}