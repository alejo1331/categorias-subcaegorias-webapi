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

        public VncTercerNvlSubcategoria GetId(int id)
        {
            return this.context.VncTercerNvlSubcategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public VncTercerNvlSubcategoria GetId(int idpadre, int idhijo)
        {
            return this.context.VncTercerNvlSubcategorias.Where(s => s.idSubcategoria == idpadre && s.idTercerNvl == idhijo && s.vinculo == 1).FirstOrDefault();
        }

        public void Update(VncTercerNvlSubcategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncTercerNvlSubcategorias.Update(objeto);
        }

        public IList<TercerNivel> getTercerNivel(int id)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.vinculo == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            IList<TercerNivel> lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id)).ToList();
            return lista;
        }
    }
}