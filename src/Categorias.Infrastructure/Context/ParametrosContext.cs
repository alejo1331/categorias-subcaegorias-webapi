using Categorias.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Categorias.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Context
{
   
        public class ParametrosContext : DbContext
        {
            public IConfiguration configuration { get; set; }
            public ParametrosContext()
            {
                configuration = AppSettings.GetConfiguration();
            }

            public DbSet<Parametro> Parametro { get; set; }
         


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
              optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionMastergovco"));
        }
   
}
