using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryVentanillaUnica : InterfaceVentanillaUnica<VentanillaUnica>
    {
        private readonly Context context;
        public RepositoryVentanillaUnica(Context context)
        {
            this.context = context;
        }

        public IList<VentanillaUnica> All()
        {
            return this.context.VentanillaUnicas.ToList();
        }

        public VentanillaUnica GetId(int id)
        {
            return context.VentanillaUnicas.Where(s => s.id == id).FirstOrDefault();
        }
        
    }
}