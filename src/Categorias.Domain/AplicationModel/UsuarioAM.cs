using System;

namespace Categorias.Domain.Categorias.AplicationModel
{
    public class UsuarioAM
    {
        public string Id { get; set; }

        public int? IdTipoVinculacion { get; set; }
        
        public int IdTipoIdentificacion { get; set; }

        public int IdPersonaNatural { get; set; }

        public int IdPerfil { get; set; }

        public int? IdAutoridad { get; set; }

        public Boolean Nivel { get; set; }

        public int IdCodigoEstado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string EstadoGestion { get; set; }

        public string EmailSolicita { get; set; }
        
        public string OtraVinculacion { get; set; }

        public virtual PersonaNaturalAM PersonaNatural { get; set; }        

    }
}