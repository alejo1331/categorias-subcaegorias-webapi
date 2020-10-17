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
    public class RepositoryCategoria : InterfaceCategoria<Categoria>
    {
        protected readonly Context context;
        public RepositoryCategoria(Context context)
        {
            this.context = context;
        }
        public IList<Categoria> All()
        {
            return this.context.Categorias.ToList();
        }

        public void Add(Categoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Categorias.Add(objeto);
        }

        public Categoria GetId(int id)
        {
            return context.Categorias.Where(s => s.id == id).FirstOrDefault();
        }

        public TipoCategoria getIdCategoria(int id)
        {
            Categoria categoria = context.Categorias.Where(s => s.id == id).FirstOrDefault();
            if (categoria == null)
                return null;

            TipoCategoria tipo = context.TipoCategorias.Where(s => s.id == categoria.padre).FirstOrDefault();

            if (tipo == null)
                return null;

            return tipo;
        }

        public IList<Categoria> Search(string data)
        {
            return this.context.Categorias.Where(s => s.nombre.Contains(data) || s.descripcionCorta.Contains(data) || s.descripcionLarga.Contains(data)).ToList(); ;
        }

        public void update(Categoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Categorias.Update(objeto);
        }

        public IList<Categoria> SonsTipoCategoria(int id)
        {
            return this.context.Categorias.Where(s => s.padre == id).ToList();
        }

        public void ChangeState(int id)
        {
            Categoria objeto = this.context.Categorias.Where(s => s.id == id).FirstOrDefault();
            if (objeto.codigoEstado == 1)
                objeto.codigoEstado = 2;
            else
                objeto.codigoEstado = 1;

            this.context.Categorias.Update(objeto);
        }

        //Paginacion
        public int Count(Expression<Func<Categoria, bool>> predicate)
        {
            return context.Categorias.Count(predicate);
        }

        public ICollection<Categoria> Get(Expression<Func<Categoria, bool>> predicate, int page, int size, Expression<Func<Categoria, object>> selector, bool descending)
        {
            try
            {
                if (descending)
                    return context.Categorias
                           .Include(s => s.TipoCategoria)
                           .Include(s => s.Estado)
                           .Where(predicate).OrderByDescending(selector).Skip(page).Take(size).ToList();
                return context.Categorias
                        .Include(s => s.TipoCategoria)
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