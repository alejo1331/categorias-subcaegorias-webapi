using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.Models
{
    public class CategoriaTramiteDestacado
    {
        public int Id { get; set; }
        public string NumeroTramite { get; set; }
        public int IdCategoria { get; set; }
        public int Orden { get; set; }
    }
}
