using AutoMapper;
using Domain.Models;
using Domain.Categorias.AplicationModel;


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
            CreateMap<CategoriaSUIT, CategoriaSUITAM>().ReverseMap();
            CreateMap<TipoConfiguracion, TipoConfiguracionAM>().ReverseMap();
            CreateMap<Bitacora, BitacoraCategoriasAM>().ReverseMap();

            //Vinculaciones
            CreateMap<VncCategoriaTipoCtg, VncCategoriaTipoCtgAM>().ReverseMap();
            CreateMap<VncSubcategoriaCategoria, VncSubcategoriaCategoriaAM>().ReverseMap();
            CreateMap<VncTercerNvlSubcategoria, VncTercerNvlSubcategoriaAM>().ReverseMap();
            CreateMap<VncTipoCtgRecurso, VncTipoCtgRecursoAM>().ReverseMap();
            CreateMap<VncCategoriaRecurso, VncCategoriaRecursoAM>().ReverseMap();
            CreateMap<VncSubcategoriaRecurso, VncSubcategoriaRecursoAM>().ReverseMap();
            CreateMap<VncTercerNvlRecurso, VncTercerNvlRecursoAM>().ReverseMap();
            CreateMap<CategoriaCtgSuit, CategoriaCtgSuitAM>().ReverseMap();
            CreateMap<SubcategoriaCtgSuit, SubcategoriaCtgSuitAM>().ReverseMap();

            //Elementos
            CreateMap<PPT, PPTAM>();
            CreateMap<TramiteServicio, TramiteServicioAM>().ReverseMap();
            CreateMap<VentanillaUnica, VentanillaUnicaAM>().ReverseMap();
            CreateMap<SedeElectronica, SedeElectronicaAM>().ReverseMap();  
            CreateMap<TipoElemento, TipoElementoAM>().ReverseMap();  
            CreateMap<ElementoCategoria, ElementoCategoriaAM>().ReverseMap();   
            CreateMap<ElementoSubcategoria, ElementoSubcategoriaAM>().ReverseMap();    
            CreateMap<ElementoTercerNivel, ElementoTercerNivelAM>().ReverseMap(); 
            CreateMap<ElementosUnion, ElementosUnionAM>().ReverseMap();  
            CreateMap<PortalTransversal, PortalTransversalAM>().ReverseMap(); 
            CreateMap<ParametrosUnion, ParametrosUnionAM>().ReverseMap(); 
            
        }
    }
}