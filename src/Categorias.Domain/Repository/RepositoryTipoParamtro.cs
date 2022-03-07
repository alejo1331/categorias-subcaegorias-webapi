using Categorias.Domain.Models;
using Categorias.Domain.Data;
using Categorias.Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Categorias.Domain.Repository
{
    public class RepositoryTipoParamtro : InterfaceTipoParametro<TipoParametro>
    {
        protected readonly Context context;
        public RepositoryTipoParamtro(Context context)
        {
            this.context = context;
        }

        public IList<TipoParametro> All()
        {
            return this.context.TipoParametros.ToList();
        }

        public void Add(TipoParametro objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.TipoParametros.Add(objeto);
        }

        public TipoParametro GetId(int id)
        {
            return this.context.TipoParametros.Where(s => s.id == id).FirstOrDefault();
        }

        public void Update(TipoParametro objeto)
        {
            this.context.TipoParametros.Update(objeto);
        }

        public TipoParametro GetSigla(string sigla)
        {
            return this.context.TipoParametros.Where(s => s.sigla == sigla).FirstOrDefault();
        }
    }
}