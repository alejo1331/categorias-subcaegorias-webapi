namespace Domain.Categorias.AplicationModel
{
    public class VncSubcategoriaCategoriaAM
    {
        public int id { get; set; }

        //Foreign Key 

        public int idCategoria { get; set; }
        public virtual CategoriaAM CAtegoria {get; set;}

        public int idSubcategoria { get; set; }
        public virtual SubcategoriaAM Subcategoria {get; set;}

        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }

        //

        public int tipoVinculo { get; set; }

        public int user { get; set; }
    }
}