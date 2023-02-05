using System.ComponentModel.DataAnnotations;
public class Pagos
{
    [Key]
    public int PagosId { get; set; }

    public DateTime Fecha { get; set; }

    public int PersonaId { get; set; }

    public String? Concepto{get; set;}

    public int Monto { get; set; }
}