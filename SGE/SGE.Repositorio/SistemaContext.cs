using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorio
{
    public class SistemaContext : DbContext
    {
        #nullable disable //por las dudas versiones anteriores (diapositiva 63 teoria 10)
        
        public DbSet<EPermiso> Permisos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Tramite> Tramites { get; set; }
        #nullable restore

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("data source=Sistema.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tramite>()
                .HasOne(t => t.Expediente)        // tramite tiene un expediente
                .WithMany(e => e.listaTramites)   // expediente tiene muchos tramites
                .HasForeignKey(t => t.IdExpediente); // usar idexpediente como clave secundaria

     
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Permisos) //un usuario puede tener muchos permisos
                .WithOne(ep => ep.poseedorPermiso) //cada permiso tiene su unico usuario asingado
                .HasForeignKey(ep => ep.IdUsuario) //permiso se relaciona con usuario con la clave secundaria idUsuario
                .IsRequired(); //cada usuario debe si o si relacionarse con un EPermiso

            modelBuilder.Entity<EPermiso>()
                .HasOne(ep => ep.poseedorPermiso) //cada permiso tiene solo un poseedor
                .WithMany(u => u.Permisos)  //cada usuario puede tener muchos permisos
                .HasForeignKey(ep => ep.IdUsuario) 
                .IsRequired(); //cada permisos de usuario debe tener si osi un usuario
        }
    }
}