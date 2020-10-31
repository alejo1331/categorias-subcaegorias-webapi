using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositorySedeElectronica : InterfaceSedeElectronica<SedeElectronica>
    {
        private readonly Context context;
        public RepositorySedeElectronica(Context context)
        {
            this.context = context;
        }

        public IList<SedeElectronica> All()
        {
            return this.context.SedeElectronicas.ToList();
        }

        public SedeElectronica GetId(int id)
        {
            return context.SedeElectronicas.Where(s => s.id == id).FirstOrDefault();
        }
        
    }
}