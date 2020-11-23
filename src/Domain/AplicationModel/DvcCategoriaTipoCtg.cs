using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Categorias.AplicationModel
{
    public class DvcCategoriaTipoCtg
    {
        [Required]
        public int idTipoCategoria { get; set; }
        [Required]
        public string idscategorias { get; set; }
    }
}