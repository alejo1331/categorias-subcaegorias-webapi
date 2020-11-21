using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("VM_CT_TRAMITE", Schema = "tramites_y_servicios")]
    public class TramiteServicio
    {
        [Column("NUMERO", TypeName = "varchar(20)")]
        public string id { get; set; }
        [Column("NOMBRE", TypeName = "varchar(400)")]
        public string nombre { get; set; }
        [Column("PROPOSITO", TypeName = "varchar(max)")]
        public string? proposito { get; set; }
        [Column("NOMBRE_RESULTADO", TypeName = "varchar(400)")]
        public string? nombreResultado { get; set; }
        [Column("OBSERVACION_TIEMPO_OBTENCION", TypeName = "varchar(max)")]
        public string? observacionTiempoObtencion { get; set; }
        [Column("PALABRAS_CLAVE", TypeName = "varchar(max)")]
        public string? palabrasClave { get; set; }
        [Column("URL_TRAMITE_EN_LINEA", TypeName = "varchar(400)")]
        public string? urlTramiteLinea { get; set; }
        [Column("ESTADO_CODIGO", TypeName = "varchar(100)")]
        public string? estadoCodigo { get; set; }
        [Column("OBSERVACION_FECHA_GENERAL", TypeName = "varchar(600)")]
        public string? observacionFechaGeneral { get; set; }
        [Column("INSTITUCION_ID", TypeName = "varchar(4)")]
        public string? institucionId { get; set; }
        [Column("INSTITUCION_NOMBRE", TypeName = "varchar(120)")]
        public string? institucionNombre { get; set; }
        [Column("MUNICIPIO_NOMBRE", TypeName = "varchar(255)")]
        public string? municipioNombre { get; set; }
        [Column("FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime? fechaCreacion { get; set; }
        [Column("FECHA_ACTUALIZACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }
        [Column("USUARIO_CREADOR_ENTIDAD", TypeName = "varchar(40)")]
        public string usuarioCreador { get; set; }
        [Column("USUARIO_AUTORIZO_GOVCO", TypeName = "varchar(40)")]
        public string? usuarioAutorizo { get; set; }
        [Column("TIPO", TypeName = "varchar(15)")]
        public string? tipo { get; set; }        
        [Column("SITUACION_VIDA_NOMBRE", TypeName = "varchar(100)")]
        public string? nombreCategoriaSuit { get; set; }
        [Column("SITUACION_VIDA_ID", TypeName = "numeric(4,0)")]
        public int CategoriaSuit { get; set; }
    }
}