using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.CategoriasDomain.IRepositories;
using Categorias.Domain.CategoriasDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Domain.CategoriasDomain.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            this._categoriaRepository = categoriaRepository;
        }

        public List<CategoriaEntity> ObtenerListadoCategorias()
        {
            try
            {
                return _categoriaRepository.ObtenerListadoCategorias();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CategoriaEntity> ObtenerListadoCategoriasPorTipoCategoria(string sigla)
        {
            try
            {
                return _categoriaRepository.ObtenerListadoCategoriasPorTipoCategoria(sigla);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CategoriaEntity> ObtenerListadoCategoriasPaginado(PaginateModelDomain paginateModel)
        {
            try
            {
                return _categoriaRepository.ObtenerListadoCategoriasPaginado(paginateModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CategoriaEntity> ObtenerListadoCategoriasPorTipoCategoriaPaginado(string sigla, string parametro, int pagina)
        {
            try
            {
                return _categoriaRepository.ObtenerListadoCategoriasPorTipoCategoriaPaginado(sigla, parametro, pagina);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
