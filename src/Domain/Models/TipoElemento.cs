using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("TBL_ISE_TIPO_ELEMENTO", Schema = "tramites_y_servicios")]
    public class TipoElemento
    {
        [Key]
        [Column("TEL_ID", TypeName = "int")]
        public int id { get; set; }
        [Column("TEL_NOMBRE", TypeName = "varchar(150)")]
        public string nombre { get; set; }
        [Column("TEL_SIGLA", TypeName = "varchar(5)")]
        public string sigla { get; set; }

        //Foreign Key
        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }
        //
        [Column("TEL_MODULO", TypeName = "varchar(20)")]
        public string modulo { get; set; }
        [Column("TEL_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime fechaCreacion { get; set; }
        [Column("USUARIO_CREACION", TypeName = "int")]
        public int usuario { get; set; }
        [Column("TEL_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }
        [Column("TEL_TIPO", TypeName = "varchar(20)")]
        public string tipo { get; set; }
    }
}