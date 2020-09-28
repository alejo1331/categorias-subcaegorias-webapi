using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;

namespace Domain.Repository
{
    public class RepositoryCategoria : InterfaceCategoria<Categoria>
    {
        protected readonly Context context;
        public RepositoryCategoria(Context context)
        {
            this.context = context;
        }
        public IList<Categoria> All()
        {
            return this.context.Categorias.ToList();
        }

        public void Add(Categoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Categorias.Add(objeto);
        }

        public Categoria GetId(int id)
        {
            return context.Categorias.Where(s => s.id == id).FirstOrDefault();
        }

        public TipoCategoria getIdCategoria(int id)
        {
            VncCategoriaTipoCtg vinculo = this.context.VncCategoriaTipoCtgs.Where(s => s.idCategoria == id && s.tipoVinculo == 1).FirstOrDefault();
            if (vinculo == null)
                return null;
            else
            {
                TipoCategoria tipo = this.context.TipoCategorias.Where(s => s.id == vinculo.idTipoCtg).FirstOrDefault();
                return tipo;
            }
        }

        public void update(Categoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));
                
            this.context.Categorias.Update(objeto);
        }
    }
}