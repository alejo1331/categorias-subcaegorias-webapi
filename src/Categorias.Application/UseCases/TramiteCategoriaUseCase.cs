using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Categorias.Application.DTO;
using Categorias.Application.Models;
using Categorias.Application.Profiles;
using Categorias.Application.UseCases.Interface;
using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.CategoriasDomain.Services;
using Categorias.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.UseCases
{
    public class TramiteCategoriaUseCase : ITramiteCategoriaUseCase
    {
        private readonly IMapper _mapper;

        public TramiteCategoriaUseCase()
        {
            // Init Automapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationProfile>();
                cfg.AddExpressionMapping();
            });
            this._mapper = new Mapper(mapConfig);
        }

        public Response<List<CategoriaDTO>> ObtenerListaTramitesCategorias(string idTramite)
        {
            var response = new Response<List<CategoriaDTO>>();
            try
            {
                using (var tramiteRepository = new TramiteCategoriaRepository())
                {
                    Expression<Func<TramiteCategoriaEntity, bool>> predicado = t => t.TipoElemento.Sigla == "TS" && t.IdElemento == idTramite && t.Estado.Descripcion == "Activo";
                    List<TramiteCategoriaDTO> listado= _mapper.Map<List<TramiteCategoriaDTO>>(new TramiteCategoriaService(tramiteRepository).ObtenerListadoCategoriaTramite(predicado));
                    List<CategoriaDTO> listadoCategorias=new List<CategoriaDTO>();
                    foreach (TramiteCategoriaDTO categoria in listado) 
                    {
                        listadoCategorias.Add(categoria.Categoria);
                    }
                    response.Data = listadoCategorias;


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
