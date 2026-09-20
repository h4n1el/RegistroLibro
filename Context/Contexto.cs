using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Models;

namespace RegistrosEstudiante.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) {}

    public DbSet<Estudiantes> Estudiantes {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudiantes>()
                .ToTable("Estudiantes", "dbo");
        }
}