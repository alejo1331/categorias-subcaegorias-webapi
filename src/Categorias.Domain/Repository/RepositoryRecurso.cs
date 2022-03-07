using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Categorias.Domain.Repository.Interface;
using Categorias.Domain.Models;
using Categorias.Domain.Data;

using System.Linq;
using System.Linq.Expressions;


namespace Categorias.Domain.Repository
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
            return this.context.Recursos.Include(s => s.Tipo).Where(s => s.id == id).FirstOrDefault();
        }

        public void Update(Recurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Recursos.Update(objeto);
        }

        public void Estado(int id)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            Estado inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();

            Recurso recurso = this.context.Recursos.Where(s => s.id == id).FirstOrDefault();

            if (recurso == null)
                throw new ArgumentNullException(nameof(recurso));

            if(recurso.codigoEstado == activo.id)
                recurso.codigoEstado = inactivo.id;
            else
                recurso.codigoEstado = activo.id;

            this.context.Recursos.Update(recurso);
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