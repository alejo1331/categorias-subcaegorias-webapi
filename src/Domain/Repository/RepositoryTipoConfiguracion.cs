using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryTipoConfiguracion : InterfaceTipoConfiguracion<TipoConfiguracion>
    {
        private readonly Context context;
        public RepositoryTipoConfiguracion(Context context)
        {
            this.context = context;
        }

        public IList<TipoConfiguracion> All()
        {
            return this.context.TipoConfiguracions.ToList();
        }

        public TipoConfiguracion GetId(int id)
        {
            return context.TipoConfiguracions.Where(s => s.id == id).FirstOrDefault();
        }

        public TipoConfiguracion GetSiglaId(string sigla)
        {
            return context.TipoConfiguracions.Where(s => s.sigla == sigla).FirstOrDefault();
        }
    }
}