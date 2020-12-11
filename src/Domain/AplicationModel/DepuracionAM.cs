using System;

namespace Domain.Categorias.AplicationModel
{
    public class DepuracionAM
    {
        public int id { get; set; }
        public int registros { get; set; }
        public int codigoEstado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
    }
}