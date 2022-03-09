using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Models
{
    [Table("TBL_CSC_ELEMENTO_CATEGORIA", Schema = "tramites_y_servicios")]
    public class TramiteCategoria
    {
        [Key]
        [Column("CEC_ID", TypeName = "int")]
        public int Id { get; set; }

        [Column("TEL_ID", TypeName = "int")]
        public int IdTipoElemento { get; set; }

        [Column("ELEMENTO_ID", TypeName = "varchar(50)")]
        public string IdElemento { get; set; }

        [Column("CATEGORIA_ID", TypeName = "int")]
        public int IdCategoria { get; set; }

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int CodigoEstado { get; set; }

        //Foranea Tipo Elemento
        [ForeignKey("IdTipoElemento")]
        public TipoElemento TipoElemento { get; set; }


        //Foranea Categoria
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        //Foranea Estado
        [ForeignKey("CodigoEstado")]
        public Estado Estado { get; set; }
    }
}
