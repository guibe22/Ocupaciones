using Microsoft.EntityFrameworkCore;
public class Contexto: DbContext
{
 public DbSet<Ocupaciones> Opcupaciones{get; set;}
 public DbSet<Persona> Personas{get; set;}
 public DbSet<Prestamos> Prestamos{get; set;}
 public DbSet<Pagos> Pagos { get; set; }

 public DbSet<PagosDetalle> PagosDetalle { get; set; }

 public Contexto(DbContextOptions<Contexto>options): base(options){ }

}