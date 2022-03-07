using Categorias.Domain.Models;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceEstado<Estado>
    {
        IList<Estado> All();
        void Add(Estado objeto);
        Estado GetId(int id);
        Estado GetDescripcion(string texto);
    }
}