using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Categorias.Domain.Models
{
    [Table("TBL_CSC_SUBCATEGORIAS_TERCER_NIVEL", Schema = "tramites_y_servicios")]
    public class VncTercerNvlSubcategoria
    {
        [Key]
        [Column("CST_ID", TypeName = "int")]
        public int id { get; set; }

        //Foreign key

        [Column("SUBCATEGORIA_ID", TypeName = "int")]
        public int idSubcategoria { get; set; }
        [ForeignKey("idSubcategoria")]
        public Subcategoria Subcategoria { get; set; }

        [Column("CTN_ID", TypeName = "int")]
        public int idTercerNvl { get; set; }
        [ForeignKey("idTercerNvl")]
        public TercerNivel TercerNivel { get; set; }

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }

        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        //

        [Column("CST_VINCULO", TypeName = "int")]
        public int vinculo { get; set; }

        [Column("USUARIO_CREACION", TypeName = "int")]
        public int user { get; set; }
    }
}