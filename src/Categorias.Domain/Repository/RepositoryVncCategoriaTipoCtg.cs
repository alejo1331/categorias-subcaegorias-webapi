using Categorias.Domain.Models;
using Categorias.Domain.Data;
using Categorias.Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Categorias.Domain.Repository
{
    public class RepositoryVncCategoriaTipoCtg : InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg>
    {
        protected readonly Context context;
        private Estado activo;
        private Estado inactivo;

        public RepositoryVncCategoriaTipoCtg(Context context)
        {
            this.context = context;
            this.activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            this.inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();
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

        public void update(VncCategoriaTipoCtg objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncCategoriaTipoCtgs.Update(objeto);
        }

        public VncCategoriaTipoCtg GetId(int id)
        {
            return this.context.VncCategoriaTipoCtgs.Where(s => s.id == id).FirstOrDefault();
        }

        public VncCategoriaTipoCtg GetId(int idpadre, int idhijo)
        {
            return this.context.VncCategoriaTipoCtgs.Where(s => s.idTipoCtg == idpadre && s.idCategoria == idhijo && s.codigoEstado == this.activo.id ).FirstOrDefault();
        }

        public void Update(VncCategoriaTipoCtg objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncCategoriaTipoCtgs.Update(objeto);
        }

        //Vinculados
        public IList<Categoria> getCategory(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            List<Categoria> categorias =  new List<Categoria>();
            
            if (orden == 1)
            {
                if(!ascd)
                { 
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                    .OrderBy(s => s.nombre)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList();       
                }
                else
                {
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                    .OrderByDescending(s => s.nombre)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList();
                }
            }
            else if (orden == 2)
            {
                if(!ascd)
                { 
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                    .OrderBy(s => s.orden)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList();       
                }
                else
                {
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                    .OrderByDescending(s => s.orden)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList();
                }
            }            
            else
            {
                categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList();
            }

            return categorias;
        }

        public IList<Categoria> getCategoryDesvincular(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id  && s.tipoVinculo == 0)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();

            List<Categoria> categorias =  new List<Categoria>();
            
            if (orden == 1)
            {
                if(!ascd)
                { 
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id )
                                        .OrderBy(s => s.nombre)
                                        .Skip((page -1 )*size)
                                        .Take(size)
                                        .ToList();        
                }
                else
                {
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id )
                                        .OrderByDescending(s => s.nombre)
                                        .Skip((page -1 )*size)
                                        .Take(size)
                                        .ToList(); 
                }
            }
            else if (orden == 2)
            {
                if(!ascd)
                { 
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id )
                                        .OrderBy(s => s.orden)
                                        .Skip((page -1 )*size)
                                        .Take(size)
                                        .ToList();        
                }
                else
                {
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id )
                                        .OrderByDescending(s => s.orden)
                                        .Skip((page -1 )*size)
                                        .Take(size)
                                        .ToList(); 
                }
            }
            else
            {
                categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id )
                                        .Skip((page -1 )*size)
                                        .Take(size)
                                        .ToList(); 
            }

            return categorias;
        }

        public IList<Categoria> getCategoryActivos(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            List<Categoria> categorias =  new List<Categoria>();
            
            if (orden == 1)
            {
                if(!ascd)
                { 
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id)
                                    .OrderBy(s => s.nombre)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList();    
                }
                else
                {
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id)
                                    .OrderByDescending(s => s.nombre)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList(); 
                }
            }
            else if (orden == 2)
            {
                if(!ascd)
                { 
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id)
                                    .OrderBy(s => s.orden)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList();    
                }
                else
                {
                    categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id)
                                    .OrderByDescending(s => s.orden)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList(); 
                }
            }
            else
            {
                categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id)
                                    .Skip((page -1 )*size)
                                    .Take(size)
                                    .ToList();
            }

            return categorias;
        }

        public IList<Categoria> getCategoryInactivos(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
                                                    
            List<Categoria> categorias =  new List<Categoria>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    categorias = this.context.Categorias
                                                .Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.inactivo.id)
                                                .OrderBy(s => s.nombre)
                                                .Skip((page -1 )*size).Take(size)
                                                .ToList();
                }
                else
                {
                    categorias = this.context.Categorias
                                                .Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.inactivo.id)
                                                .OrderByDescending(s => s.nombre)
                                                .Skip((page -1 )*size).Take(size)
                                                .ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    categorias = this.context.Categorias
                                                .Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.inactivo.id)
                                                .OrderBy(s => s.orden)
                                                .Skip((page -1 )*size).Take(size)
                                                .ToList();
                }
                else
                {
                    categorias = this.context.Categorias
                                                .Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.inactivo.id)
                                                .OrderByDescending(s => s.orden)
                                                .Skip((page -1 )*size).Take(size)
                                                .ToList();
                }
            }
            else
            {
                categorias = this.context.Categorias
                                                .Where(s => vinculos.Contains(s.id) && s.codigoEstado == this.inactivo.id)
                                                .Skip((page -1 )*size).Take(size)
                                                .ToList();
            }

            return categorias;
        }


        //Vinculados

        public IList<Categoria> getCategory(int id)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            IList<Categoria> categorias = this.context.Categorias
                                                .Where(s => vinculos.Contains(s.id))
                                                .ToList();

            return categorias;
        }

        //Desvinculados

        public IList<Categoria> Vincular(int id, int page, int size, int orden, bool ascd)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            List<Categoria> categorias = new List<Categoria>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    categorias = this.context.Categorias
                                                .Where(s => !vinculos.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                .OrderBy(s => s.nombre)
                                                .Skip((page -1 )*size)
                                                .Take(size)
                                                .ToList();
                }
                else
                {
                    categorias = this.context.Categorias
                                                .Where(s => !vinculos.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                .OrderByDescending(s => s.nombre)
                                                .Skip((page -1 )*size)
                                                .Take(size)
                                                .ToList();
                }
            }
            else
            {
                categorias = this.context.Categorias
                                                .Where(s => !vinculos.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                .Skip((page -1 )*size)
                                                .Take(size)
                                                .ToList();
            }


            return categorias;
        }

        //Total desvinculados
        public long VincularTotal(int id)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            long categorias = this.context.Categorias
                                                .Count(s => s.codigoEstado == 1 && !vinculos.Contains(s.id));

            return categorias;
        }

        //Total Vinculados
        public long DesvincularTotal(int id)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            long categorias = this.context.Categorias
                                                .Count(s => vinculos.Contains(s.id));

            return categorias;
        }

        public long DesvincularTotalVinculadas(int id)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id && s.tipoVinculo == 0)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            long categorias = this.context.Categorias
                                                .Count(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id);

            return categorias;
        }

        //Total Vinculadas Activas
        public long DesvincularTotalActivas(int id)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            long categorias = this.context.Categorias
                                                .Count(s => vinculos.Contains(s.id) && s.codigoEstado == this.activo.id);

            return categorias;
        }

        public long DesvincularTotalInactivas(int id)
        {
            var vinculos = this.context.VncCategoriaTipoCtgs
                                                    .Where(s => s.idTipoCtg == id && s.codigoEstado == this.activo.id)
                                                    .Select(s => s.idCategoria)
                                                    .ToList();
            long categorias = this.context.Categorias
                                                .Count(s => vinculos.Contains(s.id) && s.codigoEstado == this.inactivo.id);

            return categorias;
        }
    }
}