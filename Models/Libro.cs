using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Libro
{
    [Key]
    public int LibroId { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [MaxLength(50)]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El autor es obligatorio.")]
    [MaxLength(50)]
    public string Autor { get; set; } = string.Empty;

    [Required(ErrorMessage = "El año de publicación es obligatorio.")]
    [Range(1, 9999, ErrorMessage = "Ingresa un año válido.")]
    public int AnoPublicacion { get; set; }
}
