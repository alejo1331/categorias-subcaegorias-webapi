using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository
{
    public class RepositoryVncCategoriaRecurso : InterfaceVncCategoriaRecurso<VncCategoriaRecurso>
    {
        protected readonly Context context;
        public RepositoryVncCategoriaRecurso(Context context)
        {
            this.context = context;
        }

        public IList<VncCategoriaRecurso> All()
        {
            return this.context.VncCategoriaRecursos.ToList();
        }

        public void Add(VncCategoriaRecurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncCategoriaRecursos.Add(objeto);
        }

        public VncCategoriaRecurso GetId(int id)
        {
            return this.context.VncCategoriaRecursos.Where(s => s.id == id).FirstOrDefault();
        }
    }
}