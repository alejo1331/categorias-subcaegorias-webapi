using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;



namespace Domain.Repository
{
    public class RepositoryVncSubcategoriaRecurso : InterfaceVncSubcategoriaRecurso<VncSubcategoriaRecurso>
    {
        protected readonly Context context;
        public RepositoryVncSubcategoriaRecurso(Context context)
        {
            this.context = context;
        }

        public IList<VncSubcategoriaRecurso> All()
        {
            return this.context.VncSubcategoriaRecursos.ToList();
        }

        public void Add(VncSubcategoriaRecurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncSubcategoriaRecursos.Add(objeto);
        }

        public VncSubcategoriaRecurso GetId(int id)
        {
            return this.context.VncSubcategoriaRecursos.Where(s => s.id == id).FirstOrDefault();
        }

        public VncSubcategoriaRecurso GetIdPadre(int id, int padre)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();

            return this.context.VncSubcategoriaRecursos.Where(s => s.idRecurso == id && s.idSubCtg == padre && s.codigoEstado == activo.id).FirstOrDefault();
        }

        public long GetTotalId(int id)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            return this.context.VncSubcategoriaRecursos.Count(s => s.idSubCtg == id && s.codigoEstado == activo.id);
        }

        public void Estado(int id)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            Estado inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();

            VncSubcategoriaRecurso objeto = this.context.VncSubcategoriaRecursos.Where(s => s.id == id).FirstOrDefault();

            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            if(objeto.codigoEstado == activo.id)
                objeto.codigoEstado = inactivo.id;
            else
                objeto.codigoEstado = activo.id;

            this.context.VncSubcategoriaRecursos.Update(objeto);
        }
    }
}