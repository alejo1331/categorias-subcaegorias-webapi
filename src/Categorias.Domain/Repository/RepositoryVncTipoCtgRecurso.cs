using Categorias.Domain.Models;
using Categorias.Domain.Data;
using Categorias.Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;



namespace Categorias.Domain.Repository
{
    public class RepositoryVncTipoCtgRecurso : InterfaceVncTipoCtgRecurso<VncTipoCtgRecurso>
    {
        protected readonly Context context;
        public RepositoryVncTipoCtgRecurso(Context context)
        {
            this.context = context;
        }

        public IList<VncTipoCtgRecurso> All()
        {
            return this.context.VncTipoCtgRecursos.ToList();
        }

        public void Add(VncTipoCtgRecurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncTipoCtgRecursos.Add(objeto);
        }

        public VncTipoCtgRecurso GetId(int id)
        {
            return this.context.VncTipoCtgRecursos.Where(s => s.id == id).FirstOrDefault();
        }
    }
}