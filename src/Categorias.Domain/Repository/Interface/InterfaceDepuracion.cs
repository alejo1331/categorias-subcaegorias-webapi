using Categorias.Domain.Models;
using System.Collections.Generic;


namespace Categorias.Domain.Repository.Interface
{
    public interface InterfaceDepuracion<Depuracion>
    {
        Depuracion Unico();
    }
}