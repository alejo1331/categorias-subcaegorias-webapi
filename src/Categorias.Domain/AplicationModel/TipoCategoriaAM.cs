using System;

namespace Domain.Categorias.AplicationModel
{
    public class TipoCategoriaAM
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string decripcionCorta { get; set; }

        public string decripcionLarga { get; set; }

        public int ordenPresentacion { get; set; }

        public string sigla { get; set; }

        //Foreign key
        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado {get; set;}
        //

        public  string user { get; set; }

        public string icono { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }
    }
}