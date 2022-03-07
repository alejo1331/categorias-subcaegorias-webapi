using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Categorias.Domain.Models
{
    [Table("TBL_CSC_BITACORA", Schema = "tramites_y_servicios")]
    public class Bitacora
    {
        [Key]
        [Column("CBC_ID", TypeName = "int")]
        public int id { get; set; }

        [Column("CBC_PARAMETRO_ID", TypeName = "int")]
        public int idParametro { get; set; }

        [Column("CBC_DESCRIPCION", TypeName = "varchar(400)")]
        public string descripcion { get; set; }

        [Column("CBC_FECHA", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }

        [Column("USUARIO", TypeName = "varchar(450)")]
        public string usuario { get; set; }

        //Foreign Key
        [Column("CTP_ID", TypeName = "int")]
        public int Parametro {get; set;}
        [ForeignKey("Parametro")]
        public TipoParametro TipoParametro { get; set; }

        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }

        [Column("CTO_ID", TypeName = "int")]
        public int Configuracion {get; set;}
        [ForeignKey("Configuracion")]
        public TipoConfiguracion TipoConfiguracion { get; set; }
        //

        //Foranea Usuario
        [ForeignKey("usuario")]
        public Usuario usuarioObj { get; set; }   
    }
}