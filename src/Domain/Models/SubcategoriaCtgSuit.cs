using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("TBL_CSC_SUBCATEGORIA_CATEGORIASUIT", Schema = "tramites_y_servicios")]
    public class SubcategoriaCtgSuit
    {
        [Key]
        [Column("TCS_ID", TypeName = "int")]
        public int id { get; set; }

        //Foreign Key

        [Column("SUBCATEGORIA_ID", TypeName = "int")]
        public int idSubcategoria { get; set; }
        [ForeignKey("idSubcategoria")]
        public Subcategoria Subcategoria { get; set; }


        [Column("SITUACION_VIDA_ID", TypeName = "int")]
        public int idCategoriaSuit { get; set; }
        [ForeignKey("idCategoriaSuit")]
        public CategoriaSUIT CategoriaSUIT { get; set; }


        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }


        //

        [Column("TCS_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime? fechaCreacion { get; set; }

        [Column("TCS_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; } 

    }
}