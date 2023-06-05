using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.Models
{
    [Table("TBL_PARAMETROS", Schema = "ficha_tramite")]
    public class Parametro
    {
        [Key]
        [Column("PARAMETROS_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("SIGLA", TypeName = "varchar(50)")]
        public string sigla { get; set; }

        [Column("NOMBRE", TypeName = "varchar(100)")]
        public string nombre { get; set; }

        [Column("VALOR", TypeName = "varchar(100)")]
        public string valor { get; set; }
    }
}
