namespace Domain.Categorias.AplicationModel
{
    public class TipoParametroAM
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string sigla { get; set; }

        //Foreign Key
        public int codigoEstado { get; set; }
        //

        public int user { get; set; }
    }
}