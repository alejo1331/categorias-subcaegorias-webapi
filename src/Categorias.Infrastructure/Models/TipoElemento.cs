using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Models
{
    [Table("TBL_ISE_TIPO_ELEMENTO", Schema = "tramites_y_servicios")]
    public class TipoElemento
    {
        [Key]
        [Column("TEL_ID", TypeName = "int")]
        public int Id { get; set; }

        [Column("TEL_NOMBRE", TypeName = "varchar(150)")]
        public string Nombre { get; set; }

        [Column("TEL_SIGLA", TypeName = "varchar(5)")]
        public string Sigla { get; set; }

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int CodigoEstado { get; set; }
    }
}
