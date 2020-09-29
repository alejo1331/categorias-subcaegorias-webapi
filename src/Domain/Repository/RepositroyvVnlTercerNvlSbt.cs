using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository
{
    public class RepositroyvVnlTercerNvlSbt : InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria>
    {
        protected readonly Context context;
        public RepositroyvVnlTercerNvlSbt(Context context)
        {
            this.context = context;
        }

        public IList<VncTercerNvlSubcategoria> All()
        {
            return this.context.VncTercerNvlSubcategorias.ToList();
        }

        public void Add(VncTercerNvlSubcategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncTercerNvlSubcategorias.Add(objeto);
        }

        public VncTercerNvlSubcategoria GetId(int id){
            return this.context.VncTercerNvlSubcategorias.Where(s => s.id == id).FirstOrDefault();
        }
    }
}