using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("AspNetUsers", Schema = "roles_Y_perfiles")]
    public class Usuario
    {
        [Key]
        [Column("Id", TypeName = "varchar(450)")]
        public string Id { get; set; }

        // public string Estado { get; set; }
        [Column("TRT_ID", TypeName = "int")]
        public int? IdTipoVinculacion { get; set; }
        
        [Column("TRI_ID", TypeName = "int")]
        public int IdTipoIdentificacion { get; set; }

        [Column("TPP_ID", TypeName = "int")]
        public int IdPersonaNatural { get; set; }

        [Column("TRP_ID", TypeName = "int")]
        public int IdPerfil { get; set; }

        [Column("TRA_ID", TypeName = "int")]
        public int? IdAutoridad { get; set; }

        [Column("Nivel", TypeName = "bit")]
        public Boolean Nivel { get; set; }

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int IdCodigoEstado { get; set; }

        [Column("FechaCreacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [Column("EstadoGestion", TypeName = "varchar(20)")]
        public string EstadoGestion { get; set; }

        [Column("EmailSolicita", TypeName = "nvarchar(256)")]
        public string EmailSolicita { get; set; }
        
        [Column("OtraVinculacion", TypeName = "varchar(50)")]
        public string OtraVinculacion { get; set; }

        //Foranea Persona Natural
        [ForeignKey("IdPersonaNatural")]
        public PersonaNatural PersonaNatural { get; set; }        

    }
}