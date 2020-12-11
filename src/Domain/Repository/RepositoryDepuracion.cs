using System;
using System.Collections.Generic;
using Domain.Repository.Interface;
using Domain.Models;
using Domain.Data;
using System.Linq;


namespace Domain.Repository
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