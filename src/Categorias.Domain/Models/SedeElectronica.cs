using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Categorias.Domain.Models
{
    [Table("TBL_AUTORIDAD", Schema = "tramites_y_servicios")]
    public class SedeElectronica
    {
        [Key]
        [Column("TRA_ID", TypeName = "int")]
        public int id { get; set; }
        [Column("TRA_RAZON_SOCIAL", TypeName = "varchar(120)")]
        public string nombre { get; set; }
        [Column("TRA_NIT", TypeName = "varchar(50)")]
        public  string nit { get; set; }
        [Column("TRA_DIRECCION", TypeName = "varchar(200)")]
        public  string direccion { get; set; }
        [Column("TRA_TELEFONO", TypeName = "varchar(50)")]
        public  string telefono { get; set; }
        [Column("TRA_CORREO", TypeName = "varchar(200)")]
        public  string correo { get; set; }
        [Column("TRA_FECHA_CREACION", TypeName = "smalldatetime")]
        public DateTime fechaCreacion { get; set; }
        [Column("TRA_FECHA_MODIFICACION", TypeName = "smalldatetime")]
        public DateTime? fechaModificacion { get; set; }

        //Foreign Key
        [Column("CODIGO_ESTADO", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }
        //
        [Column("TRA_PAGINA_WEB", TypeName = "varchar(100)")]
        public  string sedeElectronicaUrl { get; set; }
        [Column("ENTIDAD_ID", TypeName = "varchar(4)")]
        public  string entida { get; set; }
        [Column("DEP_CODIGO", TypeName = "varchar(2)")]
        public  string departamento { get; set; }
        [Column("MUN_CODIGO", TypeName = "varchar(5)")]
        public  string municipio { get; set; }
    }
}