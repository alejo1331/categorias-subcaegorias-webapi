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
    public class RepositoryTipoCategoria : InterfaceTipoCategoria<TipoCategoria>
    {
        protected readonly Context context;
        public RepositoryTipoCategoria(Context context)
        {
            this.context = context;
        }

        public IList<TipoCategoria> All()
        {
            return this.context.TipoCategorias.ToList();
        }

        public void Add(TipoCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TipoCategorias.Add(objeto);
        }

        public TipoCategoria GetId(int id)
        {
            return this.context.TipoCategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public void update(TipoCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TipoCategorias.Update(objeto);
        }

        public IList<TipoCategoria> Search(string data)
        {
            return this.context.TipoCategorias.Where(s => s.nombre.Contains(data) || s.decripcionCorta.Contains(data) || s.decripcionLarga.Contains(data)).ToList();
        }

        public void ChangeState(int id)
        {
            TipoCategoria objeto = this.context.TipoCategorias.Where(s => s.id == id).FirstOrDefault();
            if (objeto.codigoEstado == 1)
                objeto.codigoEstado = 2;
            else
                objeto.codigoEstado = 1;

            this.context.TipoCategorias.Update(objeto);
        }



        //Paginacion
        public int Count(Expression<Func<TipoCategoria, bool>> predicate)
        {
            return context.TipoCategorias.Count(predicate);
        }

        public IList<TipoCategoria> Get(Expression<Func<TipoCategoria, bool>> predicate, int page, int size, Expression<Func<TipoCategoria, object>> selector, bool descending)
        {
            try
            {
                if (descending)
                    return context.TipoCategorias
                           .Include(s => s.Estado)
                           .Where(predicate).OrderByDescending(selector).Skip(page).Take(size).ToList();
                return context.TipoCategorias
                        .Include(s => s.Estado)
                      .Where(predicate).OrderBy(selector).Skip(page).Take(size).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}