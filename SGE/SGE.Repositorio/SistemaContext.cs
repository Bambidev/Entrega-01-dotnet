using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Repositorio
{
    public class SistemaContext : DbContext
    {
        #nullable disable //por las dudas versiones anteriores (diapositiva 63 teoria 10)
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
                .HasOne(t => t.Expediente)        // Tramite tiene un Expediente
                .WithMany(e => e.listaTramites)   // Expediente tiene muchos Tramites
                .HasForeignKey(t => t.IdExpediente); // Usar IdExpediente como clave foránea
        }
    }
}
