using Domain.Models;
using Domain.Data;
using Domain.Repository.Interface;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository
{
    public class RepositoryVncTercerNvlRecurso : InterfaceVncTercerNvlRecurso<VncTercerNvlRecurso>
    {
        protected readonly Context context;
        public RepositoryVncTercerNvlRecurso(Context context)
        {
            this.context = context;
        }

        public IList<VncTercerNvlRecurso> All()
        {
            return this.context.VncTercerNvlRecursos.ToList();
        }

        public void Add(VncTercerNvlRecurso objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.VncTercerNvlRecursos.Add(objeto);
        }

        public VncTercerNvlRecurso GetId(int id)
        {
            return this.context.VncTercerNvlRecursos.Where(s => s.id == id).FirstOrDefault();
        }

        public VncTercerNvlRecurso GetIdPadre(int id, int padre)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();

            return this.context.VncTercerNvlRecursos.Where(s => s.idRecurso == id && s.idTercerNvl == padre  && s.codigoEstado == activo.id).FirstOrDefault();
        }

        public long GetTotalId(int id)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            return this.context.VncTercerNvlRecursos.Count(s => s.idTercerNvl == id  && s.codigoEstado == activo.id);
        }

        public void Estado(int id)
        {
            Estado activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            Estado inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();

            VncTercerNvlRecurso objeto = this.context.VncTercerNvlRecursos.Where(s => s.id == id).FirstOrDefault();

            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            if(objeto.codigoEstado == activo.id)
                objeto.codigoEstado = inactivo.id;
            else
                objeto.codigoEstado = activo.id;

            this.context.VncTercerNvlRecursos.Update(objeto);
        }
    }
}