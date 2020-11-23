using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("TBL_CATEGORIAS", Schema = "tramites_y_servicios")]
    public class Categoria
    {
        [Key]
        [Column("CATEGORIA_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("NOMBRE", TypeName = "varchar(30)")]
        public string nombre { get; set; }

        [Column("DESCRIPCION", TypeName = "varchar(100)")]
        public string descripcionCorta { get; set; }

        [Column("DESCRIPCION_LARGA", TypeName = "varchar(300)")]
        public string descripcionLarga { get; set; }

        //Foreign Key
        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        [Column("CTC_ID", TypeName = "int")]
        public int padre { get; set; }
        [ForeignKey("padre")]
        public TipoCategoria TipoCategoria { get; set; }
        //

        [Column("ORDEN", TypeName = "int")]
        public int orden { get; set; }

        [Column("ICONO", TypeName = "varchar(200)")]
        public string icono { get; set; }  

        [Column("USUARIO_CREACION", TypeName = "int")]
        public int? user { get; set; }

        [Column("FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime? fechaCreacion { get; set; }

        [Column("FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }     

    }
}