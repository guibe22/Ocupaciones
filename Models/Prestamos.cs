using System.ComponentModel.DataAnnotations;

public class Prestamos
{
    [Key]

    public int PrestamoId { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime Vence { get; set; }

    public int PersonaId { get; set; }

    public String? Concepto { get; set; }

    public int Monto { get; set; }
    public int Balance { get; set; }




    
}