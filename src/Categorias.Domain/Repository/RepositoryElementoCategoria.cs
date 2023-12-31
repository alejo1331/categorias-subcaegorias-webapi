using System;
using System.Collections.Generic;
using Categorias.Domain.Repository.Interface;
using Categorias.Domain.Models;
using Categorias.Domain.Data;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Categorias.Domain.Repository
{
    public class RepositoryElementoCategoria : InterfaceElementoCategoria<ElementoCategoria>
    {
        private readonly Context context;
        private Estado activo;
        private readonly InterfaceCategoriaTramiteDestacado _categoriaRepository;


        public RepositoryElementoCategoria(Context context)
        {
            this.context = context;
            this.activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            this._categoriaRepository = new RepositoryCategoriaTramiteDestacado();
        }

        public void update(int id)
        {
            Estado inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();
            ElementoCategoria objeto = context.ElementoCategorias.Where(s => s.id == id).FirstOrDefault();

            if (objeto.codigoEstado == activo.id)
                objeto.codigoEstado = inactivo.id;
            else
                objeto.codigoEstado = activo.id;

            this.context.ElementoCategorias.Update(objeto);
            
            if (objeto.codigoEstado == inactivo.id) 
            {
                Task<CategoriaTramiteDestacado> model = _categoriaRepository.EliminarCategoriaTramiteDestacado(objeto.categoriaId,objeto.elementoId);
            }
        }

        public IList<ElementoCategoria> All()
        {
            return this.context.ElementoCategorias.ToList();
        }

        public ElementoCategoria GetId(int id)
        {
            return context.ElementoCategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public ElementoCategoria GetSedeElectronicaId(int id, int padre)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            return context.ElementoCategorias.Where(s => s.elementoId == id.ToString() && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id && s.categoriaId == padre).FirstOrDefault();
        }

        public ElementoCategoria GetVentanillaUnicaId(int id, int padre)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            return context.ElementoCategorias.Where(s => s.elementoId == id.ToString() && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id && s.categoriaId == padre).FirstOrDefault();
        }

        public ElementoCategoria GetTramiteServicioId(string id, int padre)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            return context.ElementoCategorias.Where(s => s.elementoId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id && s.categoriaId == padre).FirstOrDefault();
        }

        public ElementoCategoria GetPortalTransversalId(int id, int padre)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            return context.ElementoCategorias.Where(s => s.elementoId == id.ToString() && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id && s.categoriaId == padre).FirstOrDefault();
        }

        public void Add(ElementoCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoCategorias.Add(objeto);
        }

        public IList<PortalTransversal> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .OrderBy(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                }
            }
            else if(tipo == 2)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .OrderBy(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                }
            }
            else
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .OrderBy(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                }
            }            
            return lista;
        }

        public IList<PortalTransversal> VincularPortalTransversal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return lista;
        }

        public IList<PortalTransversal> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .OrderBy(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                }
            }
            else if(tipo == 2)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .OrderBy(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id &&  s.nombre.Contains(filtro))
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                }
            }
            else
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .OrderBy(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                    else
                    {
                        lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                    }
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id )
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)
                                                                                            .ToList();
                }
            }
            return lista;
        }

        public IList<PortalTransversal> VinculadasPortalTransversal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id).ToList();
            return lista;
        }

        public long VincularPortalTransversalTotal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            long lista = this.context.PortalTransversals.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VincularPortalTransversalTotal(int id, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            long contador = 0;
            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                contador = this.context.PortalTransversals.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                contador = this.context.PortalTransversals.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro));
            }
            else
            {
                contador = this.context.PortalTransversals.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            }
            return contador;
        }

        public long VinculadasPortalTransversalTotal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            long lista = this.context.PortalTransversals.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            return lista;
        }

        public long VinculadasPortalTransversalTotal(int id, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            long contador = 0;
            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                contador = this.context.PortalTransversals.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                contador = this.context.PortalTransversals.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro));
            }
            else
            {
                contador = this.context.PortalTransversals.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            }
            return contador;
        }

        public IList<Recurso> VincularRecurso(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {            
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            List<Recurso>  lista = new List<Recurso>();

            if(tipo == 1)
            {   
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                    .Include(s => s.Tipo)    
                                                    .Where(s => !vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                    .OrderBy(s => s.id)
                                                    .Skip((page - 1) * size)
                                                    .Take(size)
                                                    .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                    .Include(s => s.Tipo)
                                                    .Where(s => !vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                    .OrderByDescending(s => s.id)
                                                    .Skip((page - 1) * size)
                                                    .Take(size)
                                                    .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                    .Include(s => s.Tipo)
                                                    .Where(s => !vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                    .OrderBy(s => s.nombre)
                                                    .Skip((page - 1) * size)
                                                    .Take(size)
                                                    .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderByDescending(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderBy(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderByDescending(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else
                {
                    lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                }
            }
            else if(tipo == 2)
            {   
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderBy(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderByDescending(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderBy(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderByDescending(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderBy(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderByDescending(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else
                {
                    lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                }
            }
            else if(tipo == 3)
            {   
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .OrderBy(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .OrderByDescending(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .OrderBy(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .OrderByDescending(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .OrderBy(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .OrderByDescending(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else
                {
                    lista = this.context.Recursos
                                                        
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                }
            }
            else
            {   
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id))
                                                        .OrderBy(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id) )
                                                        .OrderByDescending(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id))
                                                        .OrderBy(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id))
                                                        .OrderByDescending(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id))
                                                        .OrderBy(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id))
                                                        .OrderByDescending(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else
                {
                    lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => !vinculadas.Contains(s.id))
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                }
            }

            return lista;
        }

        public IList<string> AgruparTipoRecursoVinculadas(int id)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            
            var lista = this.context.Recursos
                                        .Include(s => s.Tipo)
                                        .Where(s => vinculadas.Contains(s.id))
                                        .OrderBy(s => s.Tipo.nombre)
                                        .ToList()
                                        .GroupBy(x => x.Tipo.nombre);

            List<string> lista1 = new List<string>();
            foreach (var x in lista)
            {
                foreach (var y in x)
                {
                    lista1.Add(y.Tipo.nombre);
                    break;
                }
            }
            return lista1;
        }

        public IList<string> AgruparTipoRecursoVincular(int id)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            var lista = this.context.Recursos
                                        .Include(s => s.Tipo)
                                        .Where(s => !vinculadas.Contains(s.id))
                                        .OrderBy(s => s.Tipo.nombre)
                                        .ToList()
                                        .GroupBy(x => x.Tipo.nombre);
            List<string> lista1 = new List<string>();
            foreach (var x in lista)
            {
                foreach (var y in x)
                {
                    lista1.Add(y.Tipo.nombre);
                    break;
                }
            }
            return lista1;
        }

        public IList<Recurso> VinculadasRecurso(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            
            List<Recurso>  lista = new List<Recurso>();

            if(tipo == 1)
            {   
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderBy(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderByDescending(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderBy(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderByDescending(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderBy(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .OrderByDescending(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else
                {
                    lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.id == int.Parse(filtro))
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                }
            }
            else if(tipo == 2)
            {   
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderBy(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderByDescending(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderBy(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderByDescending(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderBy(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .OrderByDescending(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else
                {
                    lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.nombre.Contains(filtro))
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                }
            }
            else if(tipo == 3)
            {   
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.Tipo.nombre == filtro )
                                                        .OrderBy(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.Tipo.nombre == filtro )
                                                        .OrderByDescending(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.Tipo.nombre == filtro )
                                                        .OrderBy(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.Tipo.nombre == filtro )
                                                        .OrderByDescending(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .OrderBy(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.Tipo.nombre == filtro)
                                                        .OrderByDescending(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else
                {
                    lista = this.context.Recursos
                                                        
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id) && s.Tipo.nombre == filtro )
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                }
            }
            else
            {   
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)                        
                                                        .Where(s => vinculadas.Contains(s.id))
                                                        .OrderBy(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)                        
                                                        .Where(s => vinculadas.Contains(s.id) )
                                                        .OrderByDescending(s => s.id)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id))
                                                        .OrderBy(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id))
                                                        .OrderByDescending(s => s.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id))
                                                        .OrderBy(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id))
                                                        .OrderByDescending(s => s.Tipo.nombre)
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                    }
                }
                else
                {
                    lista = this.context.Recursos
                                                        .Include(s => s.Tipo)
                                                        .Where(s => vinculadas.Contains(s.id))
                                                        .Skip((page - 1) * size)
                                                        .Take(size)
                                                        .ToList();
                }
            }
            return lista;
        }

        public long VincularRecursoTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            long  lista = 0;

            if(tipo == 1)
            {
                lista = this.context.Recursos
                                        .Count(s => !vinculadas.Contains(s.id) && s.id == int.Parse(filtro));
                                        
            }
            else if(tipo == 2)
            {
                lista = this.context.Recursos
                                        .Count(s => !vinculadas.Contains(s.id) &&  s.nombre.Contains(filtro));
            }
            else if(tipo == 3)
            {
                lista = this.context.Recursos
                                        .Include(s => s.Tipo)
                                        .Count(s => !vinculadas.Contains(s.id) && s.Tipo.nombre == filtro);
            }
            else
            {
                lista = this.context.Recursos
                                        .Count(s => !vinculadas.Contains(s.id));
            }
            return lista;
        }

        public long VinculadasRecursoTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            
            long  lista = 0;

            if(tipo == 1)
            {
                lista = this.context.Recursos
                                        .Count(s => vinculadas.Contains(s.id) && s.id == int.Parse(filtro));
                                        
            }
            else if(tipo == 2)
            {
                lista = this.context.Recursos
                                        .Count(s => vinculadas.Contains(s.id) &&  s.nombre.Contains(filtro));
            }
            else if(tipo == 3)
            {
                lista = this.context.Recursos
                                        .Include(s => s.Tipo)
                                        .Count(s => vinculadas.Contains(s.id) && s.Tipo.nombre == filtro);
            }
            else
            {
                lista = this.context.Recursos
                                        .Count(s => vinculadas.Contains(s.id));
            }

            return lista;
        }

        public IList<PPT> VinculadasPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => int.Parse(s.elementoId)).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return PPTs;
        }

        public IList<PPT> VincularPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => int.Parse(s.elementoId)).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => !vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return PPTs;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();           

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .OrderBy(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .OrderByDescending(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .OrderBy(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .OrderByDescending(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                }

            }
            else if(tipo == 2)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .OrderBy(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .OrderByDescending(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .OrderBy(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .OrderByDescending(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                }
            }
            else
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .OrderBy(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .OrderByDescending(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .OrderBy(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .OrderByDescending(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                }
            }                 
            
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();

            List<SedeElectronica> sedeElectronicas = new List<SedeElectronica>();
            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .OrderBy(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .OrderByDescending(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .OrderBy(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .OrderByDescending(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else
                {
                    sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                }

            }
            else if(tipo == 2)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .OrderBy(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .OrderByDescending(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .OrderBy(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .OrderByDescending(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else
                {
                    sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                }
            }
            else
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .OrderBy(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .OrderByDescending(s => s.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .OrderBy(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                    else
                    {
                        sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .OrderByDescending(s => s.nombre)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                    }
                }
                else
                {
                    sedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                                                        .Skip((page - 1) * size)
                                                                                                        .Take(size)
                                                                                                        .ToList();
                }
            }                     

            return sedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id).ToList();
            return SedeElectronicas;
        }

        public long VincularSedeElectronicaTotal(int id, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            
            long SedeElectronicasNumero = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                SedeElectronicasNumero = this.context.SedeElectronicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                SedeElectronicasNumero = this.context.SedeElectronicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro));
            }
            else
            {
                SedeElectronicasNumero = this.context.SedeElectronicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            }
            return SedeElectronicasNumero;
        }

        public long VincularSedeElectronicaTotal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            long SedeElectronicasNumero = this.context.SedeElectronicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            
            return SedeElectronicasNumero;
        }

        public long VinculadasSedeElectronicaTotal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            return SedeElectronicas;
        }

        public long VinculadasSedeElectronicaTotal(int id, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            long SedeElectronicasNumero = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                SedeElectronicasNumero = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                SedeElectronicasNumero = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro));
            }
            else
            {
                SedeElectronicasNumero = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            }
            return SedeElectronicasNumero;
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .OrderBy(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .OrderByDescending(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .OrderBy(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .OrderByDescending(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                }
            }
            else if(tipo == 2)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .OrderBy(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .OrderByDescending(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .OrderBy(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .OrderByDescending(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                }
            } 
            else
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .OrderBy(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .OrderByDescending(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .OrderBy(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .OrderByDescending(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                }
            }                 
            
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id).ToList();
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            
            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .OrderBy(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .OrderByDescending(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .OrderBy(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .OrderByDescending(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                }
            }
            else if(tipo == 2)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .OrderBy(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .OrderByDescending(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .OrderBy(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .OrderByDescending(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro))
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                }
            } 
            else
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .OrderBy(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .OrderByDescending(s => s.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .OrderBy(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                    else
                    {
                        VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .OrderByDescending(s => s.nombre)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                    }
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id)
                                                                        .Skip((page - 1) * size)
                                                                        .Take(size)
                                                                        .ToList();
                }
            }    
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id).ToList();
            return VentanillaUnicas;
        }

        public long VincularVentanillaUnicaTotal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            return VentanillaUnicas;
        }

        public long VincularVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            
            long VentanillaUnicasNumero = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);                
                VentanillaUnicasNumero = this.context.VentanillaUnicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                VentanillaUnicasNumero = this.context.VentanillaUnicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro));
            }
            else
            {
                VentanillaUnicasNumero = this.context.VentanillaUnicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            }

            return VentanillaUnicasNumero;
        }

        public long VinculadasVentanillaUnicaTotal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id ).Select(s => int.Parse(s.elementoId)).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => vinculadas.Contains(s.id) );
            return VentanillaUnicas;
        }

        public long VinculadasVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id ).Select(s => int.Parse(s.elementoId)).ToList();
            
            long VentanillaUnicasNumero = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);                
                VentanillaUnicasNumero = this.context.VentanillaUnicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                VentanillaUnicasNumero = this.context.VentanillaUnicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id && s.nombre.Contains(filtro));
            }
            else
            {
                VentanillaUnicasNumero = this.context.VentanillaUnicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == this.activo.id);
            }

            return VentanillaUnicasNumero;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();            

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro)
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro)
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro)
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro)
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                }
            }
            else if(tipo == 2)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro))
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro))
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro))
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro))
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro))
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                }
            }
            else
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO")
                                                                                            .OrderBy(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO")
                                                                                            .OrderByDescending(s => s.id)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO")
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO")
                                                                                            .OrderByDescending(s => s.nombre)
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                    }
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO")
                                                                                            .Skip((page - 1) * size)
                                                                                            .Take(size)                
                                                                                            .ToList();
                }
            }                                   
            
            return TramiteServicios;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) ).ToList();
            return TramiteServicios;
        }
        

        public IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            

            if(tipo == 1)
            {                
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro ).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro ).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro ).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro ).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                    }
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro ).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(tipo == 2)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro) ).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro) ).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro) ).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro) ).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                    }
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro) ).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" ).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" ).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" ).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                    }
                    else
                    {
                        TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" ).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                    }
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" ).Skip((page - 1) * size).Take(size).ToList();
                }
            }                  

            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" ).ToList();
            return TramiteServicios;
        }

        public long VincularTramiteServicioTotal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO");
            return TramiteServicios;
        }

        public long VincularTramiteServicioTotal(int id, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            long TramiteServiciosNumero = 0;
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            

            if(tipo == 1)
            {
                TramiteServiciosNumero = this.context.TramiteServicios.Count(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro );
            }
            else if(tipo == 2)
            {
                TramiteServiciosNumero = this.context.TramiteServicios.Count(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro) );
            }
            else
            {
                TramiteServiciosNumero = this.context.TramiteServicios.Count(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" );
            }
            return TramiteServiciosNumero;
        }

        public long VinculadasTramiteServicioTotal(int id)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO");
            return TramiteServicios;
        }

        public long VinculadasTramiteServicioTotal(int id, int tipo, string filtro)
        {
            var elemento = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            long TramiteServiciosNumero = 0;
            if(tipo == 1)
            {
                TramiteServiciosNumero = this.context.TramiteServicios.Count(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.id == filtro );
            }
            else if(tipo == 2)
            {
                TramiteServiciosNumero = this.context.TramiteServicios.Count(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" && s.nombre.Contains(filtro) );
            }
            else
            {
                TramiteServiciosNumero = this.context.TramiteServicios.Count(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO" );
            }
            return TramiteServiciosNumero;
        }

        public IList<ElementosUnion> TodosElementos(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            Console.WriteLine("Enytramos");
            //Elementos
            var elemento1 = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var elemento2 = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var elemento4 = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();


            var paginado = (page - 1) * size;
            Console.WriteLine(paginado);
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento1.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 1, estado = s.codigoEstado.ToString(), url = s.sedeElectronicaUrl, entidad = "" })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento2.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 2, estado = s.codigoEstado.ToString(), url = s.dominio, entidad = "" })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.estadoCodigo, url = "No hay", entidad = s.institucionNombre })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento4.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 4, estado = s.codigoEstado.ToString(), url = "No hay", entidad = "" })
                                                                .ToList();

            var vinculadas4 = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            var Recursos = this.context.Recursos.Where(s => vinculadas4.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 5, estado = s.codigoEstado.ToString(), url = "No hay", entidad = "" })
                                                                .ToList();

            var vinculadas5 = this.context.CategoriaCtgSuits.Where(s => s.idCategoria == id && s.codigoEstado == this.activo.id).Select(s => s.idCategoriaSuit).ToList();
            var TramiteServicios1 = this.context.TramiteServicios.Where(s => vinculadas5.Contains(s.CategoriaSuit) && !vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 6, estado = s.estadoCodigo, url = "No hay", entidad = s.institucionNombre  })
                                                                .ToList();

            List<ElementosUnion> Union = new List<ElementosUnion>();

            var union = SedeElectronicas.Union(VentanillaUnicas);

            union = union.Union(PortalTransversals);

            union = union.Union(Recursos);            

            union = union.Union(TramiteServicios);

            union = union.Union(TramiteServicios1);

            if(tipo == 1)
            {
                if( orden == 1 )
                {
                    if(!ascd)
                    {
                        union = union.Where(s => s.nombre.Contains(filtro)).OrderBy(s => s.id).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.Where(s => s.nombre.Contains(filtro)).OrderByDescending(s => s.id).Skip(paginado).Take(size).ToList();
                    }
                }
                else if( orden == 2 ) 
                {
                    if(!ascd)
                    {
                        union = union.Where(s => s.nombre.Contains(filtro)).OrderBy(s => s.tipo).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.Where(s => s.nombre.Contains(filtro)).OrderByDescending(s => s.tipo).Skip(paginado).Take(size).ToList();
                    }
                }
                else if( orden == 3 ) 
                {
                    if(!ascd)
                    {
                        union = union.Where(s => s.nombre.Contains(filtro)).OrderBy(s => s.nombre).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.Where(s => s.nombre.Contains(filtro)).OrderByDescending(s => s.nombre).Skip(paginado).Take(size).ToList();
                    }
                }
                else
                {
                    union = union.Where(s => s.nombre.Contains(filtro)).Skip(paginado).Take(size).ToList();
                }
            }
            else if(tipo == 2)
            {
                if( orden == 1 )
                {
                    if(!ascd)
                    {
                        union = union.Where(s => s.tipo == int.Parse(filtro)).OrderBy(s => s.id).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.Where(s => s.tipo == int.Parse(filtro)).OrderByDescending(s => s.id).Skip(paginado).Take(size).ToList();
                    }
                }
                else if( orden == 2 ) 
                {
                    if(!ascd)
                    {
                        union = union.Where(s => s.tipo == int.Parse(filtro)).OrderBy(s => s.tipo).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.Where(s => s.tipo == int.Parse(filtro)).OrderByDescending(s => s.tipo).Skip(paginado).Take(size).ToList();
                    }
                }
                else if( orden == 3 ) 
                {
                    if(!ascd)
                    {
                        union = union.Where(s => s.tipo == int.Parse(filtro)).OrderBy(s => s.nombre).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.Where(s => s.tipo == int.Parse(filtro)).OrderByDescending(s => s.nombre).Skip(paginado).Take(size).ToList();
                    }
                }
                else
                {
                    union = union.Where(s => s.tipo == int.Parse(filtro)).Skip(paginado).Take(size).ToList();
                }
            }
            else
            {
                if( orden == 1 )
                {
                    if(!ascd)
                    {
                        union = union.OrderBy(s => s.id).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.OrderByDescending(s => s.id).Skip(paginado).Take(size).ToList();
                    }
                }
                else if( orden == 2 ) 
                {
                    if(!ascd)
                    {
                        union = union.OrderBy(s => s.tipo).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.OrderByDescending(s => s.tipo).Skip(paginado).Take(size).ToList();
                    }
                }
                else if( orden == 3 ) 
                {
                    if(!ascd)
                    {
                        union = union.OrderBy(s => s.nombre).Skip(paginado).Take(size).ToList();
                    }
                    else
                    {
                        union = union.OrderByDescending(s => s.nombre).Skip(paginado).Take(size).ToList();
                    }
                }
                else
                {
                    union = union.Skip(paginado).Take(size).ToList();
                }
            }
            

            foreach (var item in union)
            {
                Union.Add(new ElementosUnion() {
                    id = item.id, 
                    nombre = item.nombre, 
                    tipo = item.tipo ,
                    estado = item.estado,
                    url = item.url,
                    entidad = item.entidad
                });
            }
            return Union;
        }

        public IList<ElementosUnion> TodosElementos(int id)
        {

            //Elementos
            var elemento1 = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var elemento2 = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var elemento4 = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();


            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento1.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 1, estado = s.codigoEstado.ToString(), url = s.sedeElectronicaUrl, entidad = "no hay"})
                                                                .ToList();

            var vinculadas1 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento2.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 2, estado = s.codigoEstado.ToString(), url = s.dominio, entidad = "no hay" })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.estadoCodigo, url = "No hay", entidad = s.institucionNombre })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento4.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 4, estado = s.codigoEstado.ToString(), url = "No hay", entidad = "no hay" })
                                                                .ToList();

            var vinculadas4 = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            var Recursos = this.context.Recursos.Where(s => vinculadas4.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 5, estado = s.codigoEstado.ToString(), url = "No hay", entidad = "no hay" })
                                                                .ToList();

            var vinculadas5 = this.context.CategoriaCtgSuits.Where(s => s.idCategoria == id && s.codigoEstado == this.activo.id).Select(s => s.idCategoriaSuit).ToList();
            var TramiteServicios1 = this.context.TramiteServicios.Where(s => vinculadas5.Contains(s.CategoriaSuit) && !vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 6, estado = s.estadoCodigo, url = "No hay", entidad = s.institucionNombre  })
                                                                .ToList();                                                    


            List<ElementosUnion> Union = new List<ElementosUnion>();

            var union = SedeElectronicas.Union(VentanillaUnicas);

            union = union.Union(PortalTransversals);

            union = union.Union(Recursos);

            union = union.Union(TramiteServicios);

            union = union.Union(TramiteServicios1);

            foreach (var item in union)
            {
                Union.Add(new ElementosUnion() {
                    id = item.id, 
                    nombre = item.nombre, 
                    tipo = item.tipo ,
                    estado = item.estado,
                    url = item.url,
                    entidad = item.entidad
                });
            }
            return Union;
        }

        public long totalTodos(int id, int tipo, string filtro)
        {
            //Elementos
            var elemento1 = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var elemento2 = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var elemento4 = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();


            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento1.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 1, estado = s.codigoEstado.ToString(), url = s.sedeElectronicaUrl, entidad = "no hay"})
                                                                .ToList();

            var vinculadas1 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento2.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 2, estado = s.codigoEstado.ToString(), url = s.dominio, entidad = "no hay" })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id).Select(s => s.elementoId).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.estadoCodigo, url = "No hay", entidad = s.institucionNombre })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == elemento4.id && s.codigoEstado == this.activo.id).Select(s => int.Parse(s.elementoId)).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 4, estado = s.codigoEstado.ToString(), url = "No hay", entidad = "no hay" })
                                                                .ToList();

            var vinculadas4 = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == this.activo.id).Select(s => s.idRecurso).ToList();
            var Recursos = this.context.Recursos.Where(s => vinculadas4.Contains(s.id))
                                                                .Select(s => new { id = s.id.ToString(), nombre = s.nombre, tipo = 5, estado = s.codigoEstado.ToString(), url = "No hay", entidad = "no hay" })
                                                                .ToList();

            var vinculadas5 = this.context.CategoriaCtgSuits.Where(s => s.idCategoria == id && s.codigoEstado == this.activo.id).Select(s => s.idCategoriaSuit).ToList();
            var TramiteServicios1 = this.context.TramiteServicios.Where(s => vinculadas5.Contains(s.CategoriaSuit) && !vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 6, estado = s.estadoCodigo, url = "No hay", entidad = s.institucionNombre  })
                                                                .ToList();   

            var union = SedeElectronicas.Union(VentanillaUnicas);
            long total = 0;

            union = union.Union(PortalTransversals);

            union = union.Union(Recursos);            

            union = union.Union(TramiteServicios);

            union = union.Union(TramiteServicios1);

            if(tipo == 1)
            {
                total = union.Count(s => s.nombre.Contains(filtro));
            }
            else if(tipo == 2)
            {
                total = union.Count(s => s.tipo == int.Parse(filtro));
            }
            else
            {
                 total = union.Count();
            }                                                  
            

            return (total);
        }

        public IList<string> AgruparTipoElemento(int id)
        {
            //Elementos
            var elemento1 = this.context.TipoElementos.Where(s => s.sigla == "SE").FirstOrDefault();
            var elemento2 = this.context.TipoElementos.Where(s => s.sigla == "VU").FirstOrDefault();
            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();
            var elemento4 = this.context.TipoElementos.Where(s => s.sigla == "PT").FirstOrDefault();

            var vinculadas = this.context.ElementoCategorias.Count(s => s.categoriaId == id && s.tipoElementoId == elemento1.id && s.codigoEstado == this.activo.id);

            var vinculadas1 = this.context.ElementoCategorias.Count(s => s.categoriaId == id && s.tipoElementoId == elemento2.id && s.codigoEstado == this.activo.id);

            var vinculadas2 = this.context.ElementoCategorias.Count(s => s.categoriaId == id && s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id);

            var vinculadas3 = this.context.ElementoCategorias.Count(s => s.categoriaId == id && s.tipoElementoId == elemento4.id && s.codigoEstado == this.activo.id);

            var vinculadas4 = this.context.VncCategoriaRecursos.Count(s => s.idCtg == id && s.codigoEstado == this.activo.id);

            var vinculadas5 = this.context.CategoriaCtgSuits.Count(s => s.idCategoria == id && s.codigoEstado == this.activo.id); 

            int[] datos = new int[6];
            List<string> grupo = new List<String>();
            string[] lista = new string[6];

            lista[0] = "Portal Transversal";
            lista[1] = "Recurso";
            lista[2] = "Sede Electronica";
            lista[3] = "Tramites y Servicios";            
            lista[4] = "Tramites y Servicios Suit 3";
            lista[5] = "Ventanilla Unica";
            
            datos[0] = vinculadas3;
            datos[1] = vinculadas4;
            datos[2] = vinculadas;
            datos[3] = vinculadas2;            
            datos[4] = vinculadas5;
            datos[5] = vinculadas1;
            

            for (int i = 0; i < 6; i++)
            {
                if(datos[i] > 0)
                    grupo.Add(lista[i]);
            }

            return grupo;
        }
    }
}