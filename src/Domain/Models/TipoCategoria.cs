using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("TBL_CSC_TIPO_CATEGORIA", Schema = "tramites_y_servicios")]
    public class TipoCategoria
    {
        [Key]
        [Column("CTC_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("CTC_NOMBRE", TypeName = "varchar(30)")]
        public string nombre { get; set; }

        [Column("CTC_DESCRIPCION_CORTA", TypeName = "varchar(100)")]
        public string decripcionCorta { get; set; }

        [Column("CTC_DESCRIPCION_LARGA", TypeName = "varchar(300)")]
        public string decripcionLarga { get; set; }

        [Column("CTC_ORDEN", TypeName = "int")]
        public int ordenPresentacion { get; set; }

        [Column("CTC_SIGLA", TypeName = "varchar(5)")]
        public string sigla { get; set; }

        //Foreign key

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }

        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        //

        [Column("USUARIO_CREACION", TypeName = "varchar(450)")]
        public string? user { get; set; }

        [Column("CTC_LOGO", TypeName = "varchar(200)")]
        public string icono { get; set; }

        [Column("CTC_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime? fechaCreacion { get; set; }

        [Column("CTC_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }
    }
}