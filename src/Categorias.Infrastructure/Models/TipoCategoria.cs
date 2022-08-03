using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Models
{
    [Table("TBL_CSC_TIPO_CATEGORIA", Schema = "tramites_y_servicios")]
    public class TipoCategoria
    {
        [Key]
        [Column("CTC_ID", TypeName = "int")]
        public int Id { get; set; }

        [Column("CTC_NOMBRE", TypeName = "varchar(30)")]
        public string Nombre { get; set; }

        [Column("CTC_DESCRIPCION_CORTA", TypeName = "varchar(100)")]
        public string DecripcionCorta { get; set; }

        [Column("CTC_DESCRIPCION_LARGA", TypeName = "varchar(300)")]
        public string DecripcionLarga { get; set; }

        [Column("CTC_ORDEN", TypeName = "int")]
        public int OrdenPresentacion { get; set; }

        [Column("CTC_SIGLA", TypeName = "varchar(5)")]
        public string Sigla { get; set; }

        //Foreign key

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int CodigoEstado { get; set; }

        [ForeignKey("CodigoEstado")]
        public Estado Estado { get; set; }

        //

        [Column("USUARIO_CREACION", TypeName = "varchar(450)")]
        public string User { get; set; }

        [Column("CTC_LOGO", TypeName = "varchar(200)")]
        public string Icono { get; set; }

        [Column("CTC_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime? FechaCreacion { get; set; }

        [Column("CTC_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? FechaModificacion { get; set; }
    }
}
