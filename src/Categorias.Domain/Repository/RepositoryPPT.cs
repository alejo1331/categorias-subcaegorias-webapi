using System;
using System.Collections.Generic;
using Categorias.Domain.Repository.Interface;
using Categorias.Domain.Models;
using Categorias.Domain.Data;
using System.Linq;


namespace Categorias.Domain.Repository
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