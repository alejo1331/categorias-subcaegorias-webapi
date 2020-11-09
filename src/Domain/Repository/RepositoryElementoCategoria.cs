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

        public void update(ElementoCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoCategorias.Update(objeto);
        }

        public IList<ElementoCategoria> All()
        {
            return this.context.ElementoCategorias.ToList();
        }

        public ElementoCategoria GetId(int id)
        {
            return context.ElementoCategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public ElementoCategoria GetSedeElectronicaId(int id)
        {
            return context.ElementoCategorias.Where(s => s.elementoId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoCategoria GetVentanillaUnicaId(int id)
        {
            return context.ElementoCategorias.Where(s => s.elementoId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoCategoria GetTramiteServicioId(int id)
        {
            return context.ElementoCategorias.Where(s => s.elementoId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoCategoria GetPortalTransversalId(int id)
        {
            return context.ElementoCategorias.Where(s => s.elementoId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).FirstOrDefault();
        }

        public void Add(ElementoCategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoCategorias.Add(objeto);
        }

        public IList<PortalTransversal> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            }
            return lista;
        }

        public IList<PortalTransversal> VincularPortalTransversal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return lista;
        }

        public IList<PortalTransversal> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            }
            return lista;
        }

        public IList<PortalTransversal> VinculadasPortalTransversal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return lista;
        }

        public long VincularPortalTransversalTotal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long lista = this.context.PortalTransversals.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VinculadasPortalTransversalTotal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long lista = this.context.PortalTransversals.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public IList<Recurso> VincularRecurso(int id, int page, int size)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            List<Recurso>  lista = this.context.Recursos.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public IList<Recurso> VinculadasRecurso(int id, int page, int size)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            List<Recurso>  lista = this.context.Recursos.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public long VincularRecursoTotal(int id)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            long  lista = this.context.Recursos.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VinculadasRecursoTotal(int id)
        {
            var vinculadas = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            long  lista = this.context.Recursos.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
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

        public IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();

            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            }
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();

            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();

                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();

                }
            }
            else
            {
                SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();

            }
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return SedeElectronicas;
        }

        public long VincularSedeElectronicaTotal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return SedeElectronicas;
        }

        public long VinculadasSedeElectronicaTotal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return SedeElectronicas;
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            if(orden == 1)
            {
                if(!ascd)
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            }
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();

            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            if(orden == 1)
            {
                if(!ascd)
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            }
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return VentanillaUnicas;
        }

        public long VincularVentanillaUnicaTotal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return VentanillaUnicas;
        }

        public long VinculadasVentanillaUnicaTotal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4 ).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => vinculadas.Contains(s.id) );
            return VentanillaUnicas;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) ).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) ).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) ).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) ).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) ).Skip((page - 1) * size).Take(size).ToList();
            }
            return TramiteServicios;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) ).ToList();
            return TramiteServicios;
        }
        

        public IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();

            if(orden == 1)
            {
                if(!ascd)
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) ).OrderBy(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) ).OrderByDescending(s => s.id).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) ).OrderBy(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
                else
                {
                    TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) ).OrderByDescending(s => s.nombre).Skip((page - 1) * size).Take(size).ToList();
                }
            }
            else
            {
                TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) ).Skip((page - 1) * size).Take(size).ToList();
            }

            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) ).ToList();
            return TramiteServicios;
        }

        public long VincularTramiteServicioTotal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => !vinculadas.Contains(s.id));
            return TramiteServicios;
        }

        public long VinculadasTramiteServicioTotal(int id)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => vinculadas.Contains(s.id));
            return TramiteServicios;
        }

        public IList<ElementosUnion> TodosElementos(int id, int page, int size)
        {
            var paginado = (page - 1) * size;
            Console.WriteLine(paginado);
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 1 })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2 })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = int.Parse(s.id), nombre = s.nombre, tipo = 3 })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4 })
                                                                .ToList();

            var vinculadas4 = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
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
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 1 })
                                                                .ToList();

            var vinculadas1 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas1.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 2 })
                                                                .ToList();

            var vinculadas2 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            var TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas2.Contains(s.id))
                                                                .Select(s => new { id = int.Parse(s.id), nombre = s.nombre, tipo = 3 })
                                                                .ToList();

            var vinculadas3 = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            var PortalTransversals = this.context.PortalTransversals.Where(s => vinculadas3.Contains(s.id))
                                                                .Select(s => new { id = s.id, nombre = s.nombre, tipo = 4 })
                                                                .ToList();

            var vinculadas4 = this.context.VncCategoriaRecursos.Where(s => s.idCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
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