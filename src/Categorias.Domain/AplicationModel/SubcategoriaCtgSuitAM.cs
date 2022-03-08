using System;



namespace Domain.Categorias.AplicationModel
{
    public class SubcategoriaCtgSuitAM
    {
        public int id { get; set; }

        //Foreign Key

        public int idSubcategoria { get; set; }
        public virtual SubcategoriaAM Subcategoria { get; set; }


        public int idCategoriaSuit { get; set; }
        public virtual CategoriaSUITAM CategoriaSUIT { get; set; }


        public int codigoEstado { get; set; }
        public virtual EstadoAM Estado { get; set; }


        //

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; } 

    }
}