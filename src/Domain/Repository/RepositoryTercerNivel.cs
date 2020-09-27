using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Repository
{
    public class RepositoryTercerNivel : InterfaceTercerNivel<TercerNivel>
    {
        protected readonly Context context;
        public RepositoryTercerNivel(Context context)
        {
            this.context = context;
        }
        public IList<TercerNivel> All()
        {
            return this.context.TercerNivels.ToList();
        }

        public void Add(TercerNivel objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TercerNivels.Add(objeto);
        }

        public TercerNivel GetId(int id)
        {
            return this.context.TercerNivels.Where(s => s.id == id).FirstOrDefault();
        }
    }
}