using Categorias.Domain.Models;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceSubcategoria<Subcategoria>
    {
        IList<Subcategoria> All();
        void Add(Subcategoria objeto);
        Subcategoria GetId(int id);
        Categoria GetCategoria(int id);
        void Update(Subcategoria objeto);
        IList<Subcategoria> Search(string data);
        IList<Subcategoria> SonsCategoria(int id);
        IList<Subcategoria> SonsCategoriaActivas(int id);
        void ChangeState(int id);
        IList<string> Agrupar();
        bool Existe(string data, int padre);
        int Count(int orden);


        //Paginacion
        int Count(Expression<Func<Subcategoria, bool>> predicate);
        ICollection<Subcategoria> Get(Expression<Func<Subcategoria, bool>> predicate, int page, int size, Expression<Func<Subcategoria, object>> selector, bool descending);
    }
}