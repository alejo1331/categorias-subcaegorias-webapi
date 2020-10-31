using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryPPT : InterfacePPT<PPT>
    {
        private readonly Context context;
        public RepositoryPPT(Context context)
        {
            this.context = context;
        }

        public IList<PPT> All()
        {
            return this.context.PPTs.ToList();
        }

        public PPT GetId(int id)
        {
            return context.PPTs.Where(s => s.id == id).FirstOrDefault();
        }
    }
}