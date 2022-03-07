using Categorias.Domain.Models;
using Categorias.Domain.Data;
using Categorias.Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Categorias.Domain.Repository
{
    public class RepositoryTipoRecurso : InterfaceTipoRecurso<TipoRecurso>
    {
        protected readonly Context context;
        public RepositoryTipoRecurso(Context context)
        {
            this.context = context;
        }

        public IList<TipoRecurso> All(){
            return this.context.TipoRecursos.Where(s => s.codigoEstado == 1).ToList();
        }

        public void Add(TipoRecurso objeto){
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TipoRecursos.Add(objeto);
        }

        public TipoRecurso GetId(int id){
            return this.context.TipoRecursos.Where(s => s.id == id).FirstOrDefault();
        }

        public TipoRecurso GetSigla(string sigla)
        {
            return this.context.TipoRecursos.Where(s => s.siglas == sigla).FirstOrDefault();
        }
    }
}