using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Categorias.Application.DTO;
using Categorias.Application.Models;
using Categorias.Application.Profiles;
using Categorias.Application.UseCases.Interface;
using Categorias.Domain.CategoriasDomain.Services;
using Categorias.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.UseCases
{
    public class ParametroUseCase : IParametroUseCase
    {
        private readonly IMapper _mapper;

        public ParametroUseCase()
        {
            // Init Automapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
                cfg.AddExpressionMapping();
            });
            this._mapper = new Mapper(mapConfig);
        }

        public Response<ParametroDTO> ObtenerValorParametro(string sigla)
        {
            var response = new Response<ParametroDTO>();

            try
            {
                using (var parametroRepository = new ParametroRepository())
                {

                 
                    response.Data = _mapper.Map<ParametroDTO>(new ParametroService(parametroRepository).ObtenerValorParametro(sigla));
    
                   
                }
                response.Succeeded = true;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }

            return response;
        }

    }
}
