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

        public EstadoAM GetDescripcionEstado(string texto)
        {
            InterfaceEstado<Estado> repository = new RepositoryEstado(context);
            Estado estado = repository.GetDescripcion(texto);
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

        public IList<CategoriaAM> ActivasCategoriasOrden()
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return mapper.Map<List<CategoriaAM>>(repository.ActivasOrden());
        }

        public bool ExisteCategoria(string data, int padre)
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return repository.Existe(data, padre);
        }

        public IList<CategoriaAM> AllCategorias()
        {
            InterfaceCategoria<Categoria> repository = new RepositoryCategoria(context);
            return mapper.Map<List<CategoriaAM>>(repository.All());
        }

        public CategoriaAM Add(CategoriaAM objeto)
        {
            EstadoAM activo = GetDescripcionEstado("Activo");
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
            vinculo.codigoEstado = activo.id;
            vinculo.tipoVinculo = 1;
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

        public bool ExisteSubcategoria(string data, int padre)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return repository.Existe(data, padre);
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
            EstadoAM activo = GetDescripcionEstado("Activo");

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
            vinculo.codigoEstado = activo.id;
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

        public IList<SubcategoriaAM> SonsCategoriaActivas(int id)
        {
            InterfaceSubcategoria<Subcategoria> repository = new RepositorySubcategoria(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.SonsCategoriaActivas(id));
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
        public bool ExisteTercerNivel(string data, int padre)
        {
            InterfaceTercerNivel<TercerNivel> repository = new RepositoryTercerNivel(context);
            return repository.Existe(data, padre);
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
            EstadoAM activo = GetDescripcionEstado("Activo");

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
            vinculo.vinculo = activo.id;
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

        public TipoRecursoAM ObtenerTipoRecursoSigla(string sigla)
        {
            InterfaceTipoRecurso<TipoRecurso> repository = new RepositoryTipoRecurso(context);
            TipoRecursoAM tipo = mapper.Map<TipoRecursoAM>(repository.GetSigla(sigla));
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
            EstadoAM activo = GetDescripcionEstado("Activo");

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
                    vinculo.codigoEstado = activo.id;
                    vinculo.user = 0;
                    vinculo.vinculo = 1;
                    this.AgregarVncTipoCtgRecurso(vinculo);
                }
                else if (recurso.parametro == 2)
                {
                    VncCategoriaRecursoAM vinculo = new VncCategoriaRecursoAM();
                    vinculo.idRecurso = recurso.id;
                    vinculo.idCtg = recurso.idParametro;
                    vinculo.codigoEstado = activo.id;
                    vinculo.user = 0;
                    vinculo.vinculo = 1;
                    this.AgregarVncCategoriaRecurso(vinculo);
                }
                else if (recurso.parametro == 3)
                {
                    VncSubcategoriaRecursoAM vinculo = new VncSubcategoriaRecursoAM();
                    vinculo.idRecurso = recurso.id;
                    vinculo.idSubCtg = recurso.idParametro;
                    vinculo.codigoEstado = activo.id;
                    vinculo.user = 0;
                    vinculo.vinculo = 1;
                    this.AgregarVncSubcategoriaRecurso(vinculo);
                }
                else if (recurso.parametro == 4)
                {
                    VncTercerNvlRecursoAM vinculo = new VncTercerNvlRecursoAM();
                    vinculo.idRecurso = recurso.id;
                    vinculo.idTercerNvl = recurso.idParametro;
                    vinculo.codigoEstado = activo.id;
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

        public TipoParametroAM ObtenerTipoParametroSigla(string sigla)
        {
            InterfaceTipoParametro<TipoParametro> repository = new RepositoryTipoParamtro(context);
            return mapper.Map<TipoParametroAM>(repository.GetSigla(sigla));
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

        public IList<CategoriaAM> VincularCategorias(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<CategoriaAM>>(repository.Vincular(id, page, size, orden, ascd));
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

        public long DesvincularCategoriasVinculadasTotal(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return repository.DesvincularTotalVinculadas(id);
        }

        public long DesvincularCategoriasTotalActivas(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return repository.DesvincularTotalActivas(id);
        }

        public long DesvincularCategoriasTotalInactivas(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return repository.DesvincularTotalInactivas(id);
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

        public VncCategoriaTipoCtgAM ActualizarVncCategoriaTipoCtg(VncCategoriaTipoCtgAM objeto)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            VncCategoriaTipoCtg tipo = mapper.Map<VncCategoriaTipoCtg>(objeto);
            repository.update(tipo);
            this.context.SaveChanges();
            VncCategoriaTipoCtgAM nuevo = mapper.Map<VncCategoriaTipoCtgAM>(tipo);
            return nuevo;
        }

        public VncSubcategoriaCategoriaAM ActualizarVncCategoriaSubcategoria(VncSubcategoriaCategoriaAM objeto)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            VncSubcategoriaCategoria tipo = mapper.Map<VncSubcategoriaCategoria>(objeto);
            repository.Update(tipo);
            this.context.SaveChanges();
            VncSubcategoriaCategoriaAM nuevo = mapper.Map<VncSubcategoriaCategoriaAM>(tipo);
            return nuevo;
        }

        public VncTercerNvlSubcategoriaAM ActualizarVncTercerNvlSubcategoria(VncTercerNvlSubcategoriaAM objeto)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            VncTercerNvlSubcategoria tipo = mapper.Map<VncTercerNvlSubcategoria>(objeto);
            repository.Update(tipo);
            this.context.SaveChanges();
            VncTercerNvlSubcategoriaAM nuevo = mapper.Map<VncTercerNvlSubcategoriaAM>(tipo);
            return nuevo;
        }

        public VncCategoriaTipoCtgAM ObtenerVncCategoriaTipoCtg(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<VncCategoriaTipoCtgAM>(repository.GetId(id));
        }

        public VncCategoriaTipoCtgAM ObtenerVncCategoriaTipoCtg(int padre, int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<VncCategoriaTipoCtgAM>(repository.GetId(padre, id));
        }

        public IList<CategoriaAM> TodosVncCategorias(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<CategoriaAM>>(repository.getCategory(id, page, size, orden, ascd));
        }

        public IList<CategoriaAM> TodosVncCategoriasVinculadas(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<CategoriaAM>>(repository.getCategoryDesvincular(id, page, size, orden, ascd));
        }

        public IList<CategoriaAM> TodosVncCategoriasActivas(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<CategoriaAM>>(repository.getCategoryActivos(id, page, size, orden, ascd));
        }

        public IList<CategoriaAM> TodosVncCategoriasInactivas(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<CategoriaAM>>(repository.getCategoryInactivos(id, page, size, orden, ascd));
        }

        public IList<CategoriaAM> TodosVncCategorias(int id)
        {
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            return mapper.Map<List<CategoriaAM>>(repository.getCategory(id));
        }

        public VncCategoriaTipoCtgAM DesvncCategoriaTipoCtg(int idpadre, int idhijo)
        {
            EstadoAM estado = GetDescripcionEstado("Inactivo");
            InterfaceVclCtgTipoCtg<VncCategoriaTipoCtg> repository = new RepositoryVncCategoriaTipoCtg(context);
            VncCategoriaTipoCtg vinculo = repository.GetId(idpadre, idhijo);
            vinculo.codigoEstado = estado.id;
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
            EstadoAM estado = GetDescripcionEstado("Activo");
            string[] ids = objeto.idscategorias.Split(',');
            foreach (string id in ids)
            {
                VncCategoriaTipoCtgAM nuevo = new VncCategoriaTipoCtgAM();
                nuevo.idTipoCtg = objeto.idTipoCategoria;
                nuevo.idCategoria = int.Parse(id);
                nuevo.codigoEstado = estado.id;
                nuevo.tipoVinculo = 0;
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

        public VncSubcategoriaCategoriaAM ObtenerVncCategoriaSubcategoria(int padre, int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<VncSubcategoriaCategoriaAM>(repository.GetId(padre, id));
        }

        public void VincularSubcategoriasCategoria(DvcSubcategoriaCategoria objeto)
        {
            EstadoAM estado = GetDescripcionEstado("Activo");
            string[] ids = objeto.idssubcategorias.Split(',');
            foreach (string id in ids)
            {
                VncSubcategoriaCategoriaAM nuevo = new VncSubcategoriaCategoriaAM();
                nuevo.idCategoria = objeto.idCategoria;
                nuevo.idSubcategoria = int.Parse(id);
                nuevo.codigoEstado = estado.id;
                nuevo.tipoVinculo = 0;
                nuevo.user = 0;
                AgregarVncCategoriaSubcategoria(nuevo);
            }
        }

        public VncSubcategoriaCategoriaAM DesvncSubcategoriasCategoria(int idpadre, int idhijo)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            VncSubcategoriaCategoria vinculo = repository.GetId(idpadre, idhijo);
            vinculo.codigoEstado = 2;
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

        public IList<SubcategoriaAM> VinculadasSubcategoria(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.Vinculadas(id, page, size, orden, ascd));
        }

        public IList<SubcategoriaAM> VinculadasSubcategoriaTipoCero(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.VinculadasTipoCero(id, page, size, orden, ascd));
        }

        public IList<SubcategoriaAM> VincularSubcategoria(int id)
        {

            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.Vincular(id));
        }

        public IList<SubcategoriaAM> VinculadasSubcategoria(int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.Vinculadas(id));
        }

        public IList<SubcategoriaAM> VincularSubcategoria(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.Vincular(id, page, size, orden, ascd));
        }

        public long VinculadasSubcategoriasTotal(int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return repository.VinculadasTotal(id);
        }

        public long VinculadasSubcategoriasTipoCeroTotal(int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return repository.VinculadasTipoCeroTotal(id);
        }

        public IList<SubcategoriaAM> VinculadasSubcategoriaActivas(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.VinculadasActivas(id, page, size, orden, ascd));
        }

        public IList<SubcategoriaAM> VinculadasSubcategoriaInactivas(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return mapper.Map<List<SubcategoriaAM>>(repository.VinculadasInactivas(id, page, size, orden, ascd));
        }

        public long VinculadasSubcategoriasTotalActivas(int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return repository.VinculadasTotalActivas(id);
        }

        public long VinculadasSubcategoriasTotalInactivas(int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return repository.VinculadasTotalInactivas(id);
        }

        public long VincularSubcategoriasTotal(int id)
        {
            InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria> repository = new RepositoryVncSubcategoriaCtg(context);
            return repository.VincularTotal(id);
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

        public VncTercerNvlSubcategoriaAM ObtenerVncTercerNvlSubcategoria(int padre, int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<VncTercerNvlSubcategoriaAM>(repository.GetId(padre, id));
        }

        public VncTercerNvlSubcategoriaAM DesvncTercerNvlSubcategoria(int idpadre, int idhijo)
        {
            EstadoAM estado = GetDescripcionEstado("Inactivo");
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            VncTercerNvlSubcategoria vinculo = repository.GetId(idpadre, idhijo);
            if (vinculo == null)
                return null;

            vinculo.codigoEstado = estado.id;
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
            EstadoAM estado = GetDescripcionEstado("Activo");
            string[] ids = objeto.idsTercerNivel.Split(',');
            foreach (string id in ids)
            {
                VncTercerNvlSubcategoriaAM nuevo = new VncTercerNvlSubcategoriaAM();
                nuevo.idSubcategoria = objeto.idSubcategoria;
                nuevo.idTercerNvl = int.Parse(id);
                nuevo.codigoEstado = estado.id;
                nuevo.vinculo = 0;
                nuevo.user = 0;
                AgregarVncTercerNvlSubcategoria(nuevo);
            }
        }

        public IList<TercerNivelAM> TodosVncTercerNivel(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<TercerNivelAM>>(repository.getTercerNivel(id));
        }

        public IList<TercerNivelAM> VinculadasTercerNivel(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<TercerNivelAM>>(repository.Vinculadas(id, page, size, orden, ascd));
        }

        public IList<TercerNivelAM> VinculadasTercerNivelTipoCero(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<TercerNivelAM>>(repository.VinculadasTipoCero(id, page, size, orden, ascd));
        }

        public IList<TercerNivelAM> VinculadasTercerNivelActivas(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<TercerNivelAM>>(repository.VinculadasActivas(id, page, size, orden, ascd));
        }

        public IList<TercerNivelAM> VinculadasTercerNivelInactivas(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<TercerNivelAM>>(repository.VinculadasInactivas(id, page, size, orden, ascd));
        }

        public IList<TercerNivelAM> VinculadasTercerNivel(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<TercerNivelAM>>(repository.Vinculadas(id));
        }

        public long VinculadasTercerNivelTotal(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return repository.VinculadasTota(id);
        }

        public long VinculadasTercerNivelTipoCeroTotal(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return repository.VinculadasTotaTipoCero(id);
        }

        public long VinculadasTercerNivelTotalActivas(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return repository.VinculadasTotaActivas(id);
        }

        public long VinculadasTercerNivelTotalInactivas(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return repository.VinculadasTotaInactivas(id);
        }

        public IList<TercerNivelAM> VincularTercerNivel(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return mapper.Map<List<TercerNivelAM>>(repository.Vincular(id, page, size, orden, ascd));
        }

        public long VincularTercerNivelTotal(int id)
        {
            InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria> repository = new RepositroyvVnlTercerNvlSbt(context);
            return repository.VincularTota(id);
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

        public long ObtenerVncCategoriaRecursoTotal(int id)
        {
            InterfaceVncCategoriaRecurso<VncCategoriaRecurso> repository = new RepositoryVncCategoriaRecurso(context);
            return repository.getTotalId(id);
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

        public long ObtenerVncSubcategoriaRecursoTotal(int id)
        {
            InterfaceVncSubcategoriaRecurso<VncSubcategoriaRecurso> repository = new RepositoryVncSubcategoriaRecurso(context);
            return repository.GetTotalId(id);
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

        public long ObtenerVncTercerNvlRecursoTotal(int id)
        {
            InterfaceVncTercerNvlRecurso<VncTercerNvlRecurso> repository = new RepositoryVncTercerNvlRecurso(context);
            return repository.GetTotalId(id);
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

        public IList<ParametrosUnionAM> TodosParametrosTramitesServicios(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return mapper.Map<List<ParametrosUnionAM>>(repository.ListaParametros(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<ParametrosUnionAM> TodosParametrosTramitesServicios(int id)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return mapper.Map<List<ParametrosUnionAM>>(repository.ListaParametros(id));
        }

        public IList<TramiteServicioAM> ListaTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.ListaTramitesServicios(fehcaIncial, fechaFinal, page, size, orden, ascd, tipo, filtro));
        }

        public IList<TramiteServicioAM> ListaTramitesServicios(int page, int size, int orden, bool ascd,string filtro, int tipo)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.ListaTramitesServicios(page, size, orden, ascd,filtro, tipo));
        }

        public IList<TramiteServicioAM> ListaTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.ListaTramitesServicios(fehcaIncial, fechaFinal));
        }

        public long TotalTramitesServicios(DateTime? fehcaIncial, DateTime? fechaFinal, int tipo, string filtro)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return repository.TotalTramitesServicios(fehcaIncial, fechaFinal, tipo, filtro);
        }

        public long TotalTramitesServicios(int tipo, string filtro)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return repository.TotalTramitesServicios(tipo, filtro);
        }

        public long TodosParametrosTramitesServiciosTotal(int id)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return repository.ListaParametrosTotal(id);
        }

        public long TodosParametrosTramitesServiciosTotal(int id, int tipo, string filtro)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return repository.ListaParametrosTotal(id, tipo, filtro);
        }

        public IList<string> AgruparEstadoTramitesServicios(int id)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return repository.AgruparEstado(id);
        }

        public IList<string> AgruparTipoTramitesServicios(int id)
        {
            InterfaceTramiteServicio<TramiteServicio> repository = new RepositoryTramiteServicio(context);
            return repository.AgruparTipo(id);
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

        public IList<ParametrosUnionAM> TodosParametrosVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceVentanillaUnica<VentanillaUnica> repository = new RepositoryVentanillaUnica(context);
            return mapper.Map<List<ParametrosUnionAM>>(repository.ListaParametros(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<ParametrosUnionAM> TodosParametrosVentanillaUnica(int id)
        {
            InterfaceVentanillaUnica<VentanillaUnica> repository = new RepositoryVentanillaUnica(context);
            return mapper.Map<List<ParametrosUnionAM>>(repository.ListaParametros(id));
        }

        public long TodosParametrosVentanillaUnicaTotal(int id)
        {
            InterfaceVentanillaUnica<VentanillaUnica> repository = new RepositoryVentanillaUnica(context);
            return repository.ListaParametrosTotal(id);
        }

        public long TodosParametrosVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            InterfaceVentanillaUnica<VentanillaUnica> repository = new RepositoryVentanillaUnica(context);
            return repository.ListaParametrosTotal(id, tipo, filtro);
        }


        public IList<string> AgruparEstadoVentanillaUnica(int id)
        {
            InterfaceVentanillaUnica<VentanillaUnica> repository = new RepositoryVentanillaUnica(context);
            return repository.AgruparEstado(id);
        }

        public IList<string> AgruparTipoVentanillaUnica(int id)
        {
            InterfaceVentanillaUnica<VentanillaUnica> repository = new RepositoryVentanillaUnica(context);
            return repository.AgruparTipo(id);
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

        public IList<ParametrosUnionAM> TodosParametrosSedesElectronicas(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceSedeElectronica<SedeElectronica> repository = new RepositorySedeElectronica(context);
            return mapper.Map<List<ParametrosUnionAM>>(repository.ListaParametros(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<ParametrosUnionAM> TodosParametrosSedesElectronicas(int id)
        {
            InterfaceSedeElectronica<SedeElectronica> repository = new RepositorySedeElectronica(context);
            return mapper.Map<List<ParametrosUnionAM>>(repository.ListaParametros(id));
        }

        public long TodosParametrosSedesElectronicasTotal(int id)
        {
            InterfaceSedeElectronica<SedeElectronica> repository = new RepositorySedeElectronica(context);
            return repository.ListaParametrosTotal(id);
        }

        public long TodosParametrosSedesElectronicasTotal(int id, int tipo, string filtro)
        {
            InterfaceSedeElectronica<SedeElectronica> repository = new RepositorySedeElectronica(context);
            return repository.ListaParametrosTotal(id, tipo, filtro);
        }

        public IList<string> AgruparEstadoSedesElectronicas(int id)
        {
            InterfaceSedeElectronica<SedeElectronica> repository = new RepositorySedeElectronica(context);
            return repository.AgruparEstado(id);
        }

        public IList<string> AgruparTipoSedesElectronicas(int id)
        {
            InterfaceSedeElectronica<SedeElectronica> repository = new RepositorySedeElectronica(context);
            return repository.AgruparTipo(id);
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

        public TipoElementoAM TipoElementoSigla(string sigla)
        {
            InterfaceTipoElemento<TipoElemento> repository = new RepositoryTipoElemento(context);
            return mapper.Map<TipoElementoAM>(repository.GetSigla(sigla));
        }


        //Elemento Categoria

        public ElementoCategoriaAM ActualizarElementoCategoria(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            repository.update(id);
            this.context.SaveChanges();
            ElementoCategoriaAM nuevo = ElementoCategoriaId(id);
            return nuevo;
        }

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

        public ElementoCategoriaAM ElementoCategoriaSedeElectronicaId(int id, int padre)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<ElementoCategoriaAM>(repository.GetSedeElectronicaId(id, padre));
        }

        public ElementoCategoriaAM ElementoCategoriaVentanillaUnicaId(int id, int padre)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<ElementoCategoriaAM>(repository.GetVentanillaUnicaId(id, padre));
        }

        public ElementoCategoriaAM ElementoCategoriaTramisteServicioId(int id, int padre)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<ElementoCategoriaAM>(repository.GetTramiteServicioId(id, padre));
        }

        public ElementoCategoriaAM ElementoCategoriaPortalTransversalId(int id, int padre)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<ElementoCategoriaAM>(repository.GetPortalTransversalId(id, padre));
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

        public IList<PPTAM> VinculadasPPT(int id, int page, int size)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<PPTAM>>(repository.VinculadasPPT(id, page, size));
        }

        public IList<PPTAM> VincularPPT(int id, int page, int size)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<PPTAM>>(repository.VincularPPT(id, page, size));
        }

        public IList<SedeElectronicaAM> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VinculadasSedeElectronica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<SedeElectronicaAM> VinculadasSedeElectronica(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VinculadasSedeElectronica(id));
        }

        public IList<SedeElectronicaAM> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VincularSedeElectronica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<SedeElectronicaAM> VincularSedeElectronica(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VincularSedeElectronica(id));
        }

        public long VincularSedeElectronicaCategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularSedeElectronicaTotal(id, tipo, filtro);
        }

        public long VincularSedeElectronicaCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularSedeElectronicaTotal(id);
        }

        public long VinculadasSedeElectronicaCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasSedeElectronicaTotal(id);
        }

        public long VinculadasSedeElectronicaCategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasSedeElectronicaTotal(id, tipo, filtro);
        }

        public IList<VentanillaUnicaAM> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VinculadasVentanillaUnica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<VentanillaUnicaAM> VinculadasVentanillaUnica(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VinculadasVentanillaUnica(id));
        }

        public IList<VentanillaUnicaAM> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VincularVentanillaUnica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<VentanillaUnicaAM> VincularVentanillaUnica(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VincularVentanillaUnica(id));
        }

        public long VincularVentanillaUnicaCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularVentanillaUnicaTotal(id);
        }

        public long VincularVentanillaUnicaCategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularVentanillaUnicaTotal(id, tipo, filtro);
        }

        public long VinculadasVentanillaUnicaCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasVentanillaUnicaTotal(id);
        }

        public long VinculadasVentanillaUnicaCategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasVentanillaUnicaTotal(id, tipo, filtro);
        }

        public IList<TramiteServicioAM> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VinculadasTramiteServicio(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<TramiteServicioAM> VinculadasTramiteServicio(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VinculadasTramiteServicio(id));
        }

        public IList<TramiteServicioAM> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VincularTramiteServicio(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<TramiteServicioAM> VincularTramiteServicio(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VincularTramiteServicio(id));
        }

        public long VincularTramiteServicioCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularTramiteServicioTotal(id);
        }

        public long VincularTramiteServicioCategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularTramiteServicioTotal(id, tipo, filtro);
        }

        public long VinculadasTramiteServicioCategoriaTotal(int id)
        {
             InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasTramiteServicioTotal(id);
        }

        public long VinculadasTramiteServicioCategoriaTotal(int id, int tipo, string filtro)
        {
             InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasTramiteServicioTotal(id, tipo, filtro);
        }

        public IList<PortalTransversalAM> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VincularPortalTransversal(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<PortalTransversalAM> VincularPortalTransversal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VincularPortalTransversal(id));
        }

        public IList<PortalTransversalAM> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VinculadasPortalTransversal(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<PortalTransversalAM> VinculadasPortalTransversal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VinculadasPortalTransversal(id));
        }

        public long VincularPortalTransversalCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularPortalTransversalTotal(id);
        }

        public long VincularPortalTransversalCategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularPortalTransversalTotal(id, tipo, filtro);
        }

        public long VinculadasPortalTransversalCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasPortalTransversalTotal(id);
        }

        public long VinculadasPortalTransversalCategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasPortalTransversalTotal(id, tipo, filtro);
        }

        public IList<RecursoAM> VincularRecurso(int id, int page, int size)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<RecursoAM>>(repository.VincularRecurso(id, page, size));
        }

        public IList<RecursoAM> VinculadasRecurso(int id, int page, int size)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<RecursoAM>>(repository.VinculadasRecurso(id, page, size));
        }

        public long VincularRecursoCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VincularRecursoTotal(id);
        }

        public long VinculadasRecursoCategoriaTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.VinculadasRecursoTotal(id);
        }


        /// Elemento Subcategoria

        public ElementoSubcategoriaAM ActualizarElementoSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            repository.update(id);
            this.context.SaveChanges();
            ElementoSubcategoriaAM nuevo = ElementoSubcategoriaId(id);
            return nuevo;
        }
        public IList<ElementoSubcategoriaAM> TodasElementoSubcategoria()
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<ElementoSubcategoriaAM>>(repository.All());
        }

        public ElementoSubcategoriaAM ElementoSubcategoriaId(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<ElementoSubcategoriaAM>(repository.GetId(id));
        }

        public ElementoSubcategoriaAM ElementoSubcategoriaSedeElectronicaId(int id, int padre)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<ElementoSubcategoriaAM>(repository.GetSedeElectronicaId(id, padre));
        }

        public ElementoSubcategoriaAM ElementoSubcategoriaVentanillaUnicaId(int id, int padre)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<ElementoSubcategoriaAM>(repository.GetVentanillaUnicaId(id, padre));
        }

        public ElementoSubcategoriaAM ElementoSubcategoriaTramisteServicioId(int id, int padre)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<ElementoSubcategoriaAM>(repository.GetTramiteServicioId(id, padre));
        }

        public ElementoSubcategoriaAM ElementoSubcategoriaPortalTransversalId(int id, int padre)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<ElementoSubcategoriaAM>(repository.GetPortalTransversalId(id, padre));
        }

        public ElementoSubcategoriaAM AgregarElementoSubcategoria(ElementoSubcategoriaAM objeto)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            ElementoSubcategoria nuevo = mapper.Map<ElementoSubcategoria>(objeto);
            repository.Add(nuevo);
            this.context.SaveChanges();
            ElementoSubcategoriaAM guardado = mapper.Map<ElementoSubcategoriaAM>(nuevo);
            return guardado;
        }

        public IList<SedeElectronicaAM> VincularSedeElectronicaSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VincularSedeElectronica(id, page, size, orden, ascd, tipo, filtro));
        }  

        public IList<SedeElectronicaAM> VincularSedeElectronicaSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VincularSedeElectronica(id));
        }      

        public IList<SedeElectronicaAM> VinculadasSedeElectronicaSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VinculadasSedeElectronica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<SedeElectronicaAM> VinculadasSedeElectronicaSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VinculadasSedeElectronica(id));
        }

        public IList<VentanillaUnicaAM> VinculadasVentanillaUnicaSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VinculadasVentanillaUnica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<VentanillaUnicaAM> VinculadasVentanillaUnicaSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VinculadasVentanillaUnica(id));
        }

        public IList<VentanillaUnicaAM> VincularVentanillaUnicaSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VincularVentanillaUnica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<VentanillaUnicaAM> VincularVentanillaUnicaSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VincularVentanillaUnica(id));
        }
        
        public IList<TramiteServicioAM> VincularTramiteServicioSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VincularTramiteServicio(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<TramiteServicioAM> VincularTramiteServicioSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VincularTramiteServicio(id));
        }

        public IList<TramiteServicioAM> VinculadasTramiteServicioSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VinculadasTramiteServicio(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<TramiteServicioAM> VinculadasTramiteServicioSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VinculadasTramiteServicio(id));
        }

        public IList<PortalTransversalAM> VincularPortalTransversalSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VincularPortalTransversal(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<PortalTransversalAM> VincularPortalTransversalSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VincularPortalTransversal(id));
        }

        public IList<PortalTransversalAM> VinculadasPortalTransversalSubcategoria(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VinculadasPortalTransversal(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<PortalTransversalAM> VinculadasPortalTransversalSubcategoria(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VinculadasPortalTransversal(id));
        }

        public IList<RecursoAM> VincularRecursoSubcategoria(int id, int page, int size)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<RecursoAM>>(repository.VincularRecurso(id, page, size));
        }

        public IList<RecursoAM> VinculadasRecursoSubcategoria(int id, int page, int size)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<RecursoAM>>(repository.VinculadasRecurso(id, page, size));
        }

        public long VincularSedeElectronicaSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularSedeElectronicaTotal(id);
        }

        public long VincularSedeElectronicaSubcategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularSedeElectronicaTotal(id, tipo, filtro);
        }

        public long VinculadasSedeElectronicaSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasSedeElectronicaTotal(id);
        }

        public long VinculadasSedeElectronicaSubcategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasSedeElectronicaTotal(id, tipo, filtro);
        }

        public long VincularVentanillaUnicaSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularVentanillaUnicaTotal(id);
        }

        public long VincularVentanillaUnicaSubcategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularVentanillaUnicaTotal(id, tipo, filtro);
        }

        public long VinculadasVentanillaUnicaSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasVentanillaUnicaTotal(id);
        }

        public long VinculadasVentanillaUnicaSubcategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasVentanillaUnicaTotal(id, tipo, filtro);
        }

        public long VincularTramiteServicioSubcategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularTramiteServicioTotal(id, tipo, filtro);
        }

        public long VincularTramiteServicioSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularTramiteServicioTotal(id);
        }

        public  long VinculadasTramiteServicioSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasTramiteServicioTotal(id);
        }

        public  long VinculadasTramiteServicioSubcategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasTramiteServicioTotal(id, tipo, filtro);
        }

        public long VincularPortalTransversalSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularPortalTransversalTotal(id);
        }

        public long VincularPortalTransversalSubcategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularPortalTransversalTotal(id, tipo, filtro);
        }

        public long VinculadasPortalTransversalSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasPortalTransversalTotal(id);
        }

        public long VinculadasPortalTransversalSubcategoriaTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasPortalTransversalTotal(id, tipo, filtro);
        }

        public long VincularRecursoSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VincularRecursoTotal(id);
        }

        public long VinculadasRecursoSubcategoriaTotal(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.VinculadasRecursoTotal(id);
        }

        //Elemento Tercer Nivel

        public ElementoTercerNivelAM ElementoTercerNivelSedeElectronicaId(int id, int padre)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<ElementoTercerNivelAM>(repository.GetSedeElectronicaId(id, padre));
        }

        public ElementoTercerNivelAM ElementoTercerNivelVentanillaUnicaId(int id, int padre)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<ElementoTercerNivelAM>(repository.GetVentanillaUnicaId(id, padre));
        }

        public ElementoTercerNivelAM ElementoTercerNivelTramisteServicioId(int id, int padre)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<ElementoTercerNivelAM>(repository.GetTramiteServicioId(id, padre));
        }

        public ElementoTercerNivelAM ElementoTercerNivelPortalTransversalId(int id, int padre)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<ElementoTercerNivelAM>(repository.GetPortalTransversalId(id, padre));
        }

        public ElementoTercerNivelAM ActualizarElementoTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            repository.update(id);
            this.context.SaveChanges();
            ElementoTercerNivelAM nuevo = ElementoTercerNivelId(id);
            return nuevo;
        }

        public IList<ElementoTercerNivelAM> TodasElementoTercerNivel()
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<ElementoTercerNivelAM>>(repository.All());
        }

        public ElementoTercerNivelAM ElementoTercerNivelId(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<ElementoTercerNivelAM>(repository.GetId(id));
        }

        public ElementoTercerNivelAM AgregarElementoTercerNivel(ElementoTercerNivelAM objeto)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            ElementoTercerNivel nuevo = mapper.Map<ElementoTercerNivel>(objeto);
            repository.Add(nuevo);
            this.context.SaveChanges();
            ElementoTercerNivelAM guardado = mapper.Map<ElementoTercerNivelAM>(nuevo);
            return guardado;
        }

        public IList<VentanillaUnicaAM> VinculadasVentanillaUnicaTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VinculadasVentanillaUnica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<VentanillaUnicaAM> VinculadasVentanillaUnicaTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VinculadasVentanillaUnica(id));
        }

        public IList<VentanillaUnicaAM> VincularVentanillaUnicaTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VincularVentanillaUnica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<VentanillaUnicaAM> VincularVentanillaUnicaTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<VentanillaUnicaAM>>(repository.VincularVentanillaUnica(id));
        }

        public IList<SedeElectronicaAM> VinculadasSedeElectronicaTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VinculadasSedeElectronica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<SedeElectronicaAM> VinculadasSedeElectronicaTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VinculadasSedeElectronica(id));
        }

        public IList<SedeElectronicaAM> VincularSedeElectronicaTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VincularSedeElectronica(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<SedeElectronicaAM> VincularSedeElectronicaTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<SedeElectronicaAM>>(repository.VincularSedeElectronica(id));
        }

        public IList<TramiteServicioAM> VincularTramiteServicioTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VincularTramiteServicio(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<TramiteServicioAM> VincularTramiteServicioTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VincularTramiteServicio(id));
        }

        public IList<TramiteServicioAM> VinculadasTramiteServicioTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VinculadasTramiteServicio(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<TramiteServicioAM> VinculadasTramiteServicioTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<TramiteServicioAM>>(repository.VinculadasTramiteServicio(id));
        }

        public  IList<PortalTransversalAM> VincularPortalTransversalTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VincularPortalTransversal(id, page, size, orden, ascd, tipo, filtro));
        }

        public  IList<PortalTransversalAM> VincularPortalTransversalTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VincularPortalTransversal(id));
        }

        public IList<PortalTransversalAM> VinculadasPortalTransversalTercerNivel(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VinculadasPortalTransversal(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<PortalTransversalAM> VinculadasPortalTransversalTercerNivel(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.VinculadasPortalTransversal(id));
        }

        public  IList<RecursoAM> VincularRecursoTercerNivel(int id, int page, int size)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<RecursoAM>>(repository.VincularRecurso(id, page, size));
        }

        public IList<RecursoAM> VinculadasRecursoTercerNivel(int id, int page, int size)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<RecursoAM>>(repository.VinculadasRecurso(id, page, size));
        }

        public IList<ElementosUnionAM> Todo(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<ElementosUnionAM>>(repository.TodosElementos(id, page, size, orden, ascd));
        }

        //Porta Transversal
        public IList<PortalTransversalAM> TodasPortalTransversal()
        {
            InterfacePortalTransversal<PortalTransversal> repository = new RepositoryPortalTransversal(context);
            return mapper.Map<List<PortalTransversalAM>>(repository.All());
        }

        public IList<ParametrosUnionAM> TodosParametrosPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            InterfacePortalTransversal<PortalTransversal> repository = new RepositoryPortalTransversal(context);
            return mapper.Map<List<ParametrosUnionAM>>(repository.ListaParametros(id, page, size, orden, ascd, tipo, filtro));
        }

        public IList<ParametrosUnionAM> TodosParametrosPortalTransversal(int id)
        {
            InterfacePortalTransversal<PortalTransversal> repository = new RepositoryPortalTransversal(context);
            return mapper.Map<List<ParametrosUnionAM>>(repository.ListaParametros(id));
        }

        public long TodosParametrosPortalTransversalTotal(int id)
        {
            InterfacePortalTransversal<PortalTransversal> repository = new RepositoryPortalTransversal(context);
            return repository.ListaParametrosTotal(id);
        }

        public long TodosParametrosPortalTransversalTotal(int id, int tipo, string filtro)
        {
            InterfacePortalTransversal<PortalTransversal> repository = new RepositoryPortalTransversal(context);
            return repository.ListaParametrosTotal(id, tipo, filtro);
        }

        public IList<string> AgruparEstadoPortalTransversal(int id)
        {
            InterfacePortalTransversal<PortalTransversal> repository = new RepositoryPortalTransversal(context);
            return repository.AgruparEstado(id);
        }

        public IList<string> AgruparTipoPortalTransversal(int id)
        {
            InterfacePortalTransversal<PortalTransversal> repository = new RepositoryPortalTransversal(context);
            return repository.AgruparTipo(id);
        }
        

        public PortalTransversalAM PortalTransversalId(int id)
        {
            InterfacePortalTransversal<PortalTransversal> repository = new RepositoryPortalTransversal(context);
            return mapper.Map<PortalTransversalAM>(repository.GetId(id));
        }


        public IList<ElementosUnionAM> Todo(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return mapper.Map<List<ElementosUnionAM>>(repository.TodosElementos(id));
        }

        public long VincularSedeElectronicaTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularSedeElectronicaTotal(id);
        }

        public long VincularSedeElectronicaTercerNivelsTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularSedeElectronicaTotal(id, tipo, filtro);
        }

        public long VinculadasSedeElectronicaTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasSedeElectronicaTotal(id);
        }

        public long VinculadasSedeElectronicaTercerNivelsTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasSedeElectronicaTotal(id, tipo, filtro);
        }

        public long VincularVentanillaUnicaTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularVentanillaUnicaTotal(id);
        }

        public long VincularVentanillaUnicaTercerNivelsTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularVentanillaUnicaTotal(id, tipo, filtro);
        }

        public long VinculadasVentanillaUnicaTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasVentanillaUnicaTotal(id);
        }

        public long VinculadasVentanillaUnicaTercerNivelsTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasVentanillaUnicaTotal(id, tipo, filtro);
        }

        public long VincularTramiteServicioTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularTramiteServicioTotal(id);
        }

        public long VincularTramiteServicioTercerNivelsTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularTramiteServicioTotal(id, tipo, filtro);
        }

        public long VinculadasTramiteServicioTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasTramiteServicioTotal(id);
        }

        public long VinculadasTramiteServicioTercerNivelsTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasTramiteServicioTotal(id, tipo, filtro);
        }

        public long VincularPortalTransversalTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularPortalTransversalTotal(id);
        }

        public long VincularPortalTransversalTercerNivelsTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularPortalTransversalTotal(id, tipo, filtro);
        }

        public long VinculadasPortalTransversalTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasPortalTransversalTotal(id);
        }

        public long VinculadasPortalTransversalTercerNivelsTotal(int id, int tipo, string filtro)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasPortalTransversalTotal(id, tipo, filtro);
        }

        public long VincularRecursoTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VincularRecursoTotal(id);
        }

        public long VinculadasRecursoTercerNivelsTotal(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.VinculadasRecursoTotal(id);
        }

        

        public long TodoTotal(int id)
        {
            InterfaceElementoCategoria<ElementoCategoria> repository = new RepositoryElementoCategoria(context);
            return repository.totalTodos(id);
        }

        public IList<ElementosUnionAM> TodoSubcategorias(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<ElementosUnionAM>>(repository.TodosElementos(id));
        }

        public IList<ElementosUnionAM> TodoSubcategorias(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return mapper.Map<List<ElementosUnionAM>>(repository.TodosElementos(id, page, size, orden, ascd));
        }

        public long TodoTotalSubcategorias(int id)
        {
            InterfaceElementoSubcategoria<ElementoSubcategoria> repository = new RepositoryElementoSubcategoria(context);
            return repository.totalTodos(id);
        }

        public IList<ElementosUnionAM> TodoTercerNivels(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<ElementosUnionAM>>(repository.TodosElementos(id));
        }

        public IList<ElementosUnionAM> TodoTercerNivels(int id, int page, int size, int orden, bool ascd)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return mapper.Map<List<ElementosUnionAM>>(repository.TodosElementos(id, page, size, orden, ascd));
        }

        public long TodoTotalTercerNivels(int id)
        {
            InterfaceElementoTercerNivel<ElementoTercerNivel> repository = new RepositoryElementoTercerNivel(context);
            return repository.totalTodos(id);
        }


        //Categoria Suit
        public IList<CategoriaSUITAM> AllCategoriasSuit()
        {
            InterfaceCategoriaSUIT<CategoriaSUIT> repository = new RepositoryCategoriaSUIT(context);
            return mapper.Map<List<CategoriaSUITAM>>(repository.All());
        }

        public CategoriaSUITAM GetCategoriaSuitId(int id)
        {
            InterfaceCategoriaSUIT<CategoriaSUIT> repository = new RepositoryCategoriaSUIT(context);
            return mapper.Map<CategoriaSUITAM>(repository.GetId(id));
        }

        //Vinculo Categoria a Categoria Suit
        public IList<CategoriaCtgSuitAM> AllCategoriaCtgSuit()
        {
            InterfaceCategoriaCtgSuit<CategoriaCtgSuit> repository = new RepositoryCategoriaCtgSuit(context);
            return mapper.Map<List<CategoriaCtgSuitAM>>(repository.All());
        }

        public CategoriaCtgSuitAM GetCategoriaCtgSuitId(int id)
        {
            InterfaceCategoriaCtgSuit<CategoriaCtgSuit> repository = new RepositoryCategoriaCtgSuit(context);
            return mapper.Map<CategoriaCtgSuitAM>(repository.GetId(id));
        }

        public CategoriaCtgSuitAM GetCategoriaCtgSuitId(int idCategoria, int idCategoriaSuit)
        {
            InterfaceCategoriaCtgSuit<CategoriaCtgSuit> repository = new RepositoryCategoriaCtgSuit(context);
            return mapper.Map<CategoriaCtgSuitAM>(repository.GetId(idCategoria, idCategoriaSuit));
        }

        public CategoriaCtgSuitAM AddCategoriaCtgSuit(CategoriaCtgSuitAM objeto)
        {
            InterfaceCategoriaCtgSuit<CategoriaCtgSuit> repository = new RepositoryCategoriaCtgSuit(context);
            CategoriaCtgSuit CategoriaCtgSuit = mapper.Map<CategoriaCtgSuit>(objeto);
            repository.Add(CategoriaCtgSuit);
            this.context.SaveChanges();
            CategoriaCtgSuitAM CategoriaCtgSuitAM = mapper.Map<CategoriaCtgSuitAM>(CategoriaCtgSuit);
            return CategoriaCtgSuitAM;
        }

        public IList<CategoriaCtgSuitAM> AllCategoriaCtgSuitIdCtg(int idCategoria)
        {
            InterfaceCategoriaCtgSuit<CategoriaCtgSuit> repository = new RepositoryCategoriaCtgSuit(context);
            return mapper.Map<List<CategoriaCtgSuitAM>>(repository.GetCategoriasSuit(idCategoria));
        }

        public CategoriaCtgSuitAM updateCategoriaCtgSuitAM(CategoriaCtgSuitAM objeto)
        {
            InterfaceCategoriaCtgSuit<CategoriaCtgSuit> repository = new RepositoryCategoriaCtgSuit(context);
            CategoriaCtgSuit tipo = mapper.Map<CategoriaCtgSuit>(objeto);
            repository.update(tipo);
            this.context.SaveChanges();
            CategoriaCtgSuitAM nuevo = mapper.Map<CategoriaCtgSuitAM>(tipo);
            return nuevo;
        }

        //Vinculo Subcategoria a Categoria Suit
        public IList<SubcategoriaCtgSuitAM> AllSubcategoriaCtgSuit()
        {
            InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit> repository = new RepositorySubcategoriaCtgSuit(context);
            return mapper.Map<List<SubcategoriaCtgSuitAM>>(repository.All());
        }

        public SubcategoriaCtgSuitAM GetSubcategoriaCtgSuitId(int id)
        {
            InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit> repository = new RepositorySubcategoriaCtgSuit(context);
            return mapper.Map<SubcategoriaCtgSuitAM>(repository.GetId(id));
        }

        public SubcategoriaCtgSuitAM GetSubcategoriaCtgSuitId(int idSubcategoria, int idCategoriaSuit)
        {
            InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit> repository = new RepositorySubcategoriaCtgSuit(context);
            return mapper.Map<SubcategoriaCtgSuitAM>(repository.GetId(idSubcategoria, idCategoriaSuit));
        }

        public SubcategoriaCtgSuitAM AddSubcategoriaCtgSuit(SubcategoriaCtgSuitAM objeto)
        {
            InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit> repository = new RepositorySubcategoriaCtgSuit(context);
            SubcategoriaCtgSuit SubcategoriaCtgSuit = mapper.Map<SubcategoriaCtgSuit>(objeto);
            repository.Add(SubcategoriaCtgSuit);
            this.context.SaveChanges();
            SubcategoriaCtgSuitAM SubcategoriaCtgSuitAM = mapper.Map<SubcategoriaCtgSuitAM>(SubcategoriaCtgSuit);
            return SubcategoriaCtgSuitAM;
        }

        public IList<SubcategoriaCtgSuitAM> AllSubcategoriaCtgSuitIdCtg(int idSubcategoria)
        {
            InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit> repository = new RepositorySubcategoriaCtgSuit(context);
            return mapper.Map<List<SubcategoriaCtgSuitAM>>(repository.GetSubcategoriasSuit(idSubcategoria));
        }

        public SubcategoriaCtgSuitAM updateSubcategoriaCtgSuitAM(SubcategoriaCtgSuitAM objeto)
        {
            InterfaceSubcategoriaCtgSuit<SubcategoriaCtgSuit> repository = new RepositorySubcategoriaCtgSuit(context);
            SubcategoriaCtgSuit SubcategoriaCtgSuit = mapper.Map<SubcategoriaCtgSuit>(objeto);
            repository.update(SubcategoriaCtgSuit);
            this.context.SaveChanges();
            SubcategoriaCtgSuitAM SubcategoriaCtgSuitAM = mapper.Map<SubcategoriaCtgSuitAM>(SubcategoriaCtgSuit);
            return SubcategoriaCtgSuitAM;
        }

        public IList<TipoConfiguracionAM> AllTiposConfiguracion()
        {
            InterfaceTipoConfiguracion<TipoConfiguracion> repository = new RepositoryTipoConfiguracion(context);
            return mapper.Map<List<TipoConfiguracionAM>>(repository.All());
        }

        public TipoConfiguracionAM GetTipoConfiguracionId(int id)
        {
            InterfaceTipoConfiguracion<TipoConfiguracion> repository = new RepositoryTipoConfiguracion(context);
            return mapper.Map<TipoConfiguracionAM>(repository.GetId(id));
        }

        public TipoConfiguracionAM GetTipoConfiguracionSigla(string sigla)
        {
            InterfaceTipoConfiguracion<TipoConfiguracion> repository = new RepositoryTipoConfiguracion(context);
            return mapper.Map<TipoConfiguracionAM>(repository.GetSiglaId(sigla));
        }


        //Bitacora 
        public IList<BitacoraCategoriasAM> AllBitacora(int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
             InterfaceBitacora<Bitacora> repository = new RepositoryBitacora(context);
            return mapper.Map<List<BitacoraCategoriasAM>>(repository.All(page, size, orden, ascd, tipo, filtro));
        }

        public IList<BitacoraCategoriasAM> AllBitacora()
        {
            InterfaceBitacora<Bitacora> repository = new RepositoryBitacora(context);
            return mapper.Map<List<BitacoraCategoriasAM>>(repository.All());
        }

        public long TotalBitacora(int tipo, string filtro)
        {
            InterfaceBitacora<Bitacora> repository = new RepositoryBitacora(context);
            return repository.Total(tipo, filtro);
        }

        public BitacoraCategoriasAM GetBitacoraId(int id)
        {
            InterfaceBitacora<Bitacora> repository = new RepositoryBitacora(context);
            return mapper.Map<BitacoraCategoriasAM>(repository.GetId(id));
        }

        public BitacoraCategoriasAM AddBitacora(BitacoraCategoriasAM objeto)
        {
            InterfaceBitacora<Bitacora> repository = new RepositoryBitacora(context);
            Bitacora Bitacora = mapper.Map<Bitacora>(objeto);
            repository.Add(Bitacora);
            this.context.SaveChanges();
            BitacoraCategoriasAM BitacoraCategoriasAM = mapper.Map<BitacoraCategoriasAM>(Bitacora);
            return BitacoraCategoriasAM;
        }

        public IList<string> AgruparTipoConfiguracion()
        {
            InterfaceBitacora<Bitacora> repository = new RepositoryBitacora(context);
            return repository.AgruparTipoConfiguracion();
        }

        public IList<string> AgruparTipoParametro()
        {
            InterfaceBitacora<Bitacora> repository = new RepositoryBitacora(context);
            return repository.AgruparTipoParametro();
        }

    }
}