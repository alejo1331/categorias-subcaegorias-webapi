using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("TBL_CSC_TERCER_NIVEL", Schema = "tramites_y_servicios")]
    public class TercerNivel
    {
        [Key]
        [Column("CTN_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("CTN_NOMBRE", TypeName = "varchar(30)")]
        public string nombre { get; set; }

        [Column("CTN_DESCRIPCION_CORTA", TypeName = "varchar(100)")]
        public string descripcionCorta { get; set; }

        [Column("CTN_DESCRIPCION_LARGA", TypeName = "varchar(300)")]
        public string descripcionLarga { get; set; }

        [Column("CTN_LOGO", TypeName = "varchar(200)")]
        public string icono { get; set; }

        [Column("CTN_ORDEN", TypeName = "int")]
        public int orden { get; set; }

        //Foreign Key

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        [Column("SUBCATEGORIA_ID", TypeName = "int")]
        public int padre { get; set; }
        [ForeignKey("padre")]
        public Subcategoria Subcategoria { get; set; }
        //

        [Column("USUARIO_CREACION", TypeName = "varchar(450)")]
        public string user { get; set; }

        [Column("CTN_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime? fechaCreacion { get; set; }

        [Column("CTN_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }
    }
}