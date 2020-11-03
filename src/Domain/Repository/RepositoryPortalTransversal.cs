using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryPortalTransversal : InterfacePortalTransversal<PortalTransversal>
    {
        private readonly Context context;
        public RepositoryPortalTransversal(Context context)
        {
            this.context = context;
        }

        public IList<PortalTransversal> All()
        {
            return this.context.PortalTransversals.ToList();
        }

        public PortalTransversal GetId(int id)
        {
            return context.PortalTransversals.Where(s => s.id == id).FirstOrDefault();
        }
    }
}