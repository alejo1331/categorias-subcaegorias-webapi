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

        public long getTotalId(int id)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();

            return this.context.VncCategoriaRecursos.Count(s => s.idCtg == id && s.codigoEstado == activo.id);
        }
    }
}