using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryCategoriaCtgSuit : InterfaceCategoriaCtgSuit<CategoriaCtgSuit>
    {
        private readonly Context context;
        public RepositoryCategoriaCtgSuit(Context context)
        {
            this.context = context;
        }

        public IList<CategoriaCtgSuit> All()
        {
            return this.context.CategoriaCtgSuits.ToList();
        }

        public void Add(CategoriaCtgSuit objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.CategoriaCtgSuits.Add(objeto);
        }

        public CategoriaCtgSuit GetId(int id)
        {
            return context.CategoriaCtgSuits.Where(s => s.id == id).FirstOrDefault();
        }
    }
}