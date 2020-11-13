namespace Domain.Categorias.AplicationModel
{
    public class VncTercerNvlSubcategoriaAM
    {
        public int id { get; set; }

        //Foreign key

        public int idSubcategoria { get; set; }
        public virtual SubcategoriaAM Subcategoria {get; set;}

        public int idTercerNvl { get; set; }
        public virtual TercerNivelAM TercerNivel {get; set;}

        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }

        //

        public int vinculo { get; set; }
        public int user { get; set; }
    }
}