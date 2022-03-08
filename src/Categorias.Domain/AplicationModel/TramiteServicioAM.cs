using System;

namespace Domain.Categorias.AplicationModel
{
    public class TramiteServicioAM
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string proposito { get; set; }
        public string nombreResultado { get; set; }
        public string observacionTiempoObtencion { get; set; }
        public string palabrasClave { get; set; }
        public string urlTramiteLinea { get; set; }
        public string estadoCodigo { get; set; }
        public string observacionFechaGeneral { get; set; }
        public string institucionId { get; set; }
        public string institucionNombre { get; set; }
        public string municipioNombre { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string usuarioCreador { get; set; }
        public string usuarioAutorizo { get; set; }
        public string tipo { get; set; }
        
        public  string nombreCategoriaSuit { get; set; }
        public int CategoriaSuit { get; set; }
    }
}