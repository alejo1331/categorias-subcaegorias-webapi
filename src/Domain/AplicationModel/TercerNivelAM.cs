namespace Domain.AplicationModel
{
    public class TercerNivelAM
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcionCorta { get; set; }

        public string descripcionLarga { get; set; }

        public string icono { get; set; }

        public int orden { get; set; }

        //Foreign Key

        public int codigoEstado { get; set; }
        //

        public int user { get; set; }
    }
}