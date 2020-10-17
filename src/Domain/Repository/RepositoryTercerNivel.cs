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
    public class RepositoryTercerNivel : InterfaceTercerNivel<TercerNivel>
    {
        protected readonly Context context;
        public RepositoryTercerNivel(Context context)
        {
            this.context = context;
        }
        public IList<TercerNivel> All()
        {
            return this.context.TercerNivels.ToList();
        }

        public void Add(TercerNivel objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TercerNivels.Add(objeto);
        }

        public TercerNivel GetId(int id)
        {
            return this.context.TercerNivels.Where(s => s.id == id).FirstOrDefault();
        }

        public Subcategoria GetSubcategoria(int id)
        {
            TercerNivel tercer = this.context.TercerNivels.Where(s => s.id == id).FirstOrDefault();
            if (tercer == null)
                return null;

            Subcategoria subcategoria = this.context.Subcategorias.Where(s => s.id == tercer.padre).FirstOrDefault();
            if (subcategoria == null)
                return null;

            return subcategoria;
        }

        public IList<TercerNivel> Search(string data)
        {
            return this.context.TercerNivels.Where(s => s.nombre.Contains(data) || s.descripcionCorta.Contains(data) || s.descripcionLarga.Contains(data)).ToList();
        }

        public void Update(TercerNivel objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TercerNivels.Update(objeto);
        }

        public IList<TercerNivel> SonsSubcategoria(int id)
        {
            return this.context.TercerNivels.Where(s => s.padre == id).ToList();
        }

        public void ChangeState(int id)
        {
            TercerNivel objeto = this.context.TercerNivels.Where(s => s.id == id).FirstOrDefault();
            if (objeto.codigoEstado == 1)
                objeto.codigoEstado = 2;
            else
                objeto.codigoEstado = 1;

            this.context.TercerNivels.Update(objeto);
        }



        //Paginacion
        public int Count(Expression<Func<TercerNivel, bool>> predicate)
        {
            return context.TercerNivels.Count(predicate);
        }

        public ICollection<TercerNivel> Get(Expression<Func<TercerNivel, bool>> predicate, int page, int size, Expression<Func<TercerNivel, object>> selector, bool descending)
        {
            try
            {
                if (descending)
                    return context.TercerNivels
                           .Include(s => s.Estado)
                           .Include(s => s.Subcategoria)
                           .Where(predicate).OrderByDescending(selector).Skip(page).Take(size).ToList();
                return context.TercerNivels
                        .Include(s => s.Estado)
                        .Include(s => s.Subcategoria)
                      .Where(predicate).OrderBy(selector).Skip(page).Take(size).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}