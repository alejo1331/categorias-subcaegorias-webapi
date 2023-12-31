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
    public class RepositoryTercerNivel : InterfaceTercerNivel<TercerNivel>
    {
        protected readonly Context context;
        public RepositoryTercerNivel(Context context)
        {
            this.context = context;
        }
        public IList<TercerNivel> All()
        {
            return this.context.TercerNivels.OrderBy(s => s.nombre).ToList();
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
            return this.context.TercerNivels.Where(s => s.padre == id).OrderBy(s => s.nombre).ToList();
        }

        public void ChangeState(int id)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            Estado inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();

            TercerNivel objeto = this.context.TercerNivels.Where(s => s.id == id).FirstOrDefault();
            if (objeto.codigoEstado == activo.id)
                objeto.codigoEstado = inactivo.id;
            else
                objeto.codigoEstado = activo.id;

            this.context.TercerNivels.Update(objeto);
        }

        public IList<string> Agrupar()
        {
             List<String> lista1 = new List<string>(); 

            var sql = this.context.TercerNivels.Include(x => x.Subcategoria).OrderBy(x => x.Subcategoria.nombre).ToList().GroupBy(x => x.Subcategoria.nombre);
            foreach( var x in sql){
                foreach(var y in x){
                    lista1.Add(y.Subcategoria.nombre);
                    break;
                }
            } 
            return lista1;
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

        public bool Existe(string data, int padre)
        {
            TercerNivel objeto = this.context.TercerNivels.Where(s => s.nombre == data && s.padre == padre).FirstOrDefault();
            if(objeto == null)
                return false;
            return true;
        }

        public int Count(int orden)
        {
            return this.context.TercerNivels.Where(s => s.orden == orden).Count();
        }
    }
}