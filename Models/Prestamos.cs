using System.ComponentModel.DataAnnotations;

public class Prestamos
{
    [Key]

    public int PrestamoId { get; set; }

    [Required(ErrorMessage = "La fecha es requerida")]
    public DateTime Fecha { get; set; }
    
    [Required(ErrorMessage = "La fecha de vencimiento es requerida")]
    public DateTime Vence { get; set; }

    [Required(ErrorMessage = "La Persona  requerida")]
    public int PersonaId { get; set; }

    [Required(ErrorMessage = "el concepto es requerido")]
    public String? Concepto { get; set; }

    [Required(ErrorMessage = "el monto es requerido")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El Monto debe ser mayor que cero")]
    public double Monto { get; set; }

    [Required(ErrorMessage = "el balance  es requerido")]
   
    public double Balance { get; set; }





}