using RegistroLibros.DAL;
namespace RegistroLibros.Services;

public class LibroServices
{
    private readonly LibroRepository2 _libroRepository;

    public LibroServices(LibroRepository2 libroRepository)
    {
        _libroRepository = libroRepository;
    }
    public async Task<List<Libro>> ObtenerTodosAsync()
    {
        return await _libroRepository.ObtenerTodosAsync();
    }

  
    public async Task<Libro?> ObtenerPorIdAsync(int id)
    {
        return await _libroRepository.ObtenerPorIdAsync(id);
    }

    public async Task<(bool exito, string mensaje)> Guardar(Libro libro)
    {
        if (libro.LibroId == 0)
        {
            return await _libroRepository.AgregarAsync(libro);
        }
        else
        {
            return await _libroRepository.ActualizarAsync(libro);
        }
    }
    public async Task<(bool exito, string mensaje)> Actualizar(Libro libro)
    {
        return await _libroRepository.ActualizarAsync(libro);
    }

    
    public async Task<(bool exito, string mensaje)> ModificarAsync(Libro libro)
    {
        return await Actualizar(libro);
    }

   
    public async Task EliminarAsync(int id)
    {
        await _libroRepository.EliminarAsync(id);
    }
}