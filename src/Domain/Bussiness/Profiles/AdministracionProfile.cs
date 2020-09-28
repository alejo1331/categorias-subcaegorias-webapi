using AutoMapper;
using Domain.Models;
using Domain.AplicationModel;


namespace Domain.Bussiness.Profiles
{
    public class AdministracionProfile : Profile
    {
        public AdministracionProfile()
        {
            //Principales
            CreateMap<Estado, EstadoAM>();
            CreateMap<TipoCategoria, TipoCategoriaAM>().ReverseMap();
            CreateMap<Categoria, CategoriaAM>().ReverseMap();
            CreateMap<Subcategoria, SubcategoriaAM>().ReverseMap();
            CreateMap<TercerNivel, TercerNivelAM>().ReverseMap();
            CreateMap<TipoRecurso, TipoRecursoAM>().ReverseMap();
            CreateMap<Recurso, RecursoAM>().ReverseMap();

            //Vinculaciones
            CreateMap<VncCategoriaTipoCtg, VncCategoriaTipoCtgAM>().ReverseMap();
        }
    }
}