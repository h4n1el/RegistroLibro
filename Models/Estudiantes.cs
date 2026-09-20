using System.ComponentModel.DataAnnotations;

public class Estudiante
{
    [Key]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "La dirección es obligatoria.")]
    [MaxLength(200)]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Ingresa un email válido.")]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }
}
