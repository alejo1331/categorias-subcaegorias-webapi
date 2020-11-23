using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("TBL_TIPO_RECURSOS", Schema = "tramites_y_servicios")]
    public class TipoRecurso
    {
        [Key]
        [Column("TIPO_RECURSO_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("NOMBRE_TIPO", TypeName = "varchar(50)")]
        public string nombre { get; set; }

       [Column("DESCRIPCION", TypeName = "varchar(400)")]
        public string descripcion { get; set; }

        [Column("ICONO_TIPO_RECURSOS", TypeName = "varbinary(max)")]
        public string icono { get; set; }

        //Foreign key

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }

        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        //

        [Column("SIGLAS", TypeName = "varchar(10)")]
        public string siglas { get; set; }
    }
}