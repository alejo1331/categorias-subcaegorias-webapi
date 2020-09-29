using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;



namespace Domain.Repository
{
    public class RepositoryVncSubcategoriaRecurso : InterfaceVncSubcategoriaRecurso<VncSubcategoriaRecurso>
    {
        protected readonly Context context;
        public RepositoryVncSubcategoriaRecurso(Context context)
        {
            this.context = context;
        }

        public IList<VncSubcategoriaRecurso> All()
        {
            return this.context.VncSubcategoriaRecursos.ToList();
        }

        public void Add(VncSubcategoriaRecurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncSubcategoriaRecursos.Add(objeto);
        }

        public VncSubcategoriaRecurso GetId(int id)
        {
            return this.context.VncSubcategoriaRecursos.Where(s => s.id == id).FirstOrDefault();
        }
    }
}