using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryElementoSubcategoria : InterfaceElementoSubcategoria<ElementoSubcategoria>
    {
        private readonly Context context;
        public RepositoryElementoSubcategoria(Context context)
        {
            this.context = context;
        }

        public IList<ElementoSubcategoria> All()
        {
            return this.context.ElementoSubcategorias.ToList();
        }

        public ElementoSubcategoria GetId(int id)
        {
            return context.ElementoSubcategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public void Add(ElementoSubcategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoSubcategorias.Add(objeto);
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return SedeElectronicas;
        }

        public IList<ElementosUnion> TodosElementos(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 1 })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2 })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = int.Parse(s.id), nombre = s.nombre, tipo = 3 })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4 })
                                                                .ToList();

            var vinculadas4 = this.context.VncSubcategoriaRecursos.Where(s => s.idSubCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            var Recursos = this.context.Recursos.Where(s => vinculadas4.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 5 })
                                                                .ToList();


            List<ElementosUnion> Union = new List<ElementosUnion>();

            var union = SedeElectronicas.Union(VentanillaUnicas);

            union = union.Union(PortalTransversals);

            union = union.Union(Recursos);

            union = union.Union(TramiteServicios);

            foreach (var item in union)
            {
                Union.Add(new ElementosUnion() { id = item.id, nombre = item.nombre, tipo = item.tipo });
            }
            return Union;
        }

        public IList<ElementosUnion> TodosElementos(int id, int page, int size)
        {
            var paginado = (page - 1) * size;
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 1 })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2 })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = int.Parse(s.id), nombre = s.nombre, tipo = 3 })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4 })
                                                                .ToList();

            var vinculadas4 = this.context.VncSubcategoriaRecursos.Where(s => s.idSubCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            var Recursos = this.context.Recursos.Where(s => vinculadas4.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 5 })
                                                                .ToList();


            List<ElementosUnion> Union = new List<ElementosUnion>();

            var union = SedeElectronicas.Union(VentanillaUnicas);

            union = union.Union(PortalTransversals);

            union = union.Union(Recursos);

            union = union.Union(TramiteServicios).Skip(paginado).Take(size);

            foreach (var item in union)
            {
                Union.Add(new ElementosUnion() { id = item.id, nombre = item.nombre, tipo = item.tipo });
            }
            return Union;
        }

        public long totalTodos(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id));

            var vinculadas1 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => vinculadas1.Contains(s.id));

            var vinculadas2 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => vinculadas2.Contains(s.id));

            var vinculadas3 = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long PortalTransversals = this.context.PortalTransversals.Count(s => vinculadas3.Contains(s.id));

            var vinculadas4 = this.context.VncSubcategoriaRecursos.Where(s => s.idSubCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            var Recursos = this.context.Recursos.Count(s => vinculadas4.Contains(s.id));

            return (SedeElectronicas + VentanillaUnicas + TramiteServicios + PortalTransversals + Recursos);
        }

        /*public IList<PPT> VinculadasPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return PPTs;
        }
 
        public IList<PPT> VincularPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return PPTs;
        }        

        public IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return SedeElectronicas;
        }
        
        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return VentanillaUnicas;
        }

        

        public IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return TramiteServicios;
        }*/
    }
}