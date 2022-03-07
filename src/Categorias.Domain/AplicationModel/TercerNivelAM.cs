using System;

namespace Categorias.Domain.Categorias.AplicationModel
{
    public class TercerNivelAM
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcionCorta { get; set; }

        public string descripcionLarga { get; set; }

        public string icono { get; set; }

        public int orden { get; set; }

        //Foreign Key

        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }
        public int padre { get; set; }
        public virtual SubcategoriaAM Subcategoria { get; set; }
        //

        public string user { get; set; }
        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }
    }
}