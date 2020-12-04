using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryTramiteServicio : InterfaceTramiteServicio<TramiteServicio>
    {
        private readonly Context context;
        private Estado activo;
        private Estado inactivo;

        public RepositoryTramiteServicio(Context context)
        {
            this.context = context;
            this.activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            this.inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();
        }

        public IList<TramiteServicio> All()
        {
            return this.context.TramiteServicios.ToList();
        }

        public TramiteServicio GetId(string id)
        {
            return context.TramiteServicios.Where(s => s.id == id).FirstOrDefault();
        }

        public IList<TramiteServicio> ListaTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal)
        {
            List<TramiteServicio> Lista = new List<TramiteServicio>();

            if(fehcaIncial != null && fechaFinal != null)
            {
                Lista = context.TramiteServicios.Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal).ToList();
                    
            }
            else
            {
                Lista = context.TramiteServicios.Where(s => s.fechaModificacion >= fehcaIncial).ToList();
            }

            return Lista;
        }

        public IList<TramiteServicio> ListaTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var paginado = (page - 1) * size;
            List<TramiteServicio> Lista = new List<TramiteServicio>();

            if(fehcaIncial != null && fechaFinal != null)
            {                
                if(tipo == 1)
                {                    
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro)
                                .Skip(paginado)
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
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro))
                                .Skip(paginado)
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
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                    }
                }
                else if(tipo == 4)
                {
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro))
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                    }
                }
                else if(tipo == 5)
                {
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro))
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                    }
                }
                else if(tipo == 6)
                {
                    
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro))
                                .Skip(paginado)
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
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                    }
                }
                    
            }
            else
            {
                
                if(tipo == 1)
                {                    
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.id == filtro)
                                .Skip(paginado)
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
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.nombre.Contains(filtro))
                                .Skip(paginado)
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
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionId == filtro)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                    }
                }
                else if(tipo == 4)
                {
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.institucionNombre.Contains(filtro))
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                    }
                }
                else if(tipo == 5)
                {
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaCreacion >= DateTime.Parse(filtro))
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                    }
                }
                else if(tipo == 6)
                {
                    
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial  && s.fechaModificacion >= DateTime.Parse(filtro))
                                .Skip(paginado)
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
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderBy(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderByDescending(s => s.id)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 2)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderBy(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderByDescending(s => s.nombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 3)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderBy(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderByDescending(s => s.institucionId)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 4)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderBy(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderByDescending(s => s.institucionNombre)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 5)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderBy(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderByDescending(s => s.fechaCreacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else if(orden == 6)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderBy(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                                
                        }
                        else
                        {
                            Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .OrderByDescending(s => s.fechaModificacion)
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                        }
                    }
                    else
                    {
                        Lista = context.TramiteServicios
                                .Where(s => s.fechaModificacion >= fehcaIncial )
                                .Skip(paginado)
                                .Take(size)
                                .ToList();
                    }
                }
            } 

            
            return Lista;
        }

        public long TotalTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal, int tipo, string filtro)
        {
            long total = 0;

            if(fehcaIncial != null && fechaFinal != null)
            {                
                if(tipo == 1)
                {                    
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.id == filtro);
                }
                else if(tipo == 2)
                {
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.nombre.Contains(filtro));
                }
                else if(tipo == 3)
                {
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionId == filtro);
                }
                else if(tipo == 4)
                {
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.institucionNombre.Contains(filtro));
                }
                else if(tipo == 5)
                {
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaCreacion >= DateTime.Parse(filtro));
                }
                else if(tipo == 6)
                {
                    
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal && s.fechaModificacion >= DateTime.Parse(filtro));
                }
                else
                {
                    total = context.TramiteServicios
                        .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion <= fechaFinal);                    
                }
                    
            }
            else
            {                
                if(tipo == 1)
                {                    
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.id == filtro);
                }
                else if(tipo == 2)
                {
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.nombre.Contains(filtro));
                }
                else if(tipo == 3)
                {
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.institucionId == filtro);
                }
                else if(tipo == 4)
                {
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.institucionNombre.Contains(filtro));
                }
                else if(tipo == 5)
                {
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaCreacion >= DateTime.Parse(filtro));
                }
                else if(tipo == 6)
                {
                    
                    total = context.TramiteServicios
                                .Count(s => s.fechaModificacion >= fehcaIncial && s.fechaModificacion >= DateTime.Parse(filtro));
                }
                else
                {
                    total = context.TramiteServicios
                        .Count(s => s.fechaModificacion >= fehcaIncial);                    
                }   
            }

            return total;
        }

        public IList<ParametrosUnion> ListaParametros(string id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var paginado = (page - 1) * size;

            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<ParametrosUnion> Union = new List<ParametrosUnion>();
            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel).ToList();

            if(tipo == 2)
            {
                union = union.Where(s => s.tipo == 2).ToList();
            }
            else if(tipo == 3)
            {
                union = union.Where(s => s.tipo == 3).ToList();
            }
            else if(tipo == 4)
            {
                union = union.Where(s => s.tipo == 4).ToList();
            }

            //Filtro por Activo/Inactivo
            if(filtro == "1")
            {
                union = union.Where(s => s.estado == this.activo.id).ToList();
            }
            else if(filtro == "2")
            {
                union = union.Where(s => s.estado == this.inactivo.id).ToList();
            }

            if(orden == 1)
            {
                if(!ascd)
                {
                    union = union.OrderBy(s => s.orden).Skip(paginado).Take(size).ToList();
                }
                else
                {
                    union = union.OrderByDescending(s => s.orden).Skip(paginado).Take(size).ToList();
                }
            }
            else if(orden == 2)
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
            else
            {
                union = union.Skip(paginado).Take(size).ToList();
            }  

            foreach (var item in union)
            {
                Union.Add(new ParametrosUnion(){
                    id = item.id,
                    nombre = item.nombre,
                    tipo = item.tipo,
                    orden = item.orden,
                    estado = item.estado,
                    descripcion = item.descripcion
                });
            }

            return Union;
        }

        public IList<ParametrosUnion> ListaParametros(string id)
        {

            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<ParametrosUnion> Union = new List<ParametrosUnion>();
            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel).ToList();            

            foreach (var item in union)
            {
                Union.Add(new ParametrosUnion(){
                    id = item.id,
                    nombre = item.nombre,
                    tipo = item.tipo,
                    orden = item.orden,
                    estado = item.estado,
                    descripcion = item.descripcion
                });
            }

            return Union;
        }

        public IList<string> AgruparEstado(string id)
        {
            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<String> lista = new List<string>();

            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel);
            var sql = union.ToList().GroupBy(s => s.estado);
            foreach (var item in sql)
            {
                foreach (var x in item)
                {
                    if(x.estado == 1)
                        lista.Add("Activo");
                    else 
                        lista.Add("Inactivo");

                    break;
                }
            }
            

            return lista;
        }

        public IList<string> AgruparTipo(string id)
        {
            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<String> lista = new List<string>();

            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel);
            var sql = union.ToList().GroupBy(s => s.tipo);
            foreach (var item in sql)
            {
                foreach (var x in item)
                {
                    if(x.tipo == 2)
                        lista.Add("Categoria");
                    else if(x.tipo == 3)
                        lista.Add("Subcategoria");
                    else if(x.tipo == 4)
                        lista.Add("Tercer Nivel");

                    break;
                }
            }            

            return lista;
        }

        public long ListaParametrosTotal(string id)
        {
            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            long categorias = this.context.Categorias.Count(s => vinculos.Contains(s.id));
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            long subcategorias = this.context.Subcategorias.Count(s => vinculos1.Contains(s.id));

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            long tercerNivel = this.context.TercerNivels.Count(s => vinculos2.Contains(s.id));

            return (categorias + subcategorias + tercerNivel);
        }

        public long ListaParametrosTotal(string id, int tipo, string filtro)
        {
            var elemento3 = this.context.TipoElementos.Where(s => s.sigla == "TS").FirstOrDefault();

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == elemento3.id && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<ParametrosUnion> Union = new List<ParametrosUnion>();
            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel).ToList();

            if(tipo == 2)
            {
                union = union.Where(s => s.tipo == 2).ToList();
            }
            else if(tipo == 3)
            {
                union = union.Where(s => s.tipo == 3).ToList();
            }
            else if(tipo == 4)
            {
                union = union.Where(s => s.tipo == 4).ToList();
            }

            //Filtro por Activo/Inactivo
            if(filtro == "1")
            {
                union = union.Where(s => s.estado == this.activo.id).ToList();
            }
            else if(filtro == "2")
            {
                union = union.Where(s => s.estado == this.inactivo.id).ToList();
            }           

            return union.Count();
        }

        public IList<TramiteServicio> ListaTramitesServicios(int page, int size, int orden, bool ascd,string filtro, int tipo)
        {
            var paginado = (page - 1) * size;
            List<TramiteServicio> Lista = new List<TramiteServicio>();

            
            if(tipo == 1)
            {
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        Lista = context.TramiteServicios.Where(s => s.id == filtro)
                                    .OrderBy(s => s.id)
                                    .Skip(paginado)
                                    .Take(size)
                                    .ToList();
                    }
                    else
                    {
                        Lista = context.TramiteServicios.Where(s => s.id == filtro)
                                    .OrderByDescending(s => s.id)
                                    .Skip(paginado)
                                    .Take(size)
                                    .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(orden == 1)
                    {
                        if(!ascd)
                        {
                            Lista = context.TramiteServicios.Where(s => s.id == filtro)
                                        .OrderBy(s => s.nombre)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                        }
                        else
                        {
                            Lista = context.TramiteServicios.Where(s => s.id == filtro)
                                        .OrderByDescending(s => s.nombre)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                        }
                    }
                }
                else
                {
                    Lista = context.TramiteServicios.Where(s => s.id == filtro)
                                        .Skip(paginado)
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
                        Lista = context.TramiteServicios.Where(s => s.nombre.Contains(filtro))
                                    .OrderBy(s => s.id)
                                    .Skip(paginado)
                                    .Take(size)
                                    .ToList();
                    }
                    else
                    {
                        Lista = context.TramiteServicios.Where(s => s.nombre.Contains(filtro))
                                    .OrderByDescending(s => s.id)
                                    .Skip(paginado)
                                    .Take(size)
                                    .ToList();
                    }
                }
                else if(orden == 2)
                {
                    if(!ascd)
                    {
                        Lista = context.TramiteServicios.Where(s => s.nombre.Contains(filtro))
                                        .OrderBy(s => s.nombre)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                            Lista = context.TramiteServicios.Where(s => s.nombre.Contains(filtro))
                                        .OrderByDescending(s => s.nombre)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else
                {
                    Lista = context.TramiteServicios.Where(s => s.nombre.Contains(filtro))
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                }
            }

            return Lista;
        }

        public long TotalTramitesServicios( int tipo, string filtro)
        {
            List<TramiteServicio> Lista = new List<TramiteServicio>();

            
            if(tipo == 1)
            {
                Lista = context.TramiteServicios.Where(s => s.id == filtro).ToList();
            }
            else if(tipo == 2)
            {
                Lista = context.TramiteServicios.Where(s => s.nombre.Contains(filtro)).ToList();
            }
            

            return Lista.Count();
        }
        
    }
}