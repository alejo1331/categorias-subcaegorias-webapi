using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.DTO
{
    public class TramiteCategoriaDTO
    {
        public int Id { get; set; }
        public int IdTipoElemento { get; set; }
        public string IdElemento { get; set; }
        public int IdCategoria { get; set; }
        public int CodigoEstado { get; set; }
        public virtual TipoElementoDTO TipoElemento { get; set; }
        public virtual CategoriaDTO Categoria { get; set; }
    }
}

