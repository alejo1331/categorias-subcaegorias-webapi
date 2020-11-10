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

        public void update(ElementoSubcategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoSubcategorias.Update(objeto);
        }

        public IList<ElementoSubcategoria> All()
        {
            return this.context.ElementoSubcategorias.ToList();
        }

        public ElementoSubcategoria GetId(int id)
        {
            return context.ElementoSubcategorias.Where(s => s.id == id).FirstOrDefault();
        }

        public ElementoSubcategoria GetSedeElectronicaId(int id)
        {
            return context.ElementoSubcategorias.Where(s => s.elementoId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoSubcategoria GetVentanillaUnicaId(int id)
        {
            return context.ElementoSubcategorias.Where(s => s.elementoId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoSubcategoria GetTramiteServicioId(int id)
        {
            return context.ElementoSubcategorias.Where(s => s.elementoId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).FirstOrDefault();
        }

        public ElementoSubcategoria GetPortalTransversalId(int id)
        {
            return context.ElementoSubcategorias.Where(s => s.elementoId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).FirstOrDefault();
        }

        public void Add(ElementoSubcategoria objeto)
        {
            if (objeto == null)
                throw new ArgumentNullException(nameof(objeto));

            this.context.ElementoSubcategorias.Add(objeto);
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                VentanillaUnicas = VentanillaUnicas.Where(s => s.id == idFiltro).ToList();
            }
            else if(tipo == 2)
            {
                VentanillaUnicas = VentanillaUnicas.Where(s => s.nombre.Contains(filtro)).ToList();
            }

            if(orden == 1)
            {
                if(!ascd)
                {
                    VentanillaUnicas = VentanillaUnicas.OrderBy(s => s.id).ToList();
                }
                else
                {
                    VentanillaUnicas = VentanillaUnicas.OrderByDescending(s => s.id).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    VentanillaUnicas = VentanillaUnicas.OrderBy(s => s.nombre).ToList();
                }
                else
                {
                    VentanillaUnicas = VentanillaUnicas.OrderByDescending(s => s.nombre).ToList();
                }
            }
            
            VentanillaUnicas = VentanillaUnicas.Skip((page - 1) * size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                VentanillaUnicas = VentanillaUnicas.Where(s => s.id == idFiltro).ToList();
            }
            else if(tipo == 2)
            {
                VentanillaUnicas = VentanillaUnicas.Where(s => s.nombre.Contains(filtro)).ToList();
            }

            if(orden == 1)
            {
                if(!ascd)
                {
                    VentanillaUnicas = VentanillaUnicas.OrderBy(s => s.id).ToList();
                }
                else
                {
                    VentanillaUnicas = VentanillaUnicas.OrderByDescending(s => s.id).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    VentanillaUnicas = VentanillaUnicas.OrderBy(s => s.nombre).ToList();
                }
                else
                {
                    VentanillaUnicas = VentanillaUnicas.OrderByDescending(s => s.nombre).ToList();
                }
            }
            
            VentanillaUnicas = VentanillaUnicas.Skip((page - 1) * size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return VentanillaUnicas;
        }

        public long VincularVentanillaUnicaTotal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return VentanillaUnicas;
        }

        public long VincularVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            long contador = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                contador = VentanillaUnicas.Count(s => s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                contador = VentanillaUnicas.Count(s => s.nombre.Contains(filtro));
            }
            else
            {
                contador = VentanillaUnicas.Count();
            }
            return contador;
        }

        public long VinculadasVentanillaUnicaTotal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long VentanillaUnicas = this.context.VentanillaUnicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return VentanillaUnicas;
        }

        public long VinculadasVentanillaUnicaTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 4 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = new List<VentanillaUnica>();
            VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            long contador = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                contador = VentanillaUnicas.Count(s => s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                contador = VentanillaUnicas.Count(s => s.nombre.Contains(filtro));
            }
            else
            {
                contador = VentanillaUnicas.Count();
            }
            return contador;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                SedeElectronicas = SedeElectronicas.Where(s => s.id == idFiltro).ToList();
            }
            else if(tipo == 2)
            {
                SedeElectronicas = SedeElectronicas.Where(s => s.nombre.Contains(filtro)).ToList();
            }
            
            if(orden == 1)
            {
                if(!ascd)
                {
                    SedeElectronicas = SedeElectronicas.OrderBy(s => s.id).ToList();
                }
                else
                {
                    SedeElectronicas = SedeElectronicas.OrderByDescending(s => s.id).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    SedeElectronicas = SedeElectronicas.OrderBy(s => s.nombre).ToList();
                }
                else
                {
                    SedeElectronicas = SedeElectronicas.OrderByDescending(s => s.nombre).ToList();
                }
            }
            
            SedeElectronicas = SedeElectronicas.Skip((page - 1) * size).Take(size).ToList();
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                SedeElectronicas = SedeElectronicas.Where(s => s.id == idFiltro).ToList();
            }
            else if(tipo == 2)
            {
                SedeElectronicas = SedeElectronicas.Where(s => s.nombre.Contains(filtro)).ToList();
            }

            if(orden == 1)
            {
                if(!ascd)
                {
                    SedeElectronicas = SedeElectronicas.OrderBy(s => s.id).ToList();
                }
                else
                {
                    SedeElectronicas = SedeElectronicas.OrderByDescending(s => s.id).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    SedeElectronicas = SedeElectronicas.OrderBy(s => s.nombre).ToList();
                }
                else
                {
                    SedeElectronicas = SedeElectronicas.OrderByDescending(s => s.nombre).ToList();
                }
            }
            
            SedeElectronicas = SedeElectronicas.Skip((page - 1) * size).Take(size).ToList();
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return SedeElectronicas;
        }

        public long VincularSedeElectronicaTotal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return SedeElectronicas;
        }

        public long VincularSedeElectronicaTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            long contador = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                contador = SedeElectronicas.Count(s => s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                contador = SedeElectronicas.Count(s => s.nombre.Contains(filtro));
            }
            else
            {
                contador = SedeElectronicas.Count();
            }
            return contador;
        }

        public long VinculadasSedeElectronicaTotal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long SedeElectronicas = this.context.SedeElectronicas.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return SedeElectronicas;
        }

        public long VinculadasSedeElectronicaTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = new List<SedeElectronica>();
            SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            long contador = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                contador = SedeElectronicas.Count(s => s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                contador = SedeElectronicas.Count(s => s.nombre.Contains(filtro));
            }
            else
            {
                contador = SedeElectronicas.Count();
            }
            return contador;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id)).ToList();

            if(tipo == 1)
            {
                TramiteServicios = TramiteServicios.Where(s => s.id == filtro).ToList();
            }
            else if(tipo == 2)
            {
                TramiteServicios = TramiteServicios.Where(s => s.nombre.Contains(filtro)).ToList();
            }
            
            if(orden == 1)
            {
                if(!ascd)
                {
                    TramiteServicios = TramiteServicios.OrderBy(s => s.id).ToList();
                }
                else
                {
                    TramiteServicios = TramiteServicios.OrderByDescending(s => s.id).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    TramiteServicios = TramiteServicios.OrderBy(s => s.nombre).ToList();
                }
                else
                {
                    TramiteServicios = TramiteServicios.OrderByDescending(s => s.nombre).ToList();
                }
            }
            
            TramiteServicios = TramiteServicios.Skip((page - 1) * size).Take(size).ToList();
            return TramiteServicios;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id)).ToList();
            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id)).ToList();

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                TramiteServicios = TramiteServicios.Where(s => s.id == filtro).ToList();
            }
            else if(tipo == 2)
            {
                TramiteServicios = TramiteServicios.Where(s => s.nombre.Contains(filtro)).ToList();
            }

            if(orden == 1)
            {
                if(!ascd)
                {
                    TramiteServicios = TramiteServicios.OrderBy(s => s.id).ToList();
                }
                else
                {
                    TramiteServicios = TramiteServicios.OrderByDescending(s => s.id).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    TramiteServicios = TramiteServicios.OrderBy(s => s.nombre).ToList();
                }
                else
                {
                    TramiteServicios = TramiteServicios.OrderByDescending(s => s.nombre).ToList();
                }
            }
            
            TramiteServicios = TramiteServicios.Skip((page - 1) * size).Take(size).ToList();
            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id)).ToList();
            return TramiteServicios;
        }

        public long VincularTramiteServicioTotal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => !vinculadas.Contains(s.id));
            return TramiteServicios;
        }

        public long VincularTramiteServicioTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO").ToList();
            long contador = 0;

            if(tipo == 1)
            {
                contador = TramiteServicios.Count(s => s.id == filtro);
            }
            else if(tipo == 2)
            {
                contador = TramiteServicios.Count(s => s.nombre.Contains(filtro));
            }
            else
            {
                contador = TramiteServicios.Count();
            }
            return contador;
        }

        public long VinculadasTramiteServicioTotal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
            long TramiteServicios = this.context.TramiteServicios.Count(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO");
            return TramiteServicios;
        }

        public long VinculadasTramiteServicioTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 6 && s.codigoEstado == 1).Select(s => s.elementoId.ToString()).ToList();
           List<TramiteServicio> TramiteServicios = new List<TramiteServicio>();
            TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id) && s.estadoCodigo == "PUBLICADO").ToList();
            long contador = 0;

            if(tipo == 1)
            {
                contador = TramiteServicios.Count(s => s.id == filtro);
            }
            else if(tipo == 2)
            {
                contador = TramiteServicios.Count(s => s.nombre.Contains(filtro));
            }
            else
            {
                contador = TramiteServicios.Count();
            }
            return contador;
        }

        public IList<PortalTransversal> VincularPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                lista = lista.Where(s => s.id == idFiltro).ToList();
            }
            else if(tipo == 2)
            {
                lista = lista.Where(s => s.nombre.Contains(filtro)).ToList();
            }

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.id).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.id).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.nombre).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.nombre).ToList();
                }
            }
            
            lista = lista.Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public IList<PortalTransversal> VincularPortalTransversal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return lista;
        }

        public IList<PortalTransversal> VinculadasPortalTransversal(int id, int page, int size, int orden, bool ascd, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                lista = lista.Where(s => s.id == idFiltro).ToList();
            }
            else if(tipo == 2)
            {
                lista = lista.Where(s => s.nombre.Contains(filtro)).ToList();
            }

            if(orden == 1)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.id).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.id).ToList();
                }
            }
            else if(orden == 2)
            {
                if(!ascd)
                {
                    lista = lista.OrderBy(s => s.nombre).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(s => s.nombre).ToList();
                }
            }
            
            lista = lista.Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public IList<PortalTransversal> VinculadasPortalTransversal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            return lista;
        }

        public long VincularPortalTransversalTotal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long lista = this.context.PortalTransversals.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VincularPortalTransversalTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            long contador = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                contador = lista.Count(s => s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                contador = lista.Count(s => s.nombre.Contains(filtro));
            }
            else
            {
                contador = lista.Count();
            }
            return contador;
        }

        public long VinculadasPortalTransversalTotal(int id)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            long lista = this.context.PortalTransversals.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VinculadasPortalTransversalTotal(int id, int tipo, string filtro)
        {
            var vinculadas = this.context.ElementoSubcategorias.Where(s => s.subcategoriaId == id && s.tipoElementoId == 5 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<PortalTransversal> lista = new List<PortalTransversal>();
            lista = this.context.PortalTransversals.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).ToList();
            long contador = 0;

            if(tipo == 1)
            {
                int idFiltro = int.Parse(filtro);
                contador = lista.Count(s => s.id == idFiltro);
            }
            else if(tipo == 2)
            {
                contador = lista.Count(s => s.nombre.Contains(filtro));
            }
            else
            {
                contador = lista.Count();
            }
            return contador;
        }

        public IList<Recurso> VinculadasRecurso(int id, int page, int size)
        {
            var vinculadas = this.context.VncSubcategoriaRecursos.Where(s => s.idSubCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            List<Recurso> lista = this.context.Recursos.Where(s => vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public IList<Recurso> VincularRecurso(int id, int page, int size)
        {
            var vinculadas = this.context.VncSubcategoriaRecursos.Where(s => s.idSubCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            List<Recurso> lista = this.context.Recursos.Where(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1).Skip((page - 1) * size).Take(size).ToList();
            return lista;
        }

        public long VincularRecursoTotal(int id)
        {
            var vinculadas = this.context.VncSubcategoriaRecursos.Where(s => s.idSubCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            long lista = this.context.Recursos.Count(s => !vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
        }

        public long VinculadasRecursoTotal(int id)
        {
            var vinculadas = this.context.VncSubcategoriaRecursos.Where(s => s.idSubCtg == id && s.codigoEstado == 1).Select(s => s.idRecurso).ToList();
            long lista = this.context.Recursos.Count(s => vinculadas.Contains(s.id) && s.codigoEstado == 1);
            return lista;
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
    }
}