using System;
using System.Collections.Generic;
using Categorias.Domain.Repository.Interface;
using Categorias.Domain.Models;
using Categorias.Domain.Data;
using System.Linq;


namespace Categorias.Domain.Repository
{
    public class RepositoryCategoriaSUIT : InterfaceCategoriaSUIT<CategoriaSUIT>
    {
        private readonly Context context;
        public RepositoryCategoriaSUIT(Context context)
        {
            this.context = context;
        }

        public IList<CategoriaSUIT> All()
        {
            return this.context.CategoriaSUITs.Where(s => s.id != 0).ToList();
        }

        public CategoriaSUIT GetId(int id)
        {
            return context.CategoriaSUITs.Where(s => s.id == id).FirstOrDefault();
        }
    }
}