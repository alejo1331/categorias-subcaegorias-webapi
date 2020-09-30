using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;

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

        public void Update(Subcategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Subcategorias.Update(objeto);
        }
    }
}