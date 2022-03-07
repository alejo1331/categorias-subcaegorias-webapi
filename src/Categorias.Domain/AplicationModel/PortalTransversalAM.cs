



namespace Categorias.Domain.Categorias.AplicationModel
{
    public class PortalTransversalAM
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string nombreLargo { get; set; }
        public string descripcion { get; set; }

        //Foreign Key
        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }

        //
    }
}