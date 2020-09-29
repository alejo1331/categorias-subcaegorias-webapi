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
            CreateMap<TipoParametro, TipoParametroAM>().ReverseMap();

            //Vinculaciones
            CreateMap<VncCategoriaTipoCtg, VncCategoriaTipoCtgAM>().ReverseMap();
            CreateMap<VncSubcategoriaCategoria, VncSubcategoriaCategoriaAM>().ReverseMap();
            CreateMap<VncTercerNvlSubcategoria, VncTercerNvlSubcategoriaAM>().ReverseMap();
            CreateMap<VncTipoCtgRecurso, VncTipoCtgRecursoAM>().ReverseMap();
            CreateMap<VncCategoriaRecurso, VncCategoriaRecursoAM>().ReverseMap();
            CreateMap<VncSubcategoriaRecurso, VncSubcategoriaRecursoAM>().ReverseMap();
            CreateMap<VncTercerNvlRecurso, VncTercerNvlRecursoAM>().ReverseMap();
        }
    }
}