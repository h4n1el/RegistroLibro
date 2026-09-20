using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RegistroLibros.DAL;

public class LibroRepository
{
    private readonly IDbContextFactory<BibliotecaDbContext> DbFactory;

    public LibroRepository(IDbContextFactory<BibliotecaDbContext> dbFactory)
    {
        DbFactory = dbFactory;
    }

    public async Task<bool> Existe(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros.AnyAsync(l => l.LibroId == libroId);
    }

    public async Task<bool> ExisteTitulo(string titulo, int? idExcluir = null)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
            .AnyAsync(l => l.Titulo == titulo && (idExcluir == null || l.LibroId != idExcluir));
    }

    private async Task<bool> Insertar(Libro libro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Libros.Add(libro);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Libro libro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(libro);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Libro libro)
    {
        if (!await Existe(libro.LibroId))
        {
            return await Insertar(libro);
        }
        else
        {
            return await Modificar(libro);
        }
    }

    public async Task<Libro?> Buscar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
            .FirstOrDefaultAsync(l => l.LibroId == libroId);
    }

    public async Task<bool> Eliminar(int libroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
            .AsNoTracking()
            .Where(l => l.LibroId == libroId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Libro>> Listar(Expression<Func<Libro, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Libros
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
