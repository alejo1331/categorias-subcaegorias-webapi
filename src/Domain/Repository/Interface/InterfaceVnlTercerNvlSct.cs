using Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Domain.Repository.Interface
{
    public interface InterfaceVnlTercerNvlSct<VncTercerNvlSubcategoria>
    {
        IList<VncTercerNvlSubcategoria> All();
        void Add(VncTercerNvlSubcategoria objeto);
        VncTercerNvlSubcategoria GetId(int id);
        VncTercerNvlSubcategoria GetId(int idpadre, int idhijo);
        void Update(VncTercerNvlSubcategoria objeto);
        IList<TercerNivel> getTercerNivel(int id);
        IList<TercerNivel> Vinculadas(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivel> VinculadasTipoCero(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivel> Vincular(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivel> VinculadasActivas(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivel> VinculadasInactivas(int id, int page, int size, int orden, bool ascd);
        IList<TercerNivel> Vinculadas(int id);
        long VinculadasTota(int id);
        long VinculadasTotaTipoCero(int id);
        long VinculadasTotaActivas(int id);
        long VinculadasTotaInactivas(int id);
        long VincularTota(int id);
    }
}