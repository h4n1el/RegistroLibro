using RegistroLibros.DAL;

namespace RegistroLibros.Services;

public class EstudianteServices
{
    private readonly EstudianteRepository _estudianteRepository;

    public EstudianteServices(EstudianteRepository estudianteRepository)
    {
        _estudianteRepository = estudianteRepository;
    }

    public async Task<List<Estudiante>> ObtenerTodosAsync()
    {
        return await _estudianteRepository.Listar(e => e.EstudianteId > 0);
    }

    public async Task<Estudiante?> ObtenerPorIdAsync(int id)
    {
        return await _estudianteRepository.Buscar(id);
    }

    public async Task<(bool Exito, string? Error)> Guardar(Estudiante estudiante)
    {
        var duplicado = await _estudianteRepository.ExisteNombre(estudiante.Nombres, estudiante.EstudianteId == 0 ? null : estudiante.EstudianteId);
        if (duplicado)
        {
            return (false, "Ya existe un estudiante registrado con ese nombre.");
        }

        var exito = await _estudianteRepository.Guardar(estudiante);
        return exito ? (true, null) : (false, "Error al guardar el estudiante.");
    }

    public async Task<bool> EliminarAsync(int id)
    {
        return await _estudianteRepository.Eliminar(id);
    }
}
