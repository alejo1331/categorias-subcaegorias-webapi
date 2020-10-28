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

        public VncCategoriaTipoCtg GetId(int idpadre, int idhijo)
        {
            return this.context.VncCategoriaTipoCtgs.Where(s => s.idTipoCtg == idpadre && s.idCategoria == idhijo && s.tipoVinculo == 1).FirstOrDefault();
        }

        public void Update(VncCategoriaTipoCtg objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncCategoriaTipoCtgs.Update(objeto);
        }

        public IList<Categoria> getCategory(int id, int page, int size)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.tipoVinculo == 1)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            IList<Categoria> categorias = this.context.Categorias
                                                .Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1)
                                                .Skip(page).Take(size)
                                                .ToList();

            return categorias;
        }

        public IList<Categoria> Vincular(int id, int page, int size)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.tipoVinculo == 1)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            IList<Categoria> categorias = this.context.Categorias
                                                .Where(s => !vinculos.Contains(s.id) && s.codigoEstado == 1).Skip(page).Take(size)
                                                .ToList();


            return categorias;
        }

        public long VincularTotal(int id)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.tipoVinculo == 1)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            long categorias = this.context.Categorias
                                                .Count(s => s.codigoEstado == 1 && !vinculos.Contains(s.id));

            return categorias;
        }

        public long DesvincularTotal(int id)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.tipoVinculo == 1)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            long categorias = this.context.Categorias
                                                .Count(s => vinculos.Contains(s.id) && s.codigoEstado == 1);

            return categorias;
        }
    }
}