using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("VM_CT_PUNTO_ATENCION", Schema = "tramites_y_servicios")]
    public class PPT
    {
        [Key]
        [Column("PUNTO_ATENCION_ID", TypeName = "numeric(10,0)")]
        public int id { get; set; }
        [Column("PUNTO_ATENCION_NOMBRE", TypeName = "varchar(250)")]
        public string nombre { get; set; }
        [Column("MUNICPIO_CODIGO", TypeName = "varchar(10)")]
        public string municipioCodigo { get; set; }
        [Column("MUNICIPIO_NOMBRE", TypeName = "varchar(100)")]
        public string municipioNombre { get; set; }
        [Column("DEPARTAMENTO_CODIGO", TypeName = "varchar(10)")]
        public string departamentoCodigo { get; set; }
        [Column("DEPARTAMENTO_NOMBRE", TypeName = "varchar(100)")]
        public string departamentoNombre { get; set; }
        [Column("HORARIO_ATENCION", TypeName = "varchar(1000)")]
        public string horarioAtencion { get; set; }
        [Column("PUNTO_ATENCION_DIRECCION", TypeName = "varchar(1000)")]
        public string puntoAtencionDireccion { get; set; }
        [Column("PUNTO_ATENCION_TELEFONO", TypeName = "varchar(1000)")]
        public string puntoAtencionTelefono { get; set; }
        [Column("INSTITUCION_ID", TypeName = "varchar(4)")]
        public string institucionId { get; set; }
        [Column("ES_SEDE_PRINCIPAL", TypeName = "varchar(1)")]
        public string esSedePrincipal { get; set; }
    }
}