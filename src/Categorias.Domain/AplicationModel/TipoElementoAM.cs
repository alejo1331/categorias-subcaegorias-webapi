using System;



namespace Domain.Categorias.AplicationModel
{
    public class TipoElementoAM
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string sigla { get; set; }

        //Foreign Key
        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }
        //
        public  string modulo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int? usuario { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string tipo { get; set; }
    }
}