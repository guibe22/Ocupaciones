using Microsoft.EntityFrameworkCore;
public class Contexto: DbContext
{
 public DbSet<Ocupaciones> Opcupaciones{get; set;}

 public Contexto(DbContextOptions<Contexto>options): base(options){ }

}