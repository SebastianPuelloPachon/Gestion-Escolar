using GestionEscolarAPI.Core.Entidades.Agrupaciones.GestionEscolarAPI.Core.Entidades;
using GestionEscolarAPI.Core.Entidades.Agrupaciones;
using GestionEscolarAPI.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Infrastructure.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<EstudianteAsignatura> EstudianteAsignaturas { get; set; }
        public DbSet<PaseDeLista> PaseDeLista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de claves compuestas para la tabla intermedia
            modelBuilder.Entity<EstudianteAsignatura>()
                .HasKey(ea => new { ea.CodigoEstudiante, ea.CodigoAsignatura });

            // Configurar relaciones
            modelBuilder.Entity<Asignatura>()
                .HasOne(a => a.Profesor)
                .WithMany(p => p.Asignaturas)
                .HasForeignKey(a => a.ProfesorID);
        }
    }
}
