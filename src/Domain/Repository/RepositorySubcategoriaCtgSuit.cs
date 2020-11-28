using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositorySubcategoriaCtgSuit : InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit>
    {
        private readonly Context context;
        public RepositorySubcategoriaCtgSuit(Context context)
        {
            this.context = context;
        }

        public IList<SubcategoriaCtgSuit> All()
        {
            return this.context.SubcategoriaCtgSuits.ToList();
        }

        public void Add(SubcategoriaCtgSuit objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.SubcategoriaCtgSuits.Add(objeto);
        }

        public SubcategoriaCtgSuit GetId(int id)
        {
            return context.SubcategoriaCtgSuits.Where(s => s.id == id).FirstOrDefault();
        }

        public SubcategoriaCtgSuit GetId(int idSubcategoria, int idCategoriaSuit)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            return context.SubcategoriaCtgSuits.Where(s => s.idSubcategoria == idSubcategoria  && s.idCategoriaSuit == idCategoriaSuit && s.codigoEstado == activo.id).FirstOrDefault();
        }

        public IList<SubcategoriaCtgSuit> GetSubcategoriasSuit(int idSubcategoria)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            return context.SubcategoriaCtgSuits.Where(s => s.idSubcategoria == idSubcategoria && s.codigoEstado == activo.id).ToList();
        }

        public void update(SubcategoriaCtgSuit objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.SubcategoriaCtgSuits.Update(objeto);
        }
    }
}