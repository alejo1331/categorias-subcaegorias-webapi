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

        public IList<ElementoTercerNivel> All()
        {
            return this.context.ElementoTercerNivels.ToList();
        }

        public ElementoTercerNivel GetId(int id)
        {
            return context.ElementoTercerNivels.Where(s => s.id == id).FirstOrDefault();
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
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return VentanillaUnicas;
        }

        public IList<SedeElectronica> VinculadasSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.tercerNivelId == id && s.tipoElementoId == 3 && s.codigoEstado == 1).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return SedeElectronicas;
        }

        /*public IList<PPT> VinculadasPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return PPTs;
        }
 
        public IList<PPT> VincularPPT(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.categoriaId == id && s.tipoElementoId == 5).Select(s => s.elementoId).ToList();
            List<PPT> PPTs = this.context.PPTs.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return PPTs;
        }

        

        public IList<SedeElectronica> VincularSedeElectronica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.categoriaId == id && s.tipoElementoId == 3).Select(s => s.elementoId).ToList();
            List<SedeElectronica> SedeElectronicas = this.context.SedeElectronicas.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return SedeElectronicas;
        }
        
        public IList<VentanillaUnica> VinculadasVentanillaUnica(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.categoriaId == id && s.tipoElementoId == 4).Select(s => s.elementoId).ToList();
            List<VentanillaUnica> VentanillaUnicas = this.context.VentanillaUnicas.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return VentanillaUnicas;
        }

        

        public IList<TramiteServicio> VinculadasTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return TramiteServicios;
        }

        public IList<TramiteServicio> VincularTramiteServicio(int id, int page, int size)
        {
            var vinculadas = this.context.ElementoTercerNivels.Where(s => s.categoriaId == id && s.tipoElementoId == 6).Select(s => s.elementoId.ToString()).ToList();
            List<TramiteServicio> TramiteServicios = this.context.TramiteServicios.Where(s => !vinculadas.Contains(s.id)).Skip((page -1 )*size).Take(size).ToList();
            return TramiteServicios;
        }*/
    }
}