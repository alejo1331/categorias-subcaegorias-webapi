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

        public CategoriaAM Add(CategoriaAM objeto)
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
            vinculo.idTipoCtg = estado.padre;
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
            //Creacion de la subcategoria
            Subcategoria subcategoria = mapper.Map<Subcategoria>(objeto);
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            repository.Add(subcategoria);
            this.context.SaveChanges();
            SubcategoriaAM subcategoriaAM = mapper.Map<SubcategoriaAM>(subcategoria);

            //Creacion de la vinculacion principal
            VncSubcategoriaCategoriaAM vinculo = new VncSubcategoriaCategoriaAM();
            vinculo.idCategoria = objeto.padre;
            vinculo.idSubcategoria = subcategoria.id;
            vinculo.tipoVinculo = 1;
            vinculo.codigoEstado = 1;
            this.AgregarVncCategoriaSubcategoria(vinculo);
            return subcategoriaAM;
        }

        public SubcategoriaAM GetSubCategoria(int id)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            SubcategoriaAM subcategoria = mapper.Map<SubcategoriaAM>(repository.GetId(id));
            return subcategoria;
        }

        public CategoriaAM GetCategoriaSubcatgoria(int id)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return mapper.Map<CategoriaAM>(repository.GetCategoria(id));
        }

        public SubcategoriaAM ActualizarSubCategoria(SubcategoriaAM objeto)
        {
            Subcategoria subcategoria = mapper.Map<Subcategoria>(objeto);
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            repository.Update(subcategoria);
            this.context.SaveChanges();
            SubcategoriaAM subcategoriaAM = mapper.Map<SubcategoriaAM>(subcategoria);
            return subcategoriaAM;
        }


        //Tercer Nivel
        public IList<TercerNivelAM> TodosTercerNivel()
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return mapper.Map<List<TercerNivelAM>>(repository.All());
        }

        public TercerNivelAM AgregarTercerNivel(TercerNivelAM objeto)
        {
            //Creacion del objeto
            TercerNivel tercer = mapper.Map<TercerNivel>(objeto);
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            repository.Add(tercer);
            this.context.SaveChanges();
            TercerNivelAM tercerAM = mapper.Map<TercerNivelAM>(tercer);

            //Creacion del viculo
            VncTercerNvlSubcategoriaAM vinculo = new VncTercerNvlSubcategoriaAM();
            vinculo.codigoEstado = 1;
            vinculo.idTercerNvl = tercer.id;
            vinculo.idSubcategoria = tercer.padre;
            vinculo.vinculo = 1;
            vinculo.user = 0;
            this.AgregarVncTercerNvlSubcategoria(vinculo);
            return tercerAM;
        }

        public TercerNivelAM ObtenerTercerNivel(int id)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            TercerNivelAM tercer = mapper.Map<TercerNivelAM>(repository.GetId(id));
            return tercer;
        }

        public SubcategoriaAM GetSubcategoriaTercerNvl(int id)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return mapper.Map<SubcategoriaAM>(repository.GetSubcategoria(id));
        }

        public TercerNivelAM ActualizarTercerNivel(TercerNivelAM objeto)
        {
            TercerNivel tercer = mapper.Map<TercerNivel>(objeto);
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            repository.Update(tercer);
            this.context.SaveChanges();
            TercerNivelAM tercerAM = mapper.Map<TercerNivelAM>(tercer);
            return tercerAM;
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

        public RecursoAM AgregarRecurso(RecursoAM objeto)
        {
            return null;
        }

        //Tipo Parametro
        public IList<TipoParametroAM> TodosTipoParamtero()
        {
            InterfaceTipoParametro<TipoParametro> repository = new RepositoryTipoParamtro(context);
            return mapper.Map<List<TipoParametroAM>>(repository.All());
        }

        public TipoParametroAM AgregarTipoParametro(TipoParametroAM objeto)
        {
            TipoParametro tipo = mapper.Map<TipoParametro>(objeto);
            InterfaceTipoParametro<TipoParametro> repository = new RepositoryTipoParamtro(context);
            repository.Add(tipo);
            this.context.SaveChanges();
            TipoParametroAM tipoAM = mapper.Map<TipoParametroAM>(tipo);
            return tipoAM;
        }

        public TipoParametroAM ObtenerTipoParametro(int id)
        {
            InterfaceTipoParametro<TipoParametro> repository = new RepositoryTipoParamtro(context);
            return mapper.Map<TipoParametroAM>(repository.GetId(id));
        }

        public TipoParametroAM ActualizarTipoParametro(TipoParametroAM objeto)
        {
            TipoParametro tipo = mapper.Map<TipoParametro>(objeto);
            InterfaceTipoParametro<TipoParametro> repository = new RepositoryTipoParamtro(context);
            repository.Update(tipo);
            this.context.SaveChanges();
            TipoParametroAM tipoAM = mapper.Map<TipoParametroAM>(tipo);
            return tipoAM;
        }


        //Vinculaciones

        //Tipo Categoria ---- Categoria

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


        // Categoria ----- Subcategoria
        public IList<VncSubcategoriaCategoriaAM> TodosVncCategoriaSubcategoria()
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<VncSubcategoriaCategoriaAM>>(repository.All());
        }

        public VncSubcategoriaCategoriaAM AgregarVncCategoriaSubcategoria(VncSubcategoriaCategoriaAM objeto)
        {
            VncSubcategoriaCategoria vinculo = mapper.Map<VncSubcategoriaCategoria>(objeto);
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            repository.Add(vinculo);
            this.context.SaveChanges();
            VncSubcategoriaCategoriaAM vinculoAM = mapper.Map<VncSubcategoriaCategoriaAM>(vinculo);
            return vinculoAM;
        }

        public VncSubcategoriaCategoriaAM ObtenerVncCategoriaSubcategoria(int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<VncSubcategoriaCategoriaAM>(repository.GetId(id));
        }


        //Subcategoria ---- tercer Nivel
        public IList<VncTercerNvlSubcategoriaAM> TodosVncTercerNvlSubcategoria()
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<VncTercerNvlSubcategoriaAM>>(repository.All());
        }

        public VncTercerNvlSubcategoriaAM AgregarVncTercerNvlSubcategoria(VncTercerNvlSubcategoriaAM objeto)
        {
            VncTercerNvlSubcategoria vinculo = mapper.Map<VncTercerNvlSubcategoria>(objeto);
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            repository.Add(vinculo);
            this.context.SaveChanges();
            VncTercerNvlSubcategoriaAM vinculoAM = mapper.Map<VncTercerNvlSubcategoriaAM>(vinculo);
            return vinculoAM;
        }

        public VncTercerNvlSubcategoriaAM ObtenerVncTercerNvlSubcategoria(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<VncTercerNvlSubcategoriaAM>(repository.GetId(id));
        }


        //Tipo Categoria ---- Recurso
        public IList<VncTipoCtgRecursoAM> TodosVncTipoCtgRecurso()
        {
            InterfaceVncTipoCtgRecurso<VncTipoCtgRecurso> repository = new RepositoryVncTipoCtgRecurso(context);
            return mapper.Map<List<VncTipoCtgRecursoAM>>(repository.All());
        }

        public VncTipoCtgRecursoAM AgregarVncTipoCtgRecurso(VncTipoCtgRecursoAM objeto)
        {
            VncTipoCtgRecurso vinculo = mapper.Map<VncTipoCtgRecurso>(objeto);
            InterfaceVncTipoCtgRecurso<VncTipoCtgRecurso> repository = new RepositoryVncTipoCtgRecurso(context);
            repository.Add(vinculo);
            this.context.SaveChanges();
            VncTipoCtgRecursoAM vinculoAM = mapper.Map<VncTipoCtgRecursoAM>(vinculo);
            return vinculoAM;
        }

        public VncTipoCtgRecursoAM ObtenerVncTipoCtgRecurso(int id)
        {
            InterfaceVncTipoCtgRecurso<VncTipoCtgRecurso> repository = new RepositoryVncTipoCtgRecurso(context);
            return mapper.Map<VncTipoCtgRecursoAM>(repository.GetId(id));
        }

        //Categoria ---- Recurso
        public IList<VncCategoriaRecursoAM> TodosVncCategoriaRecurso()
        {
            InterfaceVncCategoriaRecurso<VncCategoriaRecurso> repository = new RepositoryVncCategoriaRecurso(context);
            return mapper.Map<List<VncCategoriaRecursoAM>>(repository.All());
        }

        public VncCategoriaRecursoAM AgregarVncCategoriaRecurso(VncCategoriaRecursoAM objeto)
        {
            VncCategoriaRecurso vinculo = mapper.Map<VncCategoriaRecurso>(objeto);
            InterfaceVncCategoriaRecurso<VncCategoriaRecurso> repository = new RepositoryVncCategoriaRecurso(context);
            repository.Add(vinculo);
            this.context.SaveChanges();
            VncCategoriaRecursoAM vinculoAM = mapper.Map<VncCategoriaRecursoAM>(vinculo);
            return vinculoAM;
        }

        public VncCategoriaRecursoAM ObtenerVncCategoriaRecurso(int id)
        {
            InterfaceVncCategoriaRecurso<VncCategoriaRecurso> repository = new RepositoryVncCategoriaRecurso(context);
            return mapper.Map<VncCategoriaRecursoAM>(repository.GetId(id));
        }

        //Subcategoria ---- Recurso
        public IList<VncSubcategoriaRecursoAM> TodosVncSubcategoriaRecurso()
        {
            InterfaceVncSubcategoriaRecurso<VncSubcategoriaRecurso> repository = new RepositoryVncSubcategoriaRecurso(context);
            return mapper.Map<List<VncSubcategoriaRecursoAM>>(repository.All());
        }

        public VncSubcategoriaRecursoAM AgregarVncSubcategoriaRecurso(VncSubcategoriaRecursoAM objeto)
        {
            VncSubcategoriaRecurso vinculo = mapper.Map<VncSubcategoriaRecurso>(objeto);
            InterfaceVncSubcategoriaRecurso<VncSubcategoriaRecurso> repository = new RepositoryVncSubcategoriaRecurso(context);
            repository.Add(vinculo);
            this.context.SaveChanges();
            VncSubcategoriaRecursoAM vinculoAM = mapper.Map<VncSubcategoriaRecursoAM>(vinculo);
            return vinculoAM;
        }

        public VncSubcategoriaRecursoAM ObtenerVncSubcategoriaRecurso(int id)
        {
            InterfaceVncSubcategoriaRecurso<VncSubcategoriaRecurso> repository = new RepositoryVncSubcategoriaRecurso(context);
            return mapper.Map<VncSubcategoriaRecursoAM>(repository.GetId(id));
        }

        //Tercer Nivel ---- Recurso
        public IList<VncTercerNvlRecursoAM> TodosVncTercerNvlRecurso()
        {
            InterfaceVncTercerNvlRecurso<VncTercerNvlRecurso> repository = new RepositoryVncTercerNvlRecurso(context);
            return mapper.Map<List<VncTercerNvlRecursoAM>>(repository.All());
        }

        public VncTercerNvlRecursoAM AgregarVncTercerNvlRecurso(VncTercerNvlRecursoAM objeto)
        {
            VncTercerNvlRecurso vinculo = mapper.Map<VncTercerNvlRecurso>(objeto);
            InterfaceVncTercerNvlRecurso<VncTercerNvlRecurso> repository = new RepositoryVncTercerNvlRecurso(context);
            repository.Add(vinculo);
            this.context.SaveChanges();
            VncTercerNvlRecursoAM vinculoAM = mapper.Map<VncTercerNvlRecursoAM>(vinculo);
            return vinculoAM;
        }

        public VncTercerNvlRecursoAM ObtenerVncTercerNvlRecurso(int id)
        {
            InterfaceVncTercerNvlRecurso<VncTercerNvlRecurso> repository = new RepositoryVncTercerNvlRecurso(context);
            return mapper.Map<VncTercerNvlRecursoAM>(repository.GetId(id));
        }
    }
}