using System;


namespace Categorias.Domain.Categorias.AplicationModel
{
    public class ElementoCategoriaAM
    {
        public int id { get; set; }
        public string elementoId { get; set; }

        //Foreign Key
        public int tipoElementoId { get; set; }  
        public virtual TipoElementoAM TipoElemento { get; set; }
        public int categoriaId { get; set; }
        public virtual CategoriaAM Categoria { get; set; }
        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }
        //
        public int vinculo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int usuario { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}