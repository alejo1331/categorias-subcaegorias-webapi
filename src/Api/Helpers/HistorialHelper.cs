using System;

namespace Api.Helpers
{
    public class HistorialHelper
    {
        public int page { get; set; }
        public int size { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFinal { get; set; }
        public int orden { get; set; }
        public bool ascd { get; set; }
    }
}