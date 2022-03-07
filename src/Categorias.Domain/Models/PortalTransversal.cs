using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Categorias.Domain.Models
{
    [Table("TBL_ISE_PORTAL_TRANSVERSAL", Schema = "tramites_y_servicios")]
    public class PortalTransversal
    {
        [Key]
        [Column("ptt_id", TypeName = "int")]
        public int id { get; set; }
        [Column("ptt_nombre_corto", TypeName = "varchar(100)")]
        public string nombre { get; set; }
        [Column("ptt_nombre_largo", TypeName = "varchar(500)")]
        public string nombreLargo { get; set; }
        [Column("ptt_descripcion", TypeName = "text")]
        public string descripcion { get; set; }

        //Foreign Key
        [Column("ptt_codigo_estado", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        //
    }
}