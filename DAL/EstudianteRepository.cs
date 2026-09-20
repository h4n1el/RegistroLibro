using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RegistroLibros.DAL;

public class EstudianteRepository
{
    private readonly IDbContextFactory<BibliotecaDbContext> DbFactory;

    public EstudianteRepository(IDbContextFactory<BibliotecaDbContext> dbFactory)
    {
        DbFactory = dbFactory;
    }

    public async Task<bool> Existe(int estudianteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AnyAsync(e => e.EstudianteId == estudianteId);
    }

    public async Task<bool> ExisteNombre(string nombres, int? idExcluir = null)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes
            .AnyAsync(e => e.Nombres == nombres && (idExcluir == null || e.EstudianteId != idExcluir));
    }

    private async Task<bool> Insertar(Estudiante estudiante)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Estudiantes.Add(estudiante);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Estudiante estudiante)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(estudiante);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Estudiante estudiante)
    {
        if (!await Existe(estudiante.EstudianteId))
        {
            return await Insertar(estudiante);
        }
        else
        {
            return await Modificar(estudiante);
        }
    }

    public async Task<Estudiante?> Buscar(int estudianteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes
            .FirstOrDefaultAsync(e => e.EstudianteId == estudianteId);
    }

    public async Task<bool> Eliminar(int estudianteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes
            .AsNoTracking()
            .Where(e => e.EstudianteId == estudianteId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Estudiante>> Listar(Expression<Func<Estudiante, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
