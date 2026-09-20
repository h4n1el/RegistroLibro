using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Models;
using RegistrosEstudiante.Context;



public class EstudianteServices(IDbContextFactory<Contexto>  DbFactory)
{
    public async Task<bool> Guardar(Estudiantes estudiantes)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Estudiantes.Add(estudiantes);
        return await contexto.SaveChangesAsync() > 0;
        
    }

    public async Task<bool> Existe(string nombre)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AnyAsync(n => n.Nombre == nombre);
    }

    public async Task<bool> Modificar(Estudiantes estudiantes)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(estudiantes);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int EstudianteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AsNoTracking().Where(e => e.EstudianteId == EstudianteId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Estudiantes?> Buscar(int EstudianteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.FirstOrDefaultAsync(e => e.EstudianteId == EstudianteId);
    }

    public async Task<List<Estudiantes>> ObtenerTodos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AsNoTracking().ToListAsync();
    }
    
}