using System;
using System.ComponentModel.DataAnnotations;


namespace Domain.Categorias.AplicationModel
{
    public class DvcTercerNivelSct
    {
        [Required]
        public int idSubcategoria { get; set; }
        [Required]
        public string idsTercerNivel { get; set; }
    }
}