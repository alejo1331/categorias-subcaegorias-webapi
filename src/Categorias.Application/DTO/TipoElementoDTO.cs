using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.DTO
{
    public class TipoElementoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int CodigoEstado { get; set; }
    }
}
