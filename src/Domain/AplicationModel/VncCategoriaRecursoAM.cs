namespace Domain.AplicationModel
{
    public class VncCategoriaRecursoAM
    {
        public int id { get; set; }

        //Foreign Key

        public int idRecurso { get; set; }
        public int? idCtg { get; set; }
        public int codigoEstado { get; set; }

        //

        public int vinculo { get; set; }
        public int user { get; set; }
    }
}