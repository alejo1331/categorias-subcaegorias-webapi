namespace Domain.AplicationModel
{
    public class VncTercerNvlSubcategoriaAM
    {
        public int id { get; set; }

        //Foreign key

        public int idSubcategoria { get; set; }
        public int idTercerNvl { get; set; }
        public int codigoEstado { get; set; }

        //

        public int vinculo { get; set; }
        public int user { get; set; }
    }
}