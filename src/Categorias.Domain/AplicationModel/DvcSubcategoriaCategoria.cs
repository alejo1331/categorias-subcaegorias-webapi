using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Categorias.AplicationModel
{
    public class DvcSubcategoriaCategoria
    {
        [Required]
        public int idCategoria { get; set; }
        [Required]
        public string idssubcategorias { get; set; }
    }
}