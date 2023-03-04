using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


public class PrestamosBLL
{
    private Contexto _Contexto;

    public PrestamosBLL(Contexto contexto){
        _Contexto= contexto;
    }

    public bool Existe(int PrestamoId){

        return _Contexto.Prestamos.Any(o=> o.PrestamoId==PrestamoId);
    }

    private bool Insertar (Prestamos prestamo){

        _Contexto.Prestamos.Add(prestamo);

        prestamo.Balance= prestamo.Monto;
        var persona = _Contexto.Personas.Find(prestamo.PersonaId);
        if(persona!=null){
            persona.Balance+= prestamo.Balance;
        }
        

        return _Contexto.SaveChanges() >0;
        
    }

    private bool Modificar(Prestamos prestamo){

         var pagosDetalle = _Contexto.Set<PagosDetalle>()
         .Where(d => d.PrestamoId == prestamo.PrestamoId).ToList();

        var persona = _Contexto.Personas.Find(prestamo.PersonaId);
        var prestamoAnterior = _Contexto.Prestamos.Find(prestamo.PrestamoId);
        
        if(persona!=null && prestamoAnterior!=null){
            persona.Balance-= prestamoAnterior.Balance;
        }

        prestamo.Balance= prestamo.Monto;
        foreach (var detalle in pagosDetalle )
        {
            prestamo.Balance -= detalle.ValorPagado;
        }

         if(persona!=null){
            persona.Balance+=prestamo.Balance;  
         }
        
        _Contexto.Entry(prestamo).State = EntityState.Modified;



        return _Contexto.SaveChanges() >0;
    }
   public bool Guardar (Prestamos prestamo){

        if(!Existe(prestamo.PrestamoId)){
            return this.Insertar(prestamo);
        }
        else{
            return this.Modificar(prestamo);
        }
    }

    public bool Eliminar (Prestamos prestamo){

    var persona = _Contexto.Personas.Find(prestamo.PersonaId);
    if(persona!=null){
            persona.Balance-=prestamo.Balance;  
        }
      
        _Contexto.Entry(prestamo).State = EntityState.Deleted;

        return  _Contexto.SaveChanges() >0;

    }

    public Prestamos? Buscar (int PrestamoId){
        return _Contexto.Prestamos.Where(o=> o.PrestamoId==PrestamoId).AsTracking().SingleOrDefault();
    }
    
    public List<Prestamos> GetList(Expression<Func<Prestamos,bool>>criterio){
        return _Contexto.Prestamos.AsNoTracking().Where(criterio).ToList();
    }
}