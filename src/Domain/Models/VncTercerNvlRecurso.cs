using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("TBL_CSC_TERCER_NIVEL_RECURSO", Schema = "tramites_y_servicios")]
    public class VncTercerNvlRecurso
    {
        [Key]
        [Column("CTR_ID", TypeName = "int")]
        public int id { get; set; }

        //Foreign Key

        [Column("RECURSO_ID", TypeName = "int")]
        public int idRecurso { get; set; }
        [ForeignKey("idRecurso")]
        public Recurso Recurso { get; set; }


        [Column("CTN_ID", TypeName = "int")]
        public int idTercerNvl { get; set; }
        [ForeignKey("idTercerNvl")]
        public TercerNivel TercerNivel { get; set; }


        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }

        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        //

        [Column("CTR_VINCULO", TypeName = "int")]
        public int vinculo { get; set; }

        [Column("USUARIO_CREACION", TypeName = "int")]
        public int user { get; set; }
    }
}