using System.ComponentModel.DataAnnotations;
namespace RegistroEstudiante.Models;

public class Estudiantes
{
    [Key]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int EstudianteId {get; set;}

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Nombre {get; set;}

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Email {get; set;}

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Direccion {get; set;}

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int FechaNacimiento {get; set;}


}