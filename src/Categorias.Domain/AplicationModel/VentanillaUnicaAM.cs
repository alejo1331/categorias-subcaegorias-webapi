using System;

namespace Domain.Categorias.AplicationModel
{
    public class VentanillaUnicaAM
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string nombreLargo { get; set; }
        public string descripcion { get; set; }
        public int tramiteId { get; set; }
        public string dominio { get; set; }
        public string nombreContacto { get; set; }
        public string cargoContacto { get; set; }
        public string emailContacto { get; set; }
        public string telefonoContacto { get; set; }
        public int usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public int? solicitudId { get; set; }

        //Foreign Key
        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }
        //
    }
}