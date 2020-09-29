using Microsoft.EntityFrameworkCore;
using Domain.Models;


namespace Domain.Data
{
    public class Context : DbContext
    {
        //Principales
        public DbSet<Estado> Estados { get; set; }
        public DbSet<TipoCategoria> TipoCategorias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<TercerNivel> TercerNivels { get; set; }
        public DbSet<TipoRecurso> TipoRecursos { get; set; }
        public DbSet<Recurso> Recursos { get; set; }

        //Vinculos
        public DbSet<VncCategoriaTipoCtg> VncCategoriaTipoCtgs { get; set; }
        public DbSet<VncSubcategoriaCategoria> VncSubcategoriaCategorias { get; set; }
        public DbSet<VncTercerNvlSubcategoria> VncTercerNvlSubcategorias { get; set; }

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