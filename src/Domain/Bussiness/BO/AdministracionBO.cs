using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Mvc;


using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Domain.Bussiness.Interface;
using Domain.Categorias.AplicationModel;
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

        public IList<TipoCategoriaAM> SearchTiposCtg(string data)
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            return mapper.Map<List<TipoCategoriaAM>>(repository.Search(data));
        }

        public TipoCategoriaAM CambioEstadoTipoCategoria(int id)
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            repository.ChangeState(id);
            this.context.SaveChanges();
            TipoCategoriaAM objeto = mapper.Map<TipoCategoriaAM>(repository.GetId(id));
            return objeto;
        }

        public long ObtenerTotalTipoCategoria(Expression<Func<TipoCategoriaAM, bool>> predicate)
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            return repository.Count(mapper.Map<Expression<Func<TipoCategoria, bool>>>(predicate));
        }

        public IList<TipoCategoriaAM> ObtenerTipoCategoria(Expression<Func<TipoCategoriaAM, bool>> predicate, int page, int size, Expression<Func<TipoCategoriaAM, object>> selector, bool descending)
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            var predicateMapped = mapper.Map<Expression<Func<TipoCategoria, bool>>>(predicate);
            var selectorMapped = mapper.Map<Expression<Func<TipoCategoria, object>>>(selector);
            return mapper.Map<List<TipoCategoriaAM>>(repository.Get(predicateMapped, page, size, selectorMapped, descending));
        }

        public bool ExisteTipoCategoria(string data)
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            return repository.Existe(data);
        }

        public long CountOrdenTipoCtg(int orden)
        {
            InterfaceTipoCategoria<TipoCategoria> repository = new RepositoryTipoCategoria(context);
            return repository.Count(orden);
        }

        //Categoria

        public long CountOrdenCtg(int orden)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return repository.Count(orden);
        }
        public IList<CategoriaAM> ActivasCategorias()
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return mapper.Map<List<CategoriaAM>>(repository.Activas());
        }

        public bool ExisteCategoria(string data)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return repository.Existe(data);
        }

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

        public IList<CategoriaAM> SearchCategorias(string data)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return mapper.Map<List<CategoriaAM>>(repository.Search(data));
        }

        public IList<CategoriaAM> SonsTipoCategoria(int id)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return mapper.Map<List<CategoriaAM>>(repository.SonsTipoCategoria(id));
        }

        public CategoriaAM CambioEstadoCategoria(int id)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            repository.ChangeState(id);
            this.context.SaveChanges();
            CategoriaAM objeto = mapper.Map<CategoriaAM>(repository.GetId(id));
            return objeto;
        }

        public long ObtenerTotalCategoria(Expression<Func<CategoriaAM, bool>> predicate)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return repository.Count(mapper.Map<Expression<Func<Categoria, bool>>>(predicate));
        }

        public ICollection<CategoriaAM> ObtenerCategoria(Expression<Func<CategoriaAM, bool>> predicate, int page, int size, Expression<Func<CategoriaAM, object>> selector, bool descending)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            var predicateMapped = mapper.Map<Expression<Func<Categoria, bool>>>(predicate);
            var selectorMapped = mapper.Map<Expression<Func<Categoria, object>>>(selector);
            ICollection<Categoria> categorias = repository.Get(predicateMapped, page, size, selectorMapped, descending);
            return mapper.Map<ICollection<CategoriaAM>>(categorias);
        }

        public IList<string> AgruparTiposCtg()
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return repository.Agrupar();
        }

        //Subcategory

        public long CountOrdenSbtg(int orden)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return repository.Count(orden);
        }

        public bool ExisteSubcategoria(string data)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return repository.Existe(data);
        }

        public IList<string> AgruparCtg()
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return repository.Agrupar();
        }
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

        public IList<SubcategoriaAM> SearchSubcategoria(string data)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.Search(data));
        }

        public IList<SubcategoriaAM> SonsCategoria(int id)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.SonsCategoria(id));
        }

        public long ObtenerTotalSubcategoria(Expression<Func<SubcategoriaAM, bool>> predicate)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return repository.Count(mapper.Map<Expression<Func<Subcategoria, bool>>>(predicate));
        }

        public ICollection<SubcategoriaAM> ObtenerSubcategoria(Expression<Func<SubcategoriaAM, bool>> predicate, int page, int size, Expression<Func<SubcategoriaAM, object>> selector, bool descending)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            var predicateMapped = mapper.Map<Expression<Func<Subcategoria, bool>>>(predicate);
            var selectorMapped = mapper.Map<Expression<Func<Subcategoria, object>>>(selector);
            ICollection<Subcategoria> subcategorias = repository.Get(predicateMapped, page, size, selectorMapped, descending);
            return mapper.Map<ICollection<SubcategoriaAM>>(subcategorias);
        }

        public SubcategoriaAM CambioEstadoSubcategoria(int id)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            repository.ChangeState(id);
            this.context.SaveChanges();
            SubcategoriaAM objeto = mapper.Map<SubcategoriaAM>(repository.GetId(id));
            return objeto;
        }


        //Tercer Nivel
        public long CountOrdenTercerNivel(int orden)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return repository.Count(orden);
        }
        public bool ExisteTercerNivel(string data)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return repository.Existe(data);
        }
        public IList<TercerNivelAM> TodosTercerNivel()
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return mapper.Map<List<TercerNivelAM>>(repository.All());
        }

        public IList<string> AgruparScgtTCr()
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return repository.Agrupar();
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

        public IList<TercerNivelAM> SearchTercerNivel(string data)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return mapper.Map<List<TercerNivelAM>>(repository.Search(data));
        }

        public IList<TercerNivelAM> SonsSubcategoria(int id)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return mapper.Map<List<TercerNivelAM>>(repository.SonsSubcategoria(id));
        }

        public TercerNivelAM CambioEstadoTercerNivel(int id)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            repository.ChangeState(id);
            this.context.SaveChanges();
            TercerNivelAM objeto = mapper.Map<TercerNivelAM>(repository.GetId(id));
            return objeto;
        }

        public long ObtenerTotalTercerNivel(Expression<Func<TercerNivelAM, bool>> predicate)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return repository.Count(mapper.Map<Expression<Func<TercerNivel, bool>>>(predicate));
        }

        public ICollection<TercerNivelAM> ObtenerTercerNivel(Expression<Func<TercerNivelAM, bool>> predicate, int page, int size, Expression<Func<TercerNivelAM, object>> selector, bool descending)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            var predicateMapped = mapper.Map<Expression<Func<TercerNivel, bool>>>(predicate);
            var selectorMapped = mapper.Map<Expression<Func<TercerNivel, object>>>(selector);
            ICollection<TercerNivel> TercerNivels = repository.Get(predicateMapped, page, size, selectorMapped, descending);
            return mapper.Map<ICollection<TercerNivelAM>>(TercerNivels);
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
            //Creacion de recurso
            Recurso recurso = mapper.Map<Recurso>(objeto);
            InterfaceRecurso<Recurso> repository = new RepositoryRecurso(context);
            repository.Add(recurso);
            this.context.SaveChanges();
            Console.WriteLine("Tipo Parametro: " + recurso.parametro);
            RecursoAM recursoAM = mapper.Map<RecursoAM>(recurso);

            if (recurso.parametro != null && recurso.idParametro != null)
            {
                //Creacion del vinculo Inical
                if (recurso.parametro == 1)
                {
                    VncTipoCtgRecursoAM vinculo = new VncTipoCtgRecursoAM();
                    vinculo.idRecurso = recurso.id;
                    vinculo.idTipoCtg = recurso.idParametro;
                    vinculo.codigoEstado = 1;
                    vinculo.user = 0;
                    vinculo.vinculo = 1;
                    this.AgregarVncTipoCtgRecurso(vinculo);
                }
                else if (recurso.parametro == 2)
                {
                    VncCategoriaRecursoAM vinculo = new VncCategoriaRecursoAM();
                    vinculo.idRecurso = recurso.id;
                    vinculo.idCtg = recurso.idParametro;
                    vinculo.codigoEstado = 1;
                    vinculo.user = 0;
                    vinculo.vinculo = 1;
                    this.AgregarVncCategoriaRecurso(vinculo);
                }
                else if (recurso.parametro == 3)
                {
                    VncSubcategoriaRecursoAM vinculo = new VncSubcategoriaRecursoAM();
                    vinculo.idRecurso = recurso.id;
                    vinculo.idSubCtg = recurso.idParametro;
                    vinculo.codigoEstado = 1;
                    vinculo.user = 0;
                    vinculo.vinculo = 1;
                    this.AgregarVncSubcategoriaRecurso(vinculo);
                }
                else if (recurso.parametro == 4)
                {
                    VncTercerNvlRecursoAM vinculo = new VncTercerNvlRecursoAM();
                    vinculo.idRecurso = recurso.id;
                    vinculo.idTercerNvl = recurso.idParametro;
                    vinculo.codigoEstado = 1;
                    vinculo.user = 0;
                    vinculo.vinculo = 1;
                    this.AgregarVncTercerNvlRecurso(vinculo);
                }
            }
            return recursoAM;
        }

        public RecursoAM ObtenerRecurso(int id)
        {
            InterfaceRecurso<Recurso> repository = new RepositoryRecurso(context);
            return mapper.Map<RecursoAM>(repository.GetId(id));
        }

        public RecursoAM ActualizarRecurso(RecursoAM objeto)
        {
            Recurso recurso = mapper.Map<Recurso>(objeto);
            InterfaceRecurso<Recurso> repository = new RepositoryRecurso(context);
            repository.Update(recurso);
            this.context.SaveChanges();
            RecursoAM recursoAM = mapper.Map<RecursoAM>(recurso);
            return recursoAM;
        }

        public long ObtenerTotalRecurso(Expression<Func<RecursoAM, bool>> predicate)
        {
            InterfaceRecurso<Recurso> repository = new RepositoryRecurso(context);
            return repository.Count(mapper.Map<Expression<Func<Recurso, bool>>>(predicate));
        }

        public ICollection<RecursoAM> ObtenerRecurso(Expression<Func<RecursoAM, bool>> predicate, int page, int size, Expression<Func<RecursoAM, object>> selector, bool descending)
        {
            InterfaceRecurso<Recurso> repository = new RepositoryRecurso(context);
            var predicateMapped = mapper.Map<Expression<Func<Recurso, bool>>>(predicate);
            var selectorMapped = mapper.Map<Expression<Func<Recurso, object>>>(selector);
            ICollection<Recurso> Recursos = repository.Get(predicateMapped, page, size, selectorMapped, descending);
            return mapper.Map<ICollection<RecursoAM>>(Recursos);
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

        public IList<CategoriaAM> VincularCategorias(int id, int page, int size)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<CategoriaAM>>(repository.Vincular(id, page, size));
        }

        public long VincularCategoriasTotal(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return repository.VincularTotal(id);
        }

        public long DesvincularCategoriasTotal(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return repository.DesvincularTotal(id);
        }

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
            VncCategoriaTipoCtgAM vinculoAM = mapper.Map<VncCategoriaTipoCtgAM>(vinculo);
            return vinculoAM;
        }

        public VncCategoriaTipoCtgAM ObtenerVncCategoriaTipoCtg(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<VncCategoriaTipoCtgAM>(repository.GetId(id));
        }

        public IList<CategoriaAM> TodosVncCategorias(int id, int page, int size)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<CategoriaAM>>(repository.getCategory(id, page, size));
        }

        public VncCategoriaTipoCtgAM DesvncCategoriaTipoCtg(int idpadre, int idhijo)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            VncCategoriaTipoCtg vinculo = repository.GetId(idpadre, idhijo);
            vinculo.tipoVinculo = 0;
            this.context.SaveChanges();
            return mapper.Map<VncCategoriaTipoCtgAM>(vinculo);
        }

        public void DesvncCategoriaTipo(DvcCategoriaTipoCtg objeto)
        {
            string[] ids = objeto.idscategorias.Split(',');
            foreach (string id in ids)
            {
                DesvncCategoriaTipoCtg(objeto.idTipoCategoria, int.Parse(id));
            }
        }

        public void VincularCategoriaTipo(DvcCategoriaTipoCtg objeto)
        {
            string[] ids = objeto.idscategorias.Split(',');
            foreach (string id in ids)
            {
                VncCategoriaTipoCtgAM nuevo = new VncCategoriaTipoCtgAM();
                nuevo.idTipoCtg = objeto.idTipoCategoria;
                nuevo.idCategoria = int.Parse(id);
                nuevo.codigoEstado = 1;
                nuevo.tipoVinculo = 1;
                nuevo.user = 0;
                AgregarVncCategoriaTipoCtg(nuevo);
            }
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

        public void VincularSubcategoriasCategoria(DvcSubcategoriaCategoria objeto)
        {
            string[] ids = objeto.idssubcategorias.Split(',');
            foreach (string id in ids)
            {
                VncSubcategoriaCategoriaAM nuevo = new VncSubcategoriaCategoriaAM();
                nuevo.idCategoria = objeto.idCategoria;
                nuevo.idSubcategoria = int.Parse(id);
                nuevo.codigoEstado = 1;
                nuevo.tipoVinculo = 1;
                nuevo.user = 0;
                AgregarVncCategoriaSubcategoria(nuevo);
            }
        }

        public VncSubcategoriaCategoriaAM DesvncSubcategoriasCategoria(int idpadre, int idhijo)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            VncSubcategoriaCategoria vinculo = repository.GetId(idpadre, idhijo);
            vinculo.tipoVinculo = 0;
            this.context.SaveChanges();
            return mapper.Map<VncSubcategoriaCategoriaAM>(vinculo);
        }

        public void DesvncSubcategoriasCategoria(DvcSubcategoriaCategoria objeto)
        {
            string[] ids = objeto.idssubcategorias.Split(',');
            foreach (string id in ids)
            {
                DesvncSubcategoriasCategoria(objeto.idCategoria, int.Parse(id));
            }
        }

        public IList<SubcategoriaAM> TodosVncSubcategoria(int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.getSubcategory(id));
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

        public VncTercerNvlSubcategoriaAM DesvncTercerNvlSubcategoria(int idpadre, int idhijo)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            VncTercerNvlSubcategoria vinculo = repository.GetId(idpadre, idhijo);
            if (vinculo == null)
                return null;

            vinculo.vinculo = 0;
            repository.Update(vinculo);
            this.context.SaveChanges();
            return mapper.Map<VncTercerNvlSubcategoriaAM>(vinculo);
        }

        public void DesvncTercerNvlSbc(DvcTercerNivelSct objeto)
        {
            string[] ids = objeto.idsTercerNivel.Split(',');
            foreach (string id in ids)
            {
                DesvncTercerNvlSubcategoria(objeto.idSubcategoria, int.Parse(id));
            }
        }

        public void VincularTercerNvlSbc(DvcTercerNivelSct objeto)
        {
            string[] ids = objeto.idsTercerNivel.Split(',');
            foreach (string id in ids)
            {
                VncTercerNvlSubcategoriaAM nuevo = new VncTercerNvlSubcategoriaAM();
                nuevo.idSubcategoria = objeto.idSubcategoria;
                nuevo.idTercerNvl = int.Parse(id);
                nuevo.codigoEstado = 1;
                nuevo.vinculo = 1;
                nuevo.user = 0;
                AgregarVncTercerNvlSubcategoria(nuevo);
            }
        }

        public IList<TercerNivelAM> TodosVncTercerNivel(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<TercerNivelAM>>(repository.getTercerNivel(id));
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



        //Elementos
        public IList<PPTAM> TodasPPT()
        {
            InterfacePPT<PPT> repository = new RepositoryPPT(context);
            return mapper.Map<List<PPTAM>>(repository.All());
        }

        public PPTAM PPTId(int id)
        {
            InterfacePPT<PPT> repository = new RepositoryPPT(context);
            return mapper.Map<PPTAM>(repository.GetId(id));
        }

        //Tramites y servicios
        public IList<TramiteServicioAM> TodasTramiteServicio()
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.All());
        }

        public TramiteServicioAM TramiteServicioId(string id)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return mapper.Map<TramiteServicioAM>(repository.GetId(id));
        }


        //Ventanilla Unica
        public IList<VentanillaUnicaAM> TodasVentanillaUnica()
        {
            InterfaceVentanillaUnica<VentanillaUnica> repository = new RepositoryVentanillaUnica(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.All());
        }

        public VentanillaUnicaAM VentanillaUnicaId(int id)
        {
            InterfaceVentanillaUnica<VentanillaUnica> repository = new RepositoryVentanillaUnica(context);
            return mapper.Map<VentanillaUnicaAM>(repository.GetId(id));
        }


        //Sede electronica
        public IList<SedeElectronicaAM> TodasSedeElectronica()
        {
            InterfaceSedeElectronica<SedeElectronica> repository = new RepositorySedeElectronica(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.All());
        }
        public SedeElectronicaAM SedeElectronicaId(int id)
        {
            InterfaceSedeElectronica<SedeElectronica> repository = new RepositorySedeElectronica(context);
            return mapper.Map<SedeElectronicaAM>(repository.GetId(id));
        }

        //Tipo Elemento
        public IList<TipoElementoAM> TodasTipoElemento()
        {
            InterfaceTipoElemento<TipoElemento> repository = new RepositoryTipoElemento(context);
            return mapper.Map<List<TipoElementoAM>>(repository.All());
        }
        public TipoElementoAM TipoElementoId(int id)
        {
            InterfaceTipoElemento<TipoElemento> repository = new RepositoryTipoElemento(context);
            return mapper.Map<TipoElementoAM>(repository.GetId(id));
        }


        //Elemento Categoria
        public IList<ElementoCategoriaAM> TodasElementoCategoria()
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<ElementoCategoriaAM>>(repository.All());
        }
        public ElementoCategoriaAM ElementoCategoriaId(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<ElementoCategoriaAM>(repository.GetId(id));
        }

        public ElementoCategoriaAM AgregarElementoCategoria(ElementoCategoriaAM objeto)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            ElementoCategoria nuevo = mapper.Map<ElementoCategoria>(objeto);
            repository.Add(nuevo);
            this.context.SaveChanges();
            ElementoCategoriaAM mapeo = mapper.Map<ElementoCategoriaAM>(nuevo);
            return mapeo;
        }
    }
}