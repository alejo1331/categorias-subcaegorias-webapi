using System;



namespace Domain.Categorias.AplicationModel
{
    public class BitacoraCategoriasAM
    {
        public int id { get; set; }

        public int idParametro { get; set; }

        public string descripcion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public int usuario { get; set; }

        //Foreign Key
        public int Parametro { get; set; }
        public virtual TipoParametroAM TipoParametro { get; set; }

        public int codigoEstado { get; set; }

        public int Configuracion { get; set; }
        public virtual TipoConfiguracionAM TipoConfiguracion { get; set; }
        //
    }
}