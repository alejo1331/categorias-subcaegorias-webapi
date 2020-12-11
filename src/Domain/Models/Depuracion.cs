using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("TBL_CSC_REGISTRO_DEPURACION", Schema = "tramites_y_servicios")]
    public class Depuracion
    {
        [Key]
        [Column("TRD_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("TRD_REGISTROS", TypeName = "int")]
        public int registros { get; set; }

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        [Column("TRD_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime fechaCreacion { get; set; }

        [Column("TRD_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }
    }
}