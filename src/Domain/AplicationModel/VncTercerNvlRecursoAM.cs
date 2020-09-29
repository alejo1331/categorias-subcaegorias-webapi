namespace Domain.AplicationModel
{
    public class VncTercerNvlRecursoAM
    {
        public int id { get; set; }

        //Foreign Key

        public int idRecurso { get; set; }
        public int idTercerNvl { get; set; }
        public int codigoEstado { get; set; }

        //

        public int vinculo { get; set; }
        public int user { get; set; }
    }
}