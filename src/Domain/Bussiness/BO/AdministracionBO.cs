using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Mvc;


using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Domain.Bussiness.Interface;
using Domain.AplicationModel;
using Domain.Data;
using Domain.Models;
using Domain.Repository.Interface;
using Domain.Repository;
using Domain.Bussiness.Profiles;



namespace Domain.Bussiness.BO
{
    public class AdministracionBO : IAdministracionBO
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public AdministracionBO(Context context)
        {
            this.context = context;
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AdministracionProfile>();
                cfg.AddExpressionMapping();
            });
            this.mapper = new Mapper(mapConfig);
        }

        //Principlaes

        //EstadoAM
        //Listar los EstadoAM
        public IList<EstadoAM> All()
        {
            InterfaceEstado<Estado> repository = new RepositoryEstado(context);
            return mapper.Map<List<EstadoAM>>(repository.All());
        }
        //Agregar EstaddAM
        public EstadoAM AddEstado(EstadoAM objeto)
        {
            InterfaceEstado<Estado> repository = new RepositoryEstado(context);
            Estado estado = mapper.Map<Estado>(objeto);
            repository.Add(estado);
            this.context.SaveChanges();
            EstadoAM estadoAM = mapper.Map<EstadoAM>(estado);
            return estadoAM;
        }
        //Obtener EstadoAM por id
        public EstadoAM getIdEstado(int id)
        {
            InterfaceEstado<Estado> repository = new RepositoryEstado(context);
            Estado estado = repository.GetId(id);
            return mapper.Map<EstadoAM>(estado);
        }

        //Tipo Categoria
        public IList<TipoCategoriaAM> AllTiposCtg()
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            return mapper.Map<List<TipoCategoriaAM>>(repository.All());
        }

        public TipoCategoriaAM Add(TipoCategoriaAM objeto)
        {
            TipoCategoria tipo = mapper.Map<TipoCategoria>(objeto);
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            repository.Add(tipo);
            this.context.SaveChanges();
            TipoCategoriaAM nuevo = mapper.Map<TipoCategoriaAM>(tipo);
            return nuevo;
        }

        public TipoCategoriaAM getTipoCtgId(int id)
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            TipoCategoria tipo = repository.GetId(id);
            return mapper.Map<TipoCategoriaAM>(tipo);
        }

        public TipoCategoriaAM ActualizarTipoCategoria(TipoCategoriaAM objeto)
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            TipoCategoria tipo = mapper.Map<TipoCategoria>(objeto);
            repository.update(tipo);
            this.context.SaveChanges();
            TipoCategoriaAM nuevo = mapper.Map<TipoCategoriaAM>(tipo);
            return nuevo;
        }

        //Categoria
        public IList<CategoriaAM> AllCategorias()
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return mapper.Map<List<CategoriaAM>>(repository.All());
        }

        public CategoriaAM Add(CategoriaAM objeto, int id)
        {
            //Creacion de la Categoria
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            Categoria estado = mapper.Map<Categoria>(objeto);
            repository.Add(estado);
            this.context.SaveChanges();
            CategoriaAM categoria = mapper.Map<CategoriaAM>(estado);

            //Creacion del vinculo inicial
            VncCategoriaTipoCtgAM vinculo = new VncCategoriaTipoCtgAM();
            vinculo.idCategoria = estado.id;
            vinculo.idTipoCtg = id;
            vinculo.codigoEstado = 1;
            vinculo.tipoVinculo = 1;
            vinculo.user = 0;
            this.AgregarVncCategoriaTipoCtg(vinculo);
            return categoria;
        }

        public CategoriaAM GetCategoria(int id)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            CategoriaAM categoria = mapper.Map<CategoriaAM>(repository.GetId(id));
            return categoria;
        }

        public TipoCategoriaAM ObtenerCategoriaTipoCtg(int id)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            TipoCategoriaAM tipo = mapper.Map<TipoCategoriaAM>(repository.getIdCategoria(id));
            return tipo;
        }

        public CategoriaAM ActualizarCategoria(CategoriaAM objeto)
        {
            Categoria categoria = mapper.Map<Categoria>(objeto);
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            repository.update(categoria);
            this.context.SaveChanges();
            CategoriaAM categoriaAM = mapper.Map<CategoriaAM>(categoria);
            return categoriaAM;
        }

        //Subcategory
        public IList<SubcategoriaAM> TodosSubcategoria()
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.All());
        }

        public SubcategoriaAM AgregarSubcategoria(SubcategoriaAM objeto)
        {
            Subcategoria subcategoria = mapper.Map<Subcategoria>(objeto);
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            repository.Add(subcategoria);
            this.context.SaveChanges();
            SubcategoriaAM subcategoriaAM = mapper.Map<SubcategoriaAM>(subcategoria);
            return subcategoriaAM;
        }

        public SubcategoriaAM GetSubCategoria(int id)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            SubcategoriaAM subcategoria = mapper.Map<SubcategoriaAM>(repository.GetId(id));
            return subcategoria;
        }


        //Tercer Nivel
        public IList<TercerNivelAM> TodosTercerNivel()
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return mapper.Map<List<TercerNivelAM>>(repository.All());
        }

        public TercerNivelAM AgregarTercerNivel(TercerNivelAM objeto)
        {
            TercerNivel tercer = mapper.Map<TercerNivel>(objeto);
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            repository.Add(tercer);
            this.context.SaveChanges();
            TercerNivelAM tercerAM = mapper.Map<TercerNivelAM>(tercer);
            return tercerAM;
        }

        public TercerNivelAM ObtenerTercerNivel(int id)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            TercerNivelAM tercer = mapper.Map<TercerNivelAM>(repository.GetId(id));
            return tercer;
        }


        //Tipo recurso
        public IList<TipoRecursoAM> TodosTipoRecurso()
        {
            InterfaceTipoRecurso<TipoRecurso> repository = new RepositoryTipoRecurso(context);
            return mapper.Map<List<TipoRecursoAM>>(repository.All());
        }

        public TipoRecursoAM AgregarTipoRecurso(TipoRecursoAM objeto)
        {
            TipoRecurso tipo = mapper.Map<TipoRecurso>(objeto);
            InterfaceTipoRecurso<TipoRecurso> repository = new RepositoryTipoRecurso(context);
            repository.Add(tipo);
            this.context.SaveChanges();
            TipoRecursoAM nuevo = mapper.Map<TipoRecursoAM>(tipo);
            return nuevo;
        }

        public TipoRecursoAM ObtenerTipoRecurso(int id)
        {
            InterfaceTipoRecurso<TipoRecurso> repository = new RepositoryTipoRecurso(context);
            TipoRecursoAM tipo = mapper.Map<TipoRecursoAM>(repository.GetId(id));
            return tipo;
        }


        //Recurso
        public IList<RecursoAM> TodosRecurso()
        {
            InterfaceRecurso<Recurso> repository = new RepositoryRecurso(context);
            return mapper.Map<List<RecursoAM>>(repository.All());
        }


        //Vinculaciones

        public IList<VncCategoriaTipoCtgAM> TodosVncCategoriaTipoCtg()
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<VncCategoriaTipoCtgAM>>(repository.All());
        }

        public VncCategoriaTipoCtgAM AgregarVncCategoriaTipoCtg(VncCategoriaTipoCtgAM objeto)
        {
            VncCategoriaTipoCtg vinculo = mapper.Map<VncCategoriaTipoCtg>(objeto);
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            repository.Add(vinculo);
            this.context.SaveChanges();
            VncCategoriaTipoCtgAM vinculoAM = mapper.Map<VncCategoriaTipoCtgAM>(objeto);
            return vinculoAM;
        }

        public VncCategoriaTipoCtgAM ObtenerVncCategoriaTipoCtg(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<VncCategoriaTipoCtgAM>(repository.GetId(id));
        }
    }
}