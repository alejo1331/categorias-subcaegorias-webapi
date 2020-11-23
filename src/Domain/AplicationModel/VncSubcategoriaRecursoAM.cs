namespace Domain.Categorias.AplicationModel
{
    public class VncSubcategoriaRecursoAM
    {
        public int id { get; set; }

        //Foreign Key

        public int idRecurso { get; set; }
        public int? idSubCtg { get; set; }
        public int codigoEstado { get; set; }        

        //

        public int vinculo { get; set; }
        public int user { get; set; }
    }
}