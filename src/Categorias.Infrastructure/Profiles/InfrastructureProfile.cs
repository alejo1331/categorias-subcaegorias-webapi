using AutoMapper;
using Categorias.Domain.CategoriasDomain.Entities;
using Categorias.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Profiles
{
    public class InfrastructureProfile: Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<Categoria, CategoriaEntity>().ReverseMap();
            CreateMap<TramiteCategoria, TramiteCategoriaEntity>().ReverseMap();
            CreateMap<TipoElemento, TipoElementoEntity>().ReverseMap();
            CreateMap<Estado, EstadoEntity>().ReverseMap();
            CreateMap<Parametro, ParametroEntity>().ReverseMap();



        }
    }
}
