using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("TBL_CSC_ELEMENTO_SUBCATEGORIA", Schema = "tramites_y_servicios")]
    public class ElementoSubcategoria
    {
        [Key]
        [Column("CES_ID", TypeName = "int")]
        public int id { get; set; }
        [Column("ELEMENTO_ID", TypeName = "int")]
        public int elementoId { get; set; }

        //Foreign Key
        [Column("TEL_ID", TypeName = "int")]
        public int tipoElementoId { get; set; }
        [ForeignKey("tipoElementoId")]
        public TipoElemento TipoElemento { get; set; }

        [Column("SUBCATEGORIA_ID", TypeName = "int")]
        public int subcategoriaId { get; set; }
        [ForeignKey("subcategoriaId")]
        public Subcategoria Subcategoria { get; set; }

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }
        //
        [Column("CES_VINCULO", TypeName = "int")]
        public int vinculo { get; set; }

        [Column("CES_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime fechaCreacion { get; set; }

        [Column("USUARIO_CREACION", TypeName = "int")]
        public int usuario { get; set; }

        [Column("CES_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime fechaModificacion { get; set; }
    }
}