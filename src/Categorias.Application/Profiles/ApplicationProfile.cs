using AutoMapper;
using Categorias.Application.DTO;
using Categorias.Application.Models;
using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Domain.CategoriasDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.Profiles
{
    public class ApplicationProfile: Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CategoriaDTO, CategoriaEntity>().ReverseMap();
            CreateMap<PaginateModel, PaginateModelDomain>().ReverseMap();
            CreateMap<TipoElementoDTO, TipoElementoEntity>().ReverseMap();
            CreateMap<EstadoDTO, EstadoEntity>().ReverseMap();
            CreateMap<TramiteCategoriaDTO, TramiteCategoriaEntity>().ReverseMap();
            CreateMap<ParametroDTO, ParametroEntity>().ReverseMap();

        }
    }
}
