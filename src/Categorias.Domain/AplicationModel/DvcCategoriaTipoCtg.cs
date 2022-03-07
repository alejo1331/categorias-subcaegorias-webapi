using System;
using System.ComponentModel.DataAnnotations;

namespace Categorias.Domain.Categorias.AplicationModel
{
    public class DvcCategoriaTipoCtg
    {
        [Required]
        public int idTipoCategoria { get; set; }
        [Required]
        public string idscategorias { get; set; }
    }
}