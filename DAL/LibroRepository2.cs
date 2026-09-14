namespace RegistroLibros.DAL;

public interface LibroRepository2
{
    Task<List<Libro>> ObtenerTodosAsync();
    Task<Libro?> ObtenerPorIdAsync(int id);
    Task<bool> ExisteTituloAsync(string titulo, int? idExcluir = null);
    Task<(bool exito, string mensaje)> AgregarAsync(Libro libro);
    Task<(bool exito, string mensaje)> ActualizarAsync(Libro libro);
    Task EliminarAsync(int id);
}