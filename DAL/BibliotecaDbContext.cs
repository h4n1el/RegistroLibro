using Microsoft.EntityFrameworkCore;

namespace RegistroLibros.DAL;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }

    public DbSet<Libro> Libros { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>()
            .HasIndex(l => l.Titulo)
            .IsUnique();

        modelBuilder.Entity<Estudiante>()
            .HasIndex(e => e.Nombres)
            .IsUnique();
    }
}
