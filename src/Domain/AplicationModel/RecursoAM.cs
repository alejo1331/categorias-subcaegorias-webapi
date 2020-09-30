namespace Domain.AplicationModel
{
    public class RecursoAM
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        //Foreign key

        public int codigoEstado { get; set; }

        public int tipoRecurso { get; set; }

        public int? tipoParametro { get; set; }

        //

        public int orden { get; set; }

        public string url { get; set; }

        public int? idParametro { get; set; }
    }
}