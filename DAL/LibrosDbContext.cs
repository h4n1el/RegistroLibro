using Microsoft.EntityFrameworkCore;

namespace RegistroLibros.DAL;

public class LibrosDbContext : DbContext
{
    public LibrosDbContext(DbContextOptions<LibrosDbContext> options) : base(options) { }

    public DbSet<Libro> Libros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>()
            .HasIndex(l => l.Titulo)
            .IsUnique();
    }
}