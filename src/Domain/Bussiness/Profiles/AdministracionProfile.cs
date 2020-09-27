using AutoMapper;
using Domain.Models;
using Domain.AplicationModel;


namespace Domain.Bussiness.Profiles
{
    public class AdministracionProfile : Profile
    {
        public AdministracionProfile()
        {
            CreateMap<Estado, EstadoAM>();

            CreateMap<Categoria, CategoriaAM>().ReverseMap();
        }
    }
}