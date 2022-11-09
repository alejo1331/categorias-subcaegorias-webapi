using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.CategoriasDomain.Entities
{
    public class ParametroEntity
    {
        public int id { get; set; }

        public string sigla { get; set; }

        public string nombre { get; set; }

        public string valor { get; set; }
    }
}
