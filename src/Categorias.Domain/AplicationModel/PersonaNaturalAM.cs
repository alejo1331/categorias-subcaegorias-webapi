using System;

namespace Categorias.Domain.Categorias.AplicationModel
{
    public class PersonaNaturalAM
    {       
        public int Id { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Direccion { get; set; }

        public int IdEstado { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }       
    }
}