using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Categorias.Domain.Models
{
    [Table("TBL_RECURSO_CATEGORIA", Schema = "tramites_y_servicios")]
    public class VncCategoriaRecurso
    {
        [Key]
        [Column("RECURSO_CATEGORIA_ID", TypeName = "int")]
        public int id { get; set; }

        //Foreign Key

        [Column("RECURSO_ID", TypeName = "int")]
        public int idRecurso { get; set; }
        [ForeignKey("idRecurso")]
        public Recurso Recurso { get; set; }


        [Column("CATEGORIA_ID", TypeName = "int")]
        public int idCtg { get; set; }
        [ForeignKey("idCtg")]
        public Categoria Categoria { get; set; }


        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }

        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        //

        [Column("VINCULO", TypeName = "int")]
        public int vinculo { get; set; }

        [Column("USUARIO_CREACION", TypeName = "int")]
        public int user { get; set; }
    }
}