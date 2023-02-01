using System.ComponentModel.DataAnnotations;

public class Persona
{
  [Key]
    public int PersonaId { get; set; }

     public String? Nombre { get; set; }
     public String? Telefono { get; set; }
     public String? Celular { get; set; }

     public String? Email { get; set; }
     public String? Direccion { get; set; }

     public DateTime FechaNacimiento { get; set; }
    public int OcupacionId { get; set; }




}