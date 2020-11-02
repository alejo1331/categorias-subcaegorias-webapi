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
            List<PPT> PPTs = this.context.PPTs.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return PPTs;
        }
 
        public IList<PPT> VincularPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return PPTs;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return SedeElectronicas;
        }

        public IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return SedeElectronicas;
        }
        
        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<VentanillaUnica> VincularVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoCategorias.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return TramiteServicios;
        }
    }
}