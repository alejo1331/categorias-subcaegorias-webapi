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
        public DbSet<TipoParametro> TipoParametros { get; set; }
        public DbSet<PPT> PPTs { get; set; }
        public DbSet<TramiteServicio> TramiteServicios { get; set; }
        public DbSet<VentanillaUnica> VentanillaUnicas { get; set; } 
        public DbSet<SedeElectronica> SedeElectronicas { get; set; }  
        public DbSet<TipoElemento> TipoElementos { get; set; }   
        public DbSet<ElementoCategoria> ElementoCategorias { get; set; }
        public DbSet<ElementoSubcategoria> ElementoSubcategorias { get; set; }
        public DbSet<ElementoTercerNivel> ElementoTercerNivels { get; set; }
        public DbSet<PortalTransversal> PortalTransversals { get; set; }      
        

        //Vinculos
        public DbSet<VncCategoriaTipoCtg> VncCategoriaTipoCtgs { get; set; }
        public DbSet<VncSubcategoriaCategoria> VncSubcategoriaCategorias { get; set; }
        public DbSet<VncTercerNvlSubcategoria> VncTercerNvlSubcategorias { get; set; }
        public DbSet<VncTipoCtgRecurso> VncTipoCtgRecursos { get; set; }
        public DbSet<VncCategoriaRecurso> VncCategoriaRecursos { get; set; }
        public DbSet<VncSubcategoriaRecurso> VncSubcategoriaRecursos { get; set; }
        public DbSet<VncTercerNvlRecurso> VncTercerNvlRecursos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tramites_y_servicios");
            base.OnModelCreating(modelBuilder);
        }
    }
}