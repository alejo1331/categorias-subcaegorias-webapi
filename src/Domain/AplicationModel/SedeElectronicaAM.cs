using System;

namespace Domain.Categorias.AplicationModel
{
    public class SedeElectronicaAM
    {
        public int id { get; set; }
        public string razonSocial { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }

        //Foreign Key
        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }
        //
        public string sedeElectronicaurl { get; set; }
        public string entida { get; set; }
        public string departamento { get; set; }
        public string municipio { get; set; }
    }
}