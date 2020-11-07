using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
{
    public class RepositoryElementoTercerNivel : InterfaceElementoTercerNivel<ElementoTercerNivel>
    {
        private readonly Context context;
        public RepositoryElementoTercerNivel(Context context)
        {
            this.context = context;
        }

        public void update(ElementoTercerNivel objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoTercerNivels.Update(objeto);
        }

        public IList<ElementoTercerNivel> All()
        {
            return this.context.ElementoTercerNivels.ToList();
        }

        public ElementoTercerNivel GetId(int id)
        {
            return context.ElementoTercerNivels.Where(s => s.id == id).FirstOrDefault();
        }

        public ElementoTercerNivel GetSedeElectronicaId(int id)
        {
            return context.ElementoTercerNivels.Where(s => s.elementoId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoTercerNivel GetVentanillaUnicaId(int id)
        {
            return context.ElementoTercerNivels.Where(s => s.elementoId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoTercerNivel GetTramiteServicioId(int id)
        {
            return context.ElementoTercerNivels.Where(s => s.elementoId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoTercerNivel GetPortalTransversalId(int id)
        {
            return context.ElementoTercerNivels.Where(s => s.elementoId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).FirstOrDefault();
        }

        public void Add(ElementoTercerNivel objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoTercerNivels.Add(objeto);
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public  long VincularVentanillaUnicaTotal(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return VentanillaUnicas;
        }

        public long VinculadasVentanillaUnicaTotal(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return VentanillaUnicas;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return SedeElectronicas;
        }

        public long VincularSedeElectronicaTotal(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return SedeElectronicas;
        }

        public long VinculadasSedeElectronicaTotal(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return SedeElectronicas;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id)).Skip((page - 1) * size).Take(size).ToList();
            return TramiteServicios;
        }

        public long VincularTramiteServicioTotal(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => !vinculadas.Contains(s.id));
            return TramiteServicios;
        }

        public long VinculadasTramiteServicioTotal(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => vinculadas.Contains(s.id));
            return TramiteServicios;
        }

        public IList<PortalTransversal> VincularPortalTransversal(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            IList<PortalTransversal> lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public IList<PortalTransversal> VinculadasPortalTransversal(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            IList<PortalTransversal> lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public long VincularPortalTransversalTotal(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long lista = this.context.PortalTransversals.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VinculadasPortalTransversalTotal(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long lista = this.context.PortalTransversals.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public IList<Recurso> VinculadasRecurso(int id, int page, int size)
        {
            var vinculadas = this.context.VncTercerNvlRecursos.Where(s => s.idTercerNvl == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            List<Recurso> lista = this.context.Recursos.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public IList<Recurso> VincularRecurso(int id, int page, int size)
        {
            var vinculadas = this.context.VncTercerNvlRecursos.Where(s => s.idTercerNvl == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            List<Recurso> lista = this.context.Recursos.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public long VincularRecursoTotal(int id)
        {
            var vinculadas = this.context.VncTercerNvlRecursos.Where(s => s.idTercerNvl == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            long lista = this.context.Recursos.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VinculadasRecursoTotal(int id)
        {
            var vinculadas = this.context.VncTercerNvlRecursos.Where(s => s.idTercerNvl == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            long lista = this.context.Recursos.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public IList<ElementosUnion> TodosElementos(int id)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 1 })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2 })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = int.Parse(s.id), nombre = s.nombre, tipo = 3 })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4 })
                                                                .ToList();

            var vinculadas4 = this.context.VncTercerNvlRecursos.Where(s => s.idTercerNvl == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
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
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 1 })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2 })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = int.Parse(s.id), nombre = s.nombre, tipo = 3 })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4 })
                                                                .ToList();

            var vinculadas4 = this.context.VncTercerNvlRecursos.Where(s => s.idTercerNvl == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
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
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id));

            var vinculadas1 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => vinculadas1.Contains(s.id));

            var vinculadas2 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => vinculadas2.Contains(s.id));

            var vinculadas3 = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Count(s => vinculadas3.Contains(s.id));

            var vinculadas4 = this.context.VncTercerNvlRecursos.Where(s => s.idTercerNvl == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            var Recursos = this.context.Recursos.Count(s => vinculadas4.Contains(s.id));

            return (SedeElectronicas + VentanillaUnicas + TramiteServicios + PortalTransversals + Recursos);
        }
    }
}