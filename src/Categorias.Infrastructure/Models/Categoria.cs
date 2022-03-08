using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Models
{
    [Table("TBL_CATEGORIAS", Schema = "tramites_y_servicios")]
    public class Categoria
    {
        [Key]
        [Column("CATEGORIA_ID", TypeName = "int")]
        public int Id { get; set; }

        [Column("NOMBRE", TypeName = "varchar(30)")]
        public string Nombre { get; set; }

        [Column("DESCRIPCION", TypeName = "varchar(100)")]
        public string DescripcionCorta { get; set; }

        [Column("DESCRIPCION_LARGA", TypeName = "varchar(300)")]
        public string DescripcionLarga { get; set; }


        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int CodigoEstado { get; set; }


        [Column("ORDEN", TypeName = "int")]
        public int Orden { get; set; }

        [Column("ICONO", TypeName = "varchar(200)")]
        public string Icono { get; set; }

        [Column("USUARIO_CREACION", TypeName = "varchar(450)")]
        public string User { get; set; }

        [Column("FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime? FechaCreacion { get; set; }

        [Column("FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? FechaModificacion { get; set; }
    }
}
