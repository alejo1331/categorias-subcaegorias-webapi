using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;

using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class RepositoryBitacora : InterfaceBitacora<Bitacora>
    {
        private readonly Context context;
        public RepositoryBitacora(Context context)
        {
            this.context = context;
        }

        public IList<Bitacora> All(int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            Console.WriteLine(filtro);
            var paginado = (page - 1) * size;
            List<Bitacora> lista = new List<Bitacora>();

            if(tipo == 1)
            {                 
                if(orden == 1)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderBy(s => s.id)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderBy(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderByDescending(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderBy(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderByDescending(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 4)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderBy(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderByDescending(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 5)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderBy(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro))                               
                                        .OrderByDescending(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else 
                {
                    lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.id == int.Parse(filtro)) 
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderBy(s => s.id)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderBy(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderByDescending(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderBy(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderByDescending(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 4)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderBy(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderByDescending(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 5)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderBy(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro))                               
                                        .OrderByDescending(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else 
                {
                    lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.fechaModificacion >= DateTime.Parse(filtro)) 
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderBy(s => s.id)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderBy(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderByDescending(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderBy(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderByDescending(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 4)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderBy(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderByDescending(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 5)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderBy(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro))                               
                                        .OrderByDescending(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else 
                {
                    lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.usuario == int.Parse(filtro)) 
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderBy(s => s.id)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderBy(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderByDescending(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderBy(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderByDescending(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 4)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderBy(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderByDescending(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 5)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderBy(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro)                               
                                        .OrderByDescending(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else 
                {
                    lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoConfiguracion.nombre == filtro) 
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderBy(s => s.id)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderBy(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderByDescending(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderBy(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderByDescending(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 4)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderBy(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderByDescending(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 5)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderBy(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro)                               
                                        .OrderByDescending(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else 
                {
                    lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Where(s => s.TipoParametro.nombre == filtro) 
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderBy(s => s.id)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
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
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderBy(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderByDescending(s => s.Configuracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 3)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderBy(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderByDescending(s => s.Parametro)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 4)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderBy(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderByDescending(s => s.fechaModificacion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else if(orden == 5)
                {
                    if(!ascd)
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderBy(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                    else
                    {
                        lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)                              
                                        .OrderByDescending(s => s.usuario)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                    }
                }
                else 
                {
                    lista = this.context.Bitacoras 
                                        .Include(s => s.TipoParametro)
                                        .Include(s => s.TipoConfiguracion)
                                        .Skip(paginado)
                                        .Take(size)
                                        .ToList();
                }
            }

            
            return lista;
        }

        public IList<Bitacora> All()
        {
            List<Bitacora> lista = this.context.Bitacoras 
                                .Include(s => s.TipoParametro)
                                .Include(s => s.TipoConfiguracion)                               
                                .ToList();
            return lista;
        }

        public long Total(int tipo, string filtro)
        {
            long listaNUmero = 0;

            if(tipo == 1)
            {
                listaNUmero = this.context.Bitacoras
                                    .Include(s => s.TipoParametro)
                                    .Include(s => s.TipoConfiguracion)
                                    .Count(s => s.id == int.Parse(filtro));  
            }
            else if(tipo == 2)
            {
                listaNUmero = this.context.Bitacoras
                                    .Include(s => s.TipoParametro)
                                    .Include(s => s.TipoConfiguracion)
                                    .Count(s => s.fechaModificacion >= DateTime.Parse(filtro));
            }
            else if(tipo == 3)
            {
                listaNUmero = this.context.Bitacoras
                                    .Include(s => s.TipoParametro)
                                    .Include(s => s.TipoConfiguracion)
                                    .Count(s => s.usuario == int.Parse(filtro));
            }
            else if(tipo == 4)
            {
                listaNUmero = this.context.Bitacoras
                                    .Include(s => s.TipoParametro)
                                    .Include(s => s.TipoConfiguracion)
                                    .Count(s => s.TipoConfiguracion.nombre == filtro);
            }
            else if(tipo == 5)
            {
                listaNUmero = this.context.Bitacoras
                                    .Include(s => s.TipoParametro)
                                    .Include(s => s.TipoConfiguracion)
                                    .Count(s => s.TipoParametro.nombre == filtro);
            }
            else
            {
                listaNUmero = this.context.Bitacoras
                                    .Include(s => s.TipoParametro)
                                    .Include(s => s.TipoConfiguracion)
                                    .Count();
            }

            return listaNUmero;
        }

        public void Add(Bitacora objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Bitacoras.Add(objeto);
        }

        public Bitacora GetId(int id)
        {
            return context.Bitacoras.Where(s => s.id == id).FirstOrDefault();
        }

        public IList<string> AgruparTipoConfiguracion()
        {
            List<String> lista1 = new List<string>();

            var sql = this.context.Bitacoras.Include(s => s.TipoConfiguracion).OrderBy(x => x.TipoConfiguracion.nombre).ToList().GroupBy(x => x.TipoConfiguracion.nombre);
            foreach (var x in sql)
            {
                foreach (var y in x)
                {
                    lista1.Add(y.TipoConfiguracion.nombre);
                    break;
                }
            }
            return lista1;
        }

        public IList<string> AgruparTipoParametro()
        {
            List<String> lista1 = new List<string>();

            var sql = this.context.Bitacoras.Include(s => s.TipoParametro).OrderBy(x => x.TipoParametro.nombre).ToList().GroupBy(x => x.TipoParametro.nombre);
            foreach (var x in sql)
            {
                foreach (var y in x)
                {
                    lista1.Add(y.TipoParametro.nombre);
                    break;
                }
            }
            return lista1;
        }
    }
}