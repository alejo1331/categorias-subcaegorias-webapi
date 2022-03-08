using System;


namespace Domain.Categorias.AplicationModel
{
    public class ElementoTercerNivelAM
    {
        public int id { get; set; }
        public String elementoId { get; set; }

        //Foreign Key
        public int tipoElementoId { get; set; }
        public virtual TipoElementoAM TipoElemento { get; set; }
        public int tercerNivelId { get; set; }
        public virtual TercerNivelAM TercerNivel { get; set; }
        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }
        //
        public int vinculo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int usuario { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}