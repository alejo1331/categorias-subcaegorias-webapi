using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.CategoriasDomain.Entities
{
    public class TramiteCategoriaEntity
    {
        public int Id { get; set; }
        public int IdTipoElemento { get; set; }
        public string IdElemento { get; set; }
        public int IdCategoria { get; set; }
        public int CodigoEstado { get; set; }
        public virtual TipoElementoEntity TipoElemento { get; set; }
        public virtual CategoriaEntity Categoria { get; set; }
        public virtual EstadoEntity Estado { get; set; }
    }
}
