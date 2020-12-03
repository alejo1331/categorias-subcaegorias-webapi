using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("TBL_CSC_TIPO_PARAMETRO", Schema = "tramites_y_servicios")]
    public class TipoParametro
    {
        [Key]
        [Column("CTP_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("CTP_NOMBRE", TypeName = "varchar(50)")]
        public string nombre { get; set; }

        [Column("CTP_SIGLA", TypeName = "varchar(5)")]
        public string sigla { get; set; }

        //Foreign Key
        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }
        //

        [Column("USUARIO_CREACION", TypeName = "int")]
        public int? user { get; set; }
    }
}