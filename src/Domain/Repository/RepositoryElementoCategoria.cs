using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryElementoCategoria : InterfaceElementoCategoria<ElementoCategoria>
    {
        private readonly Context context;
        public RepositoryElementoCategoria(Context context)
        {
            this.context = context;
        }

        public IList<ElementoCategoria> All()
        {
            return this.context.ElementoCategorias.ToList();
        }

        public ElementoCategoria GetId(int id)
        {
            return context.ElementoCategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public void Add(ElementoCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoCategorias.Add(objeto);
        }

        public IList<PPT> VinculadasPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return PPTs;
        }

        public IList<PPT> VincularPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => !vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return PPTs;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return SedeElectronicas;
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return TramiteServicios;
        }

        public IList<ElementosUnion> TodosElementos(int id, int page, int size)
        {
            var paginado = (page - 1) * size;
            Console.WriteLine(paginado);
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 1 })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2 })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = int.Parse(s.id), nombre = s.nombre, tipo = 3 })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4 })
                                                                .ToList();

            var vinculadas4 = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id).Select(s => s.idRecurso).ToList();
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

        public IList<ElementosUnion> TodosElementos(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 1 })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2 })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = int.Parse(s.id), nombre = s.nombre, tipo = 3 })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4 })
                                                                .ToList();

            var vinculadas4 = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id).Select(s => s.idRecurso).ToList();
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

        public long totalTodos(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id));

            var vinculadas1 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => vinculadas1.Contains(s.id));

            var vinculadas2 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => vinculadas2.Contains(s.id));

            var vinculadas3 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            long PortalTransversals = this.context.PortalTransversals.Count(s => vinculadas3.Contains(s.id));

            var vinculadas4 = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id).Select(s => s.idRecurso).ToList();
            long Recursos = this.context.Recursos.Count(s => vinculadas4.Contains(s.id));

            return (SedeElectronicas+VentanillaUnicas+TramiteServicios+PortalTransversals+Recursos);
        }
    }
}