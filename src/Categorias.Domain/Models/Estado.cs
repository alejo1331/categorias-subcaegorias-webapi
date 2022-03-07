using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Categorias.Domain.Models
{
    [Table("TBL_ESTADOS", Schema = "tramites_y_servicios")]
    public class Estado
    {
        [Key]
        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int id { get; set; }

        [Column("DESCRIPCION_ESTADO", TypeName = "varchar(100)")]
        public string descripcion { get; set; }

        [Column("FUNCIONALIDAD", TypeName = "varchar(100)")]
        public string funcionalidad { get; set; }
    }
}