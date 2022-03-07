using System;
using System.Collections.Generic;
using Categorias.Domain.Repository.Interface;
using Categorias.Domain.Models;
using Categorias.Domain.Data;
using System.Linq;


namespace Categorias.Domain.Repository
{
    public class RepositoryDepuracion : InterfaceDepuracion<Depuracion>
    {
        private readonly Context context;
        public RepositoryDepuracion(Context context)
        {
            this.context = context;
        }

        public Depuracion Unico()
        {
            return this.context.Depuracions.FirstOrDefault();
        }
    }
}