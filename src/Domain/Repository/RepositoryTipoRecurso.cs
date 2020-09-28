using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository
{
    public class RepositoryTipoRecurso : InterfaceTipoRecurso<TipoRecurso>
    {
        protected readonly Context context;
        public RepositoryTipoRecurso(Context context)
        {
            this.context = context;
        }

        public IList<TipoRecurso> All(){
            return this.context.TipoRecursos.ToList();
        }

        public void Add(TipoRecurso objeto){
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TipoRecursos.Add(objeto);
        }

        public TipoRecurso GetId(int id){
            return this.context.TipoRecursos.Where(s => s.id == id).FirstOrDefault();
        }
    }
}