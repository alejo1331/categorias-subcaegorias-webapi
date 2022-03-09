using Categorias.Infrastructure.Helpers;
using Categorias.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Infrastructure.Context
{
    public class CategoriasContext: DbContext
    {
        public IConfiguration configuration { get; set; }
        public CategoriasContext()
        {
            configuration = AppSettings.GetConfiguration();
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<TramiteCategoria> TramiteCategoria { get; set; }
        public DbSet<TipoElemento> TipoElemento { get; set; }
        public DbSet<Estado> Estado { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
          optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
}
