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

        public IList<Bitacora> All(int page, int size)
        {
            var paginado = (page - 1) * size;
            List<Bitacora> lista = this.context.Bitacoras 
                                .Include(s => s.TipoParametro)
                                .Include(s => s.TipoConfiguracion)                               
                                .ToList();
            
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