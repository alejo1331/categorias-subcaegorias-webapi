using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository
{
    public class RepositoryVncCategoriaTipoCtg : InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg>
    {
        protected readonly Context context;
        public RepositoryVncCategoriaTipoCtg(Context context)
        {
            this.context = context;
        }

        public IList<VncCategoriaTipoCtg> All()
        {
            return this.context.VncCategoriaTipoCtgs.ToList();
        }

        public void Add(VncCategoriaTipoCtg objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncCategoriaTipoCtgs.Add(objeto);
        }

        public VncCategoriaTipoCtg GetId(int id)
        {
            return this.context.VncCategoriaTipoCtgs.Where(s => s.id == id).FirstOrDefault();
        }
    }
}