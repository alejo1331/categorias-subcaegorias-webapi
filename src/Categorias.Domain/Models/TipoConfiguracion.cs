using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Categorias.Domain.Models
{
    [Table("TBL_CSC_TIPO_CONFIGURACION", Schema = "tramites_y_servicios")]
    public class TipoConfiguracion
    {
        [Key]
        [Column("CTO_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("CTO_NOMBRE", TypeName = "varchar(50)")]
        public string nombre { get; set; }

        [Column("CTO_SIGLA", TypeName = "varchar(50)")]
        public string sigla { get; set; }

        //Foreign Key
        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }
        //

        [Column("CTO_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime? fechaCreacion { get; set; }

        [Column("CTO_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }

        [Column("USUARIO_CREACION", TypeName = "int")]
        public int? user { get; set; }
    }
}