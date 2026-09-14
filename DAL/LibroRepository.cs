using Microsoft.EntityFrameworkCore;

namespace RegistroLibros.DAL;

public class LibroRepository : LibroRepository2
{
    private readonly LibrosDbContext _context;

    public LibroRepository(LibrosDbContext context)
    {
        _context = context;
    }

    public async Task<List<Libro>> ObtenerTodosAsync()
    {
        return await _context.Libros.ToListAsync();
    }

    public async Task<Libro?> ObtenerPorIdAsync(int id)
    {
        return await _context.Libros.FindAsync(id);
    }

    public async Task<bool> ExisteTituloAsync(string titulo, int? idExcluir = null)
    {
        return await _context.Libros
            .AnyAsync(l => l.Titulo == titulo && (idExcluir == null || l.LibroId != idExcluir));
    }

    public async Task<(bool exito, string mensaje)> AgregarAsync(Libro libro)
    {
        if (await ExisteTituloAsync(libro.Titulo))
            return (false, "Ya existe un libro con el título '{libro.Titulo}'.");

        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();
        return (true, "Libro se ha registrado perfectamente.");
    }

    public async Task<(bool exito, string mensaje)> ActualizarAsync(Libro libro)
    {
        if (await ExisteTituloAsync(libro.Titulo, libro.LibroId))
            return (false, "Ya existe otro libro con el título '{libro.Titulo}'.");

        _context.Libros.Update(libro);
        await _context.SaveChangesAsync();
        return (true, "Libro se ha actualizado perfectamente.");
    }

    public async Task EliminarAsync(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro != null)
        {
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
        }
    }
}