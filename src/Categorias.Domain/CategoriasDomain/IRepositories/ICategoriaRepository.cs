using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.CategoriasDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.CategoriasDomain.IRepositories
{
    public interface ICategoriaRepository
    {
        List<CategoriaEntity> ObtenerListadoCategoriasPaginado(PaginateModelDomain paginateModel);
        List<CategoriaEntity> ObtenerListadoCategorias();
        List<CategoriaEntity> ObtenerListadoCategoriasPorTipoCategoria(string sigla);
        List<CategoriaEntity> ObtenerListadoCategoriasPorTipoCategoriaPaginado(string sigla, string parametro, int pagina);
    }
}
