namespace Domain.AplicationModel
{
    public class SubcategoriaAM
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        //Foreign Key
        public int codigoEstado { get; set; }
        //

        public int orden { get; set; }

        public string descripcionLarga { get; set; }
    }
}