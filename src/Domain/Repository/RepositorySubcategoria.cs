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
    public class RepositorySubcategoria : InterfaceSubcategoria<Subcategoria>
    {
        protected readonly Context context;
        public RepositorySubcategoria(Context context)
        {
            this.context = context;
        }
        public IList<Subcategoria> All()
        {
            return this.context.Subcategorias.ToList();
        }

        public void Add(Subcategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Subcategorias.Add(objeto);
        }

        public Subcategoria GetId(int id)
        {
            return this.context.Subcategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public Categoria GetCategoria(int id)
        {
            Subcategoria subcategoria = this.context.Subcategorias.Where(s => s.id == id).FirstOrDefault();
            if (subcategoria == null)
                return null;
            Categoria categoria = this.context.Categorias.Where(s => s.id == subcategoria.padre).FirstOrDefault();
            if (categoria == null)
                return null;
            return categoria;
        }

        public IList<Subcategoria> Search(string data)
        {
            return this.context.Subcategorias.Where(s => s.nombre.Contains(data) || s.descripcionCorta.Contains(data) || s.descripcionLarga.Contains(data)).ToList();
        }

        public void Update(Subcategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Subcategorias.Update(objeto);
        }

        public IList<Subcategoria> SonsCategoria(int id)
        {
            return this.context.Subcategorias.Where(s => s.padre == id).ToList();
        }

        public void ChangeState(int id)
        {
            Subcategoria objeto = this.context.Subcategorias.Where(s => s.id == id).FirstOrDefault();
            if (objeto.codigoEstado == 1)
                objeto.codigoEstado = 2;
            else
                objeto.codigoEstado = 1;

            this.context.Subcategorias.Update(objeto);
        }


        //Paginacion
        public int Count(Expression<Func<Subcategoria, bool>> predicate)
        {
            return context.Subcategorias.Count(predicate);
        }

        public ICollection<Subcategoria> Get(Expression<Func<Subcategoria, bool>> predicate, int page, int size, Expression<Func<Subcategoria, object>> selector, bool descending)
        {
            try
            {
                if (descending)
                    return context.Subcategorias
                           .Include(s => s.Estado)
                           .Include(s => s.Categoria)
                           .Where(predicate).OrderByDescending(selector).Skip(page).Take(size).ToList();
                return context.Subcategorias
                        .Include(s => s.Estado)
                        .Include(s => s.Categoria)
                      .Where(predicate).OrderBy(selector).Skip(page).Take(size).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IList<string> Agrupar()
        {
             List<String> lista1 = new List<string>(); 

            var sql = this.context.Subcategorias.Include(x => x.Categoria).ToList().GroupBy(x => x.Categoria.nombre);
            foreach( var x in sql){
                foreach(var y in x){
                    lista1.Add(y.Categoria.nombre);
                    break;
                }
            } 
            return lista1;
        }

        public bool Existe(string data, int padre)
        {
            Subcategoria objeto = this.context.Subcategorias.Where(s => s.nombre == data && s.padre == padre).FirstOrDefault();
            if(objeto == null)
                return false;
            return true;
        }

        public int Count(int orden)
        {
            return this.context.Subcategorias.Where(s => s.orden == orden).Count();
        }
    }
}