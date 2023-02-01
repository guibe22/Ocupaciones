using System.ComponentModel.DataAnnotations;

public class Ocupaciones
{
    [Key]
    public int OcupacionId { get; set; }
    public Double Salario { get; set; }
    [Required(ErrorMessage ="La Descripcion es Requerida")]
    public String? Descripcion { get; set; }

}