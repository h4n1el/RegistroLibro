using Microsoft.EntityFrameworkCore;

namespace RegistroLibros.DAL;

public class LibrosDbContext : DbContext
{
    public LibrosDbContext(DbContextOptions<LibrosDbContext> options) : base(options) { }

    public DbSet<Libro> Libros { get; set; }

    public DbSet<Estudiante> Estudiantes {get; set;}

   
}
