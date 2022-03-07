using Categorias.Domain.Models;
using Categorias.Domain.Data;
using Categorias.Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Categorias.Domain.Repository
{
    public class RepositoryVncCategoriaRecurso : InterfaceVncCategoriaRecurso<VncCategoriaRecurso>
    {
        protected readonly Context context;
        

        public RepositoryVncCategoriaRecurso(Context context)
        {
            this.context = context;
        }

        public IList<VncCategoriaRecurso> All()
        {
            return this.context.VncCategoriaRecursos.ToList();
        }

        public void Add(VncCategoriaRecurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncCategoriaRecursos.Add(objeto);
        }

        public VncCategoriaRecurso GetId(int id)
        {
            return this.context.VncCategoriaRecursos.Where(s => s.id == id).FirstOrDefault();
        }

        public VncCategoriaRecurso GetIdPadre(int id, int padre)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            
            return this.context.VncCategoriaRecursos.Where(s => s.idRecurso == id && s.idCtg == padre && s.codigoEstado == activo.id).FirstOrDefault();
        }

        public long getTotalId(int id)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();

            return this.context.VncCategoriaRecursos.Count(s => s.idCtg == id && s.codigoEstado == activo.id);
        }

        public void Estado(int id)
        {
            
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            Estado inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();

            VncCategoriaRecurso objeto = this.context.VncCategoriaRecursos.Where(s => s.id == id).FirstOrDefault();

            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            if(objeto.codigoEstado == activo.id)
                objeto.codigoEstado = inactivo.id;
            else
                objeto.codigoEstado = activo.id;

            this.context.VncCategoriaRecursos.Update(objeto);
        }
    }
}