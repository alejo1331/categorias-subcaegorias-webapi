using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("VM_CT_CATEGORIASUIT", Schema = "tramites_y_servicios")]
    public class CategoriaSUIT
    {
        [Key]
        [Column("SITUACION_VIDA_ID", TypeName = "numeric(4,0)")]
        public int id { get; set; }

        [Column("SITUACION_VIDA_NOMBRE", TypeName = "varchar(100)")]
        public string nombre { get; set; }
    }
}