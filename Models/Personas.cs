using System.ComponentModel.DataAnnotations;

public class Personas
{
    [Key]
    public int PersonaId { get; set; }
    [Required(ErrorMessage = "El Nombre es requerido")]
    public String? Nombre { get; set; }

    [Required(ErrorMessage = "El Telefono es requerido")]
    [MinLength(10, ErrorMessage = "El Telefono debe disponer de 10 digitos")]
    [MaxLength(10, ErrorMessage = "El Telefono debe disponer de 10 digitos")]
    public String? Telefono { get; set; }

    [Required(ErrorMessage = "El Celular es requerido")]
    [MinLength(10, ErrorMessage = "El Celular debe disponer de 10 digitos")]
    [MaxLength(10, ErrorMessage = "El Celular debe disponer de 10 digitos")]
    public String? Celular { get; set; }

    [Required(ErrorMessage = "El Email es requerido")]
    public String? Email { get; set; }
    [Required(ErrorMessage = "La direccion es requerida")]
    public String? Direccion { get; set; }
  [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
    public DateTime FechaNacimiento { get; set; }
    [Required(ErrorMessage = "La ocupacion es requerida")]
    public int OcupacionId { get; set; }

    public double Balance { get; set; }




}