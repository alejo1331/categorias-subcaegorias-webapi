using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Models
{
    [Table("TBL_ESTADOS", Schema = "tramites_y_servicios")]
    public class Estado
    {
        [Key]
        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int Id { get; set; }

        [Column("DESCRIPCION_ESTADO", TypeName = "varchar(100)")]
        public string Descripcion { get; set; }
    }
}
