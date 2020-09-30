using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("TBL_RECURSO_SUBCATEGORIA", Schema = "tramites_y_servicios")]
    public class VncSubcategoriaRecurso
    {
        [Key]
        [Column("RECURSO_SUBCATEGORIA_ID", TypeName = "int")]
        public int id { get; set; }

        //Foreign Key

        [Column("RECURSOS_ID", TypeName = "int")]
        public int idRecurso { get; set; }
        [ForeignKey("idRecurso")]
        public Recurso Recurso { get; set; }


        [Column("SUBCATEGORIA_ID", TypeName = "int")]
        public int idSubCtg { get; set; }
        [ForeignKey("idSubCtg")]
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