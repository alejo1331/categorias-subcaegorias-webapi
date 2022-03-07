using System;

namespace Categorias.Domain.Categorias.AplicationModel
{
    public class CategoriaCtgSuitAM
    {
        public int id { get; set; }

        //Foreign Key

        public int idCategoria { get; set; }
        public virtual CategoriaAM Categoria { get; set; }


        public int idCategoriaSuit { get; set; }
        public virtual CategoriaSUITAM CategoriaSUIT { get; set; }


        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }


        //

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; } 

    }
}