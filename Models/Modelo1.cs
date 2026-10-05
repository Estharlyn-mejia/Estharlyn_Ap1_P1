using System.ComponentModel.DataAnnotations;

namespace Estharlyn_Ap1_P1.Models;

public class Modelo1
{
    [Key]
    public int IdAutor { get; set; }
    
    [Required(ErrorMessage ="Este campo es obligatorio")]

    public string Nombres { get; set; } = string.Empty;
    [Required(ErrorMessage ="Este campo es obligatorio")]

    public string Nacionalidad { get; set; } = string.Empty;
    
    public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage ="Este campo es obligatorio")]
    public int Sueldo { get; set; }

}