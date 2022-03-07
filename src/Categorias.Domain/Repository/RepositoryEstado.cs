using System;
using System.Collections.Generic;
using Categorias.Domain.Repository.Interface;
using Categorias.Domain.Models;
using Categorias.Domain.Data;
using System.Linq;


namespace Categorias.Domain.Repository
{
    public class RepositoryEstado : InterfaceEstado<Estado>
    {
        private readonly Context context;
        public RepositoryEstado(Context context)
        {
            this.context = context;
        }

        public IList<Estado> All()
        {
            return this.context.Estados.ToList();
        }

        public void Add(Estado objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.Estados.Add(objeto);
        }

        public Estado GetId(int id)
        {
            return context.Estados.Where(s => s.id == id).FirstOrDefault();
        }

        public Estado GetDescripcion(string texto)
        {
            return context.Estados.Where(s => s.descripcion == texto).FirstOrDefault();
        }
    }
}