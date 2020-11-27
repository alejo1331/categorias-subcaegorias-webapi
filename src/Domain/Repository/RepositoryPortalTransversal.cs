using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryPortalTransversal : InterfacePortalTransversal<PortalTransversal>
    {
        private readonly Context context;
        private Estado activo;
        private Estado inactivo;

        public RepositoryPortalTransversal(Context context)
        {
            this.context = context;
            this.activo = this.context.Estados.Where(s => s.descripcion == "Activo").FirstOrDefault();
            this.inactivo = this.context.Estados.Where(s => s.descripcion == "Inactivo").FirstOrDefault();
        }

        public IList<PortalTransversal> All()
        {
            return this.context.PortalTransversals.ToList();
        }

        public PortalTransversal GetId(int id)
        {
            return context.PortalTransversals.Where(s => s.id == id).FirstOrDefault();
        }

        public IList<ParametrosUnion> ListaParametros(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var paginado = (page - 1) * size;

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<ParametrosUnion> Union = new List<ParametrosUnion>();
            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel).ToList();

            if(tipo == 2)
            {
                union = union.Where(s => s.tipo == 2).ToList();
            }
            else if(tipo == 3)
            {
                union = union.Where(s => s.tipo == 3).ToList();
            }
            else if(tipo == 4)
            {
                union = union.Where(s => s.tipo == 4).ToList();
            }

            //Filtro por Activo/Inactivo
            if(filtro == "1")
            {
                union = union.Where(s => s.estado == this.activo.id).ToList();
            }
            else if(filtro == "2")
            {
                union = union.Where(s => s.estado == this.inactivo.id).ToList();
            }

            if(orden == 1)
            {
                if(!ascd)
                {
                    union = union.OrderBy(s => s.orden).Skip(paginado).Take(size).ToList();
                }
                else
                {
                    union = union.OrderByDescending(s => s.orden).Skip(paginado).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    union = union.OrderBy(s => s.tipo).Skip(paginado).Take(size).ToList();
                }
                else
                {
                    union = union.OrderByDescending(s => s.tipo).Skip(paginado).Take(size).ToList();
                }
            }
            else
            {
                union = union.Skip(paginado).Take(size).ToList();
            }  

            foreach (var item in union)
            {
                Union.Add(new ParametrosUnion(){
                    id = item.id,
                    nombre = item.nombre,
                    tipo = item.tipo,
                    orden = item.orden,
                    estado = item.estado,
                    descripcion = item.descripcion
                });
            }

            return Union;
        }

        public IList<ParametrosUnion> ListaParametros(int id)
        {

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<ParametrosUnion> Union = new List<ParametrosUnion>();
            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel).ToList();            

            foreach (var item in union)
            {
                Union.Add(new ParametrosUnion(){
                    id = item.id,
                    nombre = item.nombre,
                    tipo = item.tipo,
                    orden = item.orden,
                    estado = item.estado,
                    descripcion = item.descripcion
                });
            }

            return Union;
        }

        public IList<string> AgruparEstado(int id)
        {
            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<String> lista = new List<string>();

            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel);
            var sql = union.ToList().GroupBy(s => s.estado);
            foreach (var item in sql)
            {
                foreach (var x in item)
                {
                    if(x.estado == 1)
                        lista.Add("Activo");
                    else 
                        lista.Add("Inactivo");

                    break;
                }
            }
            

            return lista;
        }

        public IList<string> AgruparTipo(int id)
        {
            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<String> lista = new List<string>();

            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel);
            var sql = union.ToList().GroupBy(s => s.tipo);

            foreach (var item in sql)
            {
                foreach (var x in item)
                {
                    if(x.tipo == 2)
                        lista.Add("Categoria");
                    else if(x.tipo == 3)
                        lista.Add("Subcategoria");
                    else if(x.tipo == 4)
                        lista.Add("Tercer Nivel");

                    break;
                }
            }
            

            return lista;
        }

        public long ListaParametrosTotal(int id)
        {
            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            long categorias = this.context.Categorias.Count(s => vinculos.Contains(s.id));
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            long subcategorias = this.context.Subcategorias.Count(s => vinculos1.Contains(s.id));

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            long tercerNivel = this.context.TercerNivels.Count(s => vinculos2.Contains(s.id));
            
            return (categorias + subcategorias + tercerNivel);
        }

        public long ListaParametrosTotal(int id, int tipo, string filtro)
        {

            var vinculos = this.context.ElementoCategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.categoriaId)
                                                            .ToList();

            var categorias = this.context.Categorias.Where(s => vinculos.Contains(s.id))
                                                    .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                    .ToList();
            
            var vinculos1 = this.context.ElementoSubcategorias.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.subcategoriaId)
                                                            .ToList();
            
            var subcategorias = this.context.Subcategorias.Where(s => vinculos1.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 3, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            var vinculos2 = this.context.ElementoTercerNivels.Where(s => s.tipoElementoId == 5 && s.codigoEstado == this.activo.id && s.elementoId == id)
                                                            .Select(s => s.tercerNivelId)
                                                            .ToList();

            var tercerNivel = this.context.TercerNivels.Where(s => vinculos2.Contains(s.id))
                                                        .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4, estado = s.codigoEstado, orden = s.orden, descripcion = s.descripcionCorta })
                                                        .ToList();

            List<ParametrosUnion> Union = new List<ParametrosUnion>();
            var union = categorias.Union(subcategorias);
            union = union.Union(tercerNivel).ToList();

            if(tipo == 2)
            {
                union = union.Where(s => s.tipo == 2).ToList();
            }
            else if(tipo == 3)
            {
                union = union.Where(s => s.tipo == 3).ToList();
            }
            else if(tipo == 4)
            {
                union = union.Where(s => s.tipo == 4).ToList();
            }

            //Filtro por Activo/Inactivo
            if(filtro == "1")
            {
                union = union.Where(s => s.estado == this.activo.id).ToList();
            }
            else if(filtro == "2")
            {
                union = union.Where(s => s.estado == this.inactivo.id).ToList();
            }

            return union.Count();
        }
    }
}