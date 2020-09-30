namespace Domain.AplicationModel
{
    public class VncCategoriaTipoCtgAM
    {
        public int id { get; set; }

        //Foreign Key

        public int idCategoria { get; set; }

        public int idTipoCtg { get; set; }

        public int codigoEstado { get; set; }

        //

        public int tipoVinculo { get; set; }

        public int user { get; set; }
    }
}