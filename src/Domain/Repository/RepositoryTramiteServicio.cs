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
        public RepositoryTramiteServicio(Context context)
        {
            this.context = context;
        }

        public IList<TramiteServicio> All()
        {
            return this.context.TramiteServicios.ToList();
        }

        public TramiteServicio GetId(string id)
        {
            return context.TramiteServicios.Where(s => s.id == id).FirstOrDefault();
        }
        
    }
}