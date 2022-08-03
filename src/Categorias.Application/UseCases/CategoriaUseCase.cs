using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Categorias.Application.DTO;
using Categorias.Application.Models;
using Categorias.Application.Profiles;
using Categorias.Application.UseCases.Interface;
using Categorias.Domain.CategoriasDomain.Models;
using Categorias.Domain.CategoriasDomain.Services;
using Categorias.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.UseCases
{
    public class CategoriaUseCase : ICategoriaUseCase
    {
        private readonly IMapper _mapper;

        public CategoriaUseCase()
        {
            // Init Automapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
                cfg.AddExpressionMapping();
            });
            this._mapper = new Mapper(mapConfig);
        }

        public Response<List<CategoriaDTO>> ObtenerListadoCategoriasPorTipoCategoria(string sigla)
        {
            var response = new Response<List<CategoriaDTO>>();

            try
            {
                using (var categoriaRepository = new CategoriaRepository())
                {
                    response.Data = _mapper.Map<List<CategoriaDTO>>(new CategoriaService(categoriaRepository).ObtenerListadoCategoriasPorTipoCategoria(sigla));
                    response.Data.ForEach(c => c.Codigo = c.Id.ToString());
                }
                response.Succeeded = true;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }

            return response;
        }




        public Response<List<CategoriaDTO>> ObtenerListadoCategoriasPaginado(PaginateModel paginateModel)
        {
            var response = new Response<List<CategoriaDTO>>();

            try
            {
                using (var categoriaRepository = new CategoriaRepository())
                {
                    PaginateModelDomain paginateMapped = _mapper.Map<PaginateModelDomain>(paginateModel);
                    response.Data = _mapper.Map<List<CategoriaDTO>>(new CategoriaService(categoriaRepository).ObtenerListadoCategoriasPaginado(paginateMapped));
                }
                response.Succeeded = true;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }

            return response;
        }

        public Response<List<CategoriaDTO>> ObtenerListadoCategorias()
        {
            throw new NotImplementedException();
        }
    }
}
