using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Categorias.Domain.Models
{
    [Table("TBL_RYP_PERSONA", Schema = "roles_Y_perfiles")]
    public class PersonaNatural
    {       
            [Key]
            [Column("TPP_ID", TypeName = "int")]
            public int Id { get; set; }

            [Column("TRD_ID", TypeName = "int")]
            public int IdTipoDocumento { get; set; }

            [Column("TPP_DOCUMENTO", TypeName = "varchar(50)")]
            public string NumeroDocumento { get; set; }

            [Column("TPP_DIRECCION", TypeName = "varchar(100)")]
            public string Direccion { get; set; }

            [Column("CODIGO_ESTADO", TypeName = "int")]
            public int IdEstado { get; set; }

            [Column("TPP_PRIMER_NOMBRE", TypeName = "varchar(50)")]
            public string PrimerNombre { get; set; }

            [Column("TPP_SEGUNDO_NOMBRE", TypeName = "varchar(50)")]
            public string SegundoNombre { get; set; }

            [Column("TPP_PRIMER_APELLIDO", TypeName = "varchar(50)")]
            public string PrimerApellido { get; set; }

            [Column("TPP_SEGUNDO_APELLIDO", TypeName = "varchar(50)")]
            public string SegundoApellido { get; set; }       
    }
}