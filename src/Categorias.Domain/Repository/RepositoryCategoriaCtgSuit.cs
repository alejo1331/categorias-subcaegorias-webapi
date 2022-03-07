using System;
using System.Collections.Generic;
using Categorias.Domain.Repository.Interface;
using Categorias.Domain.Models;
using Categorias.Domain.Data;
using System.Linq;


namespace Categorias.Domain.Repository
{
    public class RepositoryCategoriaCtgSuit : InterfaceCategoriaCtgSuit<CategoriaCtgSuit>
    {
        private readonly Context context;
        private Estado activo;
        public RepositoryCategoriaCtgSuit(Context context)
        {
            this.context = context;
            this.activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
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

        public IList<CategoriaCtgSuit> GetCategoriasSuit(int idCategoria)
        {
            return context.CategoriaCtgSuits.Where(s => s.idCategoria == idCategoria && s.codigoEstado == this.activo.id).ToList();
        }

        public CategoriaCtgSuit GetId(int idCategoria, int idCategoriaSuit)
        {
            return context.CategoriaCtgSuits.Where(s => s.idCategoria == idCategoria  && s.idCategoriaSuit == idCategoriaSuit && s.codigoEstado == this.activo.id).FirstOrDefault();
        }

        public void update(CategoriaCtgSuit objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.CategoriaCtgSuits.Update(objeto);
        }
    }
}