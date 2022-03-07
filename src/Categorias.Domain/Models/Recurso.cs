using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Categorias.Domain.Models
{
    [Table("TBL_RECURSOS", Schema = "tramites_y_servicios")]
    public class Recurso
    {
        [Key]
        [Column("RECURSO_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("NOMBRE", TypeName = "varchar(200)")]
        public string nombre { get; set; }

        [Column("DESCRIPCION", TypeName = "varchar(300)")]
        public string descripcion { get; set; }

        //Foreign key

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }

        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }


        [Column("TIPO_RECURSO_ID", TypeName = "int")]
        public int tipoRecurso { get; set; }

        [ForeignKey("tipoRecurso")]
        public TipoRecurso Tipo { get; set; }

        
        [Column("CTP_ID", TypeName = "int")]
        public int? parametro { get; set; }

        [ForeignKey("parametro")]
        public TipoParametro TipoParametro { get; set; }

        //

        [Column("ORDEN", TypeName = "tinyint")]
        public int orden { get; set; }

        [Column("URL_RECURSO", TypeName = "varchar(400)")]
        public string url { get; set; }

        [Column("PARAMETRO_ID", TypeName = "int")]
        public int? idParametro { get; set; }
    }
}