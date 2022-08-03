namespace Domain.Categorias.AplicationModel
{
    public class VncCategoriaTipoCtgAM
    {
        public int id { get; set; }

        //Foreign Key

        public int idCategoria { get; set; }
        public virtual CategoriaAM Categoria { get; set; }

        public int idTipoCtg { get; set; }
        public virtual TipoCategoriaAM TipoCategoria { get; set; }

        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }

        //

        public int tipoVinculo { get; set; }

        public int user { get; set; }
    }
}