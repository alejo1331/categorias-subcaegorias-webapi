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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                                 
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                          
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                     
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                           
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                             
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                                
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))                            
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
                                        .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))  
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                            
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                          
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                           
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                             
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)                              
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
                                        .Include( s => s.usuarioObj)
                                        .ThenInclude(uo => uo.PersonaNatural)
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
                                .Include( s => s.usuarioObj)
                                .ThenInclude(uo => uo.PersonaNatural)                             
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
                                    .Include(s => s.usuarioObj)
                                    .ThenInclude(uo => uo.PersonaNatural)
                                    .Where(s => s.usuarioObj.PersonaNatural.PrimerNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoNombre.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.PrimerApellido.Contains(filtro)||
                                                    s.usuarioObj.PersonaNatural.SegundoApellido.Contains(filtro)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerNombre+" "+s.usuarioObj.PersonaNatural.SegundoNombre) ||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.SegundoNombre+" "+s.usuarioObj.PersonaNatural.PrimerApellido)||
                                                    filtro.Contains(s.usuarioObj.PersonaNatural.PrimerApellido+" "+s.usuarioObj.PersonaNatural.SegundoApellido))
                                    .Count();
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

        public long Total()
        {
            long listaNUmero = 0;            
            listaNUmero = this.context.Bitacoras.Count(); 
            return listaNUmero;
        }

        public void Add(Bitacora objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Bitacoras.Add(objeto);
        }

        public void Remove(DateTime fechaInicio)
        {
            List<Bitacora> lista = this.context.Bitacoras.Where(s => s.fechaModificacion >= fechaInicio).ToList();

            foreach (var item in lista)
            {
                this.context.Bitacoras.Remove(item);
            }
        }

        public Bitacora GetId(int id)
        {
            return context.Bitacoras.Include( s => s.usuarioObj)
                                    .ThenInclude(uo => uo.PersonaNatural)
                                    .Where(s => s.id == id).
                                    FirstOrDefault();
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