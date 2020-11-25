using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryTipoElemento : InterfaceTipoElemento<TipoElemento>
    {
        private readonly Context context;
        public RepositoryTipoElemento(Context context)
        {
            this.context = context;
        }

        public IList<TipoElemento> All()
        {
            return this.context.TipoElementos.ToList();
        }

        public TipoElemento GetId(int id)
        {
            return context.TipoElementos.Where(s => s.id == id).FirstOrDefault();
        }

        public TipoElemento GetSigla(string sigla)
        {
            return context.TipoElementos.Where(s => s.sigla == sigla).FirstOrDefault();
        }
        
    }
}