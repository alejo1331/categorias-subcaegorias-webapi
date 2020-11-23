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
            return this.context.VncTercerNvlSubcategorias.Where(s => s.idSubcategoria == idpadre && s.idTercerNvl == idhijo && s.codigoEstado == 1).FirstOrDefault();
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

        public IList<TercerNivel> Vinculadas(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();
            
            List<TercerNivel> lista = new List<TercerNivel>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id)).Skip((page - 1) * size).OrderBy(s => s.nombre).Take(size).ToList();
                }
                else
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id)).Skip((page - 1) * size).OrderByDescending(s => s.nombre).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id)).Skip((page - 1) * size).OrderBy(s => s.orden).Take(size).ToList();
                }
                else
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id)).Skip((page - 1) * size).OrderByDescending(s => s.orden).Take(size).ToList();
                }
            }
            else
            {
                lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id)).Skip((page - 1) * size).OrderByDescending(s => s.orden).Take(size).ToList();
            }
            return lista;
        }

        public IList<TercerNivel> VinculadasTipoCero(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1 && s.vinculo == 0)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();
            
            List<TercerNivel> lista = new List<TercerNivel>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).OrderBy(s => s.nombre).Take(size).ToList();
                }
                else
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).OrderByDescending(s => s.nombre).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).OrderBy(s => s.orden).Take(size).ToList();
                }
                else
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).OrderByDescending(s => s.orden).Take(size).ToList();
                }
            }
            else
            {
                lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).OrderByDescending(s => s.orden).Take(size).ToList();
            }
            return lista;
        }

        public IList<TercerNivel> VinculadasActivas(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            List<TercerNivel> lista = new List<TercerNivel>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.orden).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.orden).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            }
            return lista;
        }

        public IList<TercerNivel> VinculadasInactivas(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            List<TercerNivel> lista = new List<TercerNivel>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 2).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 2).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 2).OrderBy(s => s.orden).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 2).OrderByDescending(s => s.orden).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id) && s.codigoEstado == 2).Skip((page - 1) * size).Take(size).ToList();
            }
            return lista;
        }

        public IList<TercerNivel> Vinculadas(int id)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                                .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                                .Select(s => s.idTercerNvl)
                                                                .ToList();

            IList<TercerNivel> lista = this.context.TercerNivels.Where(s => vinculos.Contains(s.id)).ToList();
            return lista;
        }

        public long VinculadasTota(int id)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            long lista = this.context.TercerNivels.Count(s => vinculos.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VinculadasTotaTipoCero(int id)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1 && s.vinculo == 0)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            long lista = this.context.TercerNivels.Count(s => vinculos.Contains(s.id));
            return lista;
        }

        public long VinculadasTotaActivas(int id)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            long lista = this.context.TercerNivels.Count(s => vinculos.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VinculadasTotaInactivas(int id)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            long lista = this.context.TercerNivels.Count(s => vinculos.Contains(s.id) && s.codigoEstado == 2);
            return lista;
        }

        public IList<TercerNivel> Vincular(int id, int page, int size)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            IList<TercerNivel> lista = this.context.TercerNivels.Where(s => !vinculos.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public  long VincularTota(int id)
        {
            var vinculos = this.context.VncTercerNvlSubcategorias
                                                    .Where(s => s.idSubcategoria == id && s.codigoEstado == 1)
                                                    .Select(s => s.idTercerNvl)
                                                    .ToList();

            long lista = this.context.TercerNivels.Count(s => !vinculos.Contains(s.id) && s.codigoEstado == 1 );
            return lista;
        }
    }
}