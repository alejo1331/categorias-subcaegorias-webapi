using Microsoft.EntityFrameworkCore;
using Categorias.Domain.Models;

namespace Categorias.Domain.Data
{
    public class ContextoParametro : DbContext
    {
        //Principales
    

    public ContextoParametro(DbContextOptions<ContextoParametro> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ficha_tramite");
        base.OnModelCreating(modelBuilder);
    }
        public DbSet<Parametro> Parametro { get; set; }
    }
}
