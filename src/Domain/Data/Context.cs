using Microsoft.EntityFrameworkCore;
using Domain.Models;


namespace Domain.Data
{
    public class Context : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tramites_y_servicios");

            /*modelBuilder.Entity<TipoCategoria>()
            .HasOne(p => p.Estado)
            .WithMany(b => b.TipoCategorias)
            .IsRequired()
            .HasForeignKey(p => p.estado);

            modelBuilder.Entity<TipoCategoria>()
            .HasOne(i => i.Estado)
            .WithMany(c => c.TipoCategorias)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);*/

            base.OnModelCreating(modelBuilder);
        }
    }
}