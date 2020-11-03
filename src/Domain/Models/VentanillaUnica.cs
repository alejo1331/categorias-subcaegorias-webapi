using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("TBL_ISE_VENTANILLA_UNICA", Schema = "tramites_y_servicios")]
    public class VentanillaUnica
    {
        [Key]
        [Column("vtu_id", TypeName = "int")]
        public int id { get; set; }
        [Column("vtu_nombre_corto", TypeName = "varchar(200)")]
        public string nombre { get; set; }
        [Column("vtu_nombre_largo", TypeName = "varchar(500)")]
        public string nombreLargo { get; set; }
        [Column("vtu_descripcion", TypeName = "text")]
        public string descripcion { get; set; }
        [Column("tra_id", TypeName = "int")]
        public int tramiteId { get; set; }
        [Column("vtu_url_dominio", TypeName = "varchar(1000)")]
        public string dominio { get; set; }
        [Column("vtu_nombre_contacto", TypeName = "varchar(100)")]
        public string nombreContacto { get; set; }
        [Column("vtu_cargo_contacto", TypeName = "varchar(100)")]
        public string cargoContacto { get; set; }
        [Column("vtu_email_contacto", TypeName = "varchar(100)")]
        public string emailContacto { get; set; }
        [Column("vtu_telefono_contacto", TypeName = "varchar(20)")]
        public string telefonoContacto { get; set; }
        [Column("vtu_usuario_creacion", TypeName = "int")]
        public int usuarioCreacion { get; set; }
        [Column("vtu_fecha_creacion", TypeName = "smalldatetime")]
        public DateTime fechaCreacion { get; set; }
        [Column("vtu_fecha_modificacion", TypeName = "smalldatetime")]
        public DateTime fechaModificacion { get; set; }
        [Column("vtu_solicitud_id", TypeName = "int")]
        public int solicitudId { get; set; }

        //Foreign Key
        [Column("vtu_codigo_estado", TypeName = "int")]
        public int codigoEstado { get; set; }
        [ForeignKey("codigoEstado")]
        public Estado Estado { get; set; }
        //
    }
}