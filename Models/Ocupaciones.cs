using System.ComponentModel.DataAnnotations;

public class Ocupaciones
{
    [Key]
    public int OcupacionId { get; set; }

    [Required(ErrorMessage = "El salario es Requerido")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El salario debe ser mayor que cero")]
    public Double Salario { get; set; }

    [Required(ErrorMessage ="La Descripcion es Requerida")]
    [MinLength(2)]
    public String? Descripcion { get; set; }

}