using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.CategoriasDomain.Entities
{
    public class TipoElementoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int CodigoEstado { get; set; }
    }
}
