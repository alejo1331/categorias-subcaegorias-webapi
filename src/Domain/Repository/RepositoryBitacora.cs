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

        public IList<Bitacora> All(int page, int size, int orden, bool ascd)
        {
            var paginado = (page - 1) * size;
            List<Bitacora> lista = this.context.Bitacoras 
                                .Include(s => s.TipoParametro)
                                .Include(s => s.TipoConfiguracion)                               
                                .ToList();

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.id).Skip(paginado).Take(size).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.id).Skip(paginado).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.Configuracion).Skip(paginado).Take(size).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.Configuracion).Skip(paginado).Take(size).ToList();
                }
            }
            else if(orden == 3)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.Parametro).Skip(paginado).Take(size).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.Parametro).Skip(paginado).Take(size).ToList();
                }
            }
            else if(orden == 4)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.fechaModificacion).Skip(paginado).Take(size).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.fechaModificacion).Skip(paginado).Take(size).ToList();
                }
            }
            else if(orden == 5)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.usuario).Skip(paginado).Take(size).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.usuario).Skip(paginado).Take(size).ToList();
                }
            }
            else 
                lista = lista.Skip(paginado).Take(size).ToList();
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

        public long Total()
        {
            long lista = this.context.Bitacoras.Count();
            return lista;
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
    }
}