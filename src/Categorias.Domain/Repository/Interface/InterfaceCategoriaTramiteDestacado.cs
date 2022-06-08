using Categorias.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceCategoriaTramiteDestacado
    {
        Task<CategoriaTramiteDestacado> EliminarCategoriaTramiteDestacado(int idCategoria, string numeroTramite);
    }
}
