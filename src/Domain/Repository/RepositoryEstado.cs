using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
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
            this.context.Estados.Add(objeto);
        }

        public Estado GetId(int id)
        {
            return context.Estados.Where(s => s.id == id).FirstOrDefault();
        }
    }
}