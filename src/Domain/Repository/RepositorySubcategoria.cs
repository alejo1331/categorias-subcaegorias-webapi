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
    }
}