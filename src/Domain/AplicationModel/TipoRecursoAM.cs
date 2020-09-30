namespace Domain.AplicationModel
{
    public class TipoRecursoAM
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string icono { get; set; }

        //Foreign key

        public int codigoEstado { get; set; }

        //

        public string siglas { get; set; }
    }
}