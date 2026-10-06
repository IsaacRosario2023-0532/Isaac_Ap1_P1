using System.ComponentModel.DataAnnotations;

namespace Isaac_Ap1_P1.Models;

public class Autores
{
    [Key]
    public int IdAutor { get; set; }

    [Required(ErrorMessage = "El campo Nombres es obligatorio")]
    public string Nombres { get; set; } = string.Empty;

    public string? Nacionalidad { get; set; } 

    public DateTime FechaNacimiento { get; set; } = DateTime.Today;

    [Range(0, 999999999, ErrorMessage = "El sueldo no puede ser negativo")]
    public decimal Sueldo { get; set; } 
}