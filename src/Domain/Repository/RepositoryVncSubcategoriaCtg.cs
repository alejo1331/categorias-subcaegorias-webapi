using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository
{
    public class RepositoryVncSubcategoriaCtg : InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria>
    {
        protected readonly Context context;
        public RepositoryVncSubcategoriaCtg(Context context)
        {
            this.context = context;
        }

        public IList<VncSubcategoriaCategoria> All()
        {
            return this.context.VncSubcategoriaCategorias.ToList();
        }

        public void Add(VncSubcategoriaCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncSubcategoriaCategorias.Add(objeto);
        }

        public VncSubcategoriaCategoria GetId(int id)
        {
            return this.context.VncSubcategoriaCategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public IList<Subcategoria> getSubcategory(int id)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.tipoVinculo == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            IList<Subcategoria> subcategorias = this.context.Subcategorias.Where(s => vinculos.Contains(s.id)).ToList();
            return subcategorias;
        }

        public void Update(VncSubcategoriaCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncSubcategoriaCategorias.Update(objeto);
        }

        public VncSubcategoriaCategoria GetId(int idpadre, int idhijo)
        {
            return this.context.VncSubcategoriaCategorias.Where(s => s.idCategoria == idpadre && s.idSubcategoria == idhijo && s.tipoVinculo == 1).FirstOrDefault();
        }

        public IList<Subcategoria> Vinculadas(int id, int page, int size)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            IList<Subcategoria> subcategorias = this.context.Subcategorias.Where(s => vinculos.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return subcategorias;
        }

        public IList<Subcategoria> Vinculadas(int id)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            IList<Subcategoria> subcategorias = this.context.Subcategorias.Where(s => vinculos.Contains(s.id)).ToList();
            return subcategorias;
        }

        public long VinculadasTotal(int id)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            long total = this.context.Subcategorias.Count(s => vinculos.Contains(s.id));

            return total;

        }

        public IList<Subcategoria> VinculadasActivas(int id, int page, int size)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            IList<Subcategoria> subcategorias = this.context.Subcategorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1)
                                                                            .Skip((page - 1) * size)
                                                                            .Take(size)
                                                                            .ToList();
            return subcategorias;
        }

        public long VinculadasTotalActivas(int id)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            long subcategorias = this.context.Subcategorias.Count(s => vinculos.Contains(s.id) && s.codigoEstado == 1);
            return subcategorias;
        }

        //Vincular sin paginacion
        public IList<Subcategoria> Vincular(int id)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            IList<Subcategoria> subcategorias = this.context.Subcategorias.Where(s => !vinculos.Contains(s.id) && s.codigoEstado == 1).ToList();
            return subcategorias;
        }

        public IList<Subcategoria> Vincular(int id, int page, int size)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            IList<Subcategoria> subcategorias = this.context.Subcategorias.Where(s => !vinculos.Contains(s.id) && s.codigoEstado == 1)
                                                                            .Skip((page - 1) * size)
                                                                            .Take(size)
                                                                            .ToList();
            return subcategorias;
        }

        public long VincularTotal(int id)
        {
            var vinculos = this.context.VncSubcategoriaCategorias
                                                    .Where(s => s.idCategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idSubcategoria)
                                                    .ToList();

            long subcategorias = this.context.Subcategorias.Count(s => !vinculos.Contains(s.id) && s.codigoEstado == 1);
            return subcategorias;
        }
    }
}