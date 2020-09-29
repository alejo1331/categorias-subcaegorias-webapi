using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository
{
    public class RepositoryRecurso : InterfaceRecurso<Recurso>
    {
        protected readonly Context context;
        public RepositoryRecurso(Context context)
        {
            this.context = context;
        }

        public IList<Recurso> All()
        {
            return this.context.Recursos.ToList();
        }

        public void Add(Recurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Recursos.Add(objeto);
        }
    }
}