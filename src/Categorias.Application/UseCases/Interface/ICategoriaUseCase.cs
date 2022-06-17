using Categorias.Application.DTO;
using Categorias.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.UseCases.Interface
{
    public interface ICategoriaUseCase
    {
        Response<List<CategoriaDTO>> ObtenerListadoCategoriasPorTipoCategoria(string sigla);
        Response<List<CategoriaDTO>> ObtenerListadoCategoriasPaginado(PaginateModel paginateModel);
    }
}
