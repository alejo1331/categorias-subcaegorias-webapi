using Categorias.Domain.Models;

using System;
using System.Linq;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceVncSubcategoriaCategoria<VncSubcategoriaCategoria>
    {
        IList<VncSubcategoriaCategoria> All();
        void Add(VncSubcategoriaCategoria objeto);
        VncSubcategoriaCategoria GetId(int id);
        VncSubcategoriaCategoria GetId(int idpadre, int idhijo);
        IList<Subcategoria> getSubcategory(int id);
        void Update(VncSubcategoriaCategoria objeto);
        IList<Subcategoria> Vinculadas(int id, int page, int size, int orden, bool ascd);
        IList<Subcategoria> VinculadasTipoCero(int id, int page, int size, int orden, bool ascd);
        IList<Subcategoria> VinculadasActivas(int id, int page, int size, int orden, bool ascd);
        IList<Subcategoria> VinculadasInactivas(int id, int page, int size, int orden, bool ascd);
        IList<Subcategoria> Vinculadas(int id);
        IList<Subcategoria> Vincular(int id);
        IList<Subcategoria> Vincular(int id, int page, int size, int orden, bool ascd);
        long VinculadasTotal(int id);
        long VinculadasTipoCeroTotal(int id);
        long VinculadasTotalActivas(int id);
        long VinculadasTotalInactivas(int id);
        long VincularTotal(int id);
    }
}