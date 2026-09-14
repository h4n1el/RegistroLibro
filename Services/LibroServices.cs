using RegistroLibros.DAL;

namespace RegistroLibros.Services;

public class LibroServices
{
    private readonly LibroRepository _libroRepository;

    public LibroServices(LibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<List<Libro>> ObtenerTodosAsync()
    {
        return await _libroRepository.Listar(l => l.LibroId > 0);
    }

    public async Task<Libro?> ObtenerPorIdAsync(int id)
    {
        return await _libroRepository.Buscar(id);
    }

    public async Task<bool> Guardar(Libro libro)
    {
        return await _libroRepository.Guardar(libro);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        return await _libroRepository.Eliminar(id);
    }
}
