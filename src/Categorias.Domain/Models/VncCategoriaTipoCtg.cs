using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Categorias.Domain.Models
{
    [Table("TBL_CSC_CATEGORIAS_TIPO_CATEGORIA", Schema = "tramites_y_servicios")]
    public class VncCategoriaTipoCtg
    {
        [Key]
        [Column("CCT_ID", TypeName = "int")]
        public int id { get; set; }

        //Foreign Key

        [Column("CATEGORIA_ID", TypeName = "int")]
        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }


        [Column("CTC_ID", TypeName = "int")]
        public int idTipoCtg { get; set; }
        [ForeignKey("idTipoCtg")]
        public TipoCategoria TipoCategoria { get; set; }


        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }

        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        //

        [Column("CCT_VINCULO", TypeName = "int")]
        public int tipoVinculo { get; set; }

        [Column("USUARIO_CREACION", TypeName = "int")]
        public int user { get; set; }
    }
}