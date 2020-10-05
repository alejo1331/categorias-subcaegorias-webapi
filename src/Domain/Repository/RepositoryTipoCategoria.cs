using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository
{
    public class RepositoryTipoCategoria : InterfaceTipoCategoria<TipoCategoria>
    {
        protected readonly Context context;
        public RepositoryTipoCategoria(Context context)
        {
            this.context = context;
        }

        public IList<TipoCategoria> All()
        {
            return this.context.TipoCategorias.ToList();
        }

        public void Add(TipoCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TipoCategorias.Add(objeto);
        }

        public TipoCategoria GetId(int id)
        {
            return this.context.TipoCategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public void update(TipoCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TipoCategorias.Update(objeto);
        }

        public IList<TipoCategoria> Search(string data)
        {
            return this.context.TipoCategorias.Where(s => s.nombre.Contains(data) || s.decripcionCorta.Contains(data) || s.decripcionLarga.Contains(data) ).ToList();
        }
    }
}