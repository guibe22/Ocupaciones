using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class PagosBLL
{
    private Contexto _Contexto;

    public PagosBLL(Contexto contexto)
    {
        _Contexto = contexto;
    }

    public bool Existe(int PagosId)
    {
        return _Contexto.Pagos.Any(o => o.PagoId == PagosId);
    }

    private bool Insertar(Pagos Pago)
    {
         var persona = _Contexto.Personas.Find(Pago.PersonaId);
        if(Pago.PagosDetalle != null){
             foreach (var detalle in Pago.PagosDetalle)
            {
                var prestamo = _Contexto.Prestamos.Find(detalle.PrestamoId);
                
                if(prestamo!=null){
                     prestamo.Balance-= detalle.ValorPagado;
                    _Contexto.Entry(prestamo).State = EntityState.Modified;
                }
                
                if(persona!=null){
                    persona.Balance-=detalle.ValorPagado;
                    _Contexto.Entry(persona).State = EntityState.Modified;  
                 }
                
            
            }  
        }


        _Contexto.Pagos.Add(Pago);
        return _Contexto.SaveChanges() > 0;


    }

      private bool Modificar(Pagos pago)
    {
        var PagoAnterior = _Contexto.Pagos
           .Where(p => p.PagoId == pago.PagoId)
           .Include(p =>  p.PagosDetalle)
           .AsNoTracking()
           .SingleOrDefault();
        var persona = _Contexto.Personas.Find(pago.PersonaId);

        if(PagoAnterior != null && PagoAnterior.PagosDetalle!=null){
            
             foreach (var detalle in PagoAnterior.PagosDetalle)
            {
                var prestamo = _Contexto.Prestamos.Find(detalle.PrestamoId);
                if(prestamo!=null){
                     prestamo.Balance+= detalle.ValorPagado;
                    _Contexto.Entry(prestamo).State = EntityState.Modified;
                }
                
                if(persona!=null){
                    persona.Balance+=detalle.ValorPagado;
                    _Contexto.Entry(persona).State = EntityState.Modified;  
                 }
            }
            
        }

        if(pago.PagosDetalle != null){
             foreach (var detalle in pago.PagosDetalle)
            {
               var prestamo = _Contexto.Prestamos.Find(detalle.PrestamoId);
                if(prestamo!=null){
                     prestamo.Balance-= detalle.ValorPagado;
                    _Contexto.Entry(prestamo).State = EntityState.Modified;
                }
                
                if(persona!=null){
                    persona.Balance-=detalle.ValorPagado;
                    _Contexto.Entry(persona).State = EntityState.Modified;  
                 }
              
            
            }  
        }
        

        var pagosDetalleAEliminar = _Contexto.Set<PagosDetalle>().Where(pd => pd.PagoId == pago.PagoId);
        _Contexto.Set<PagosDetalle>().RemoveRange(pagosDetalleAEliminar);
        _Contexto.Entry(pago).State = EntityState.Modified;

        

         return _Contexto.SaveChanges() > 0;
    }



    public bool Guardar(Pagos Pago)
    {
        if (!Existe(Pago.PagoId))
        {
            return this.Insertar(Pago);
        }
        else
        {
            return  this.Modificar(Pago);
        }
    }

    public bool Eliminar(Pagos Pago)
    { 
        var persona = _Contexto.Personas.Find(Pago.PersonaId);

        if(Pago.PagosDetalle != null){
             foreach (var detalle in Pago.PagosDetalle)
            {
                var prestamo = _Contexto.Prestamos.Find(detalle.PrestamoId);
                if(prestamo!=null){
                     prestamo.Balance+= detalle.ValorPagado;
                    _Contexto.Entry(prestamo).State = EntityState.Modified;
                }
                
                if(persona!=null){
                    persona.Balance+=detalle.ValorPagado;
                    _Contexto.Entry(persona).State = EntityState.Modified;  
                 }
            }  
        }
        
        var pagosDetalleAEliminar = _Contexto.Set<PagosDetalle>().Where(pd => pd.PagoId == Pago.PagoId);
        _Contexto.Set<PagosDetalle>().RemoveRange(pagosDetalleAEliminar);

        _Contexto.Entry(Pago).State = EntityState.Deleted;

        return _Contexto.SaveChanges() > 0;
    }

    public Pagos? Buscar(int PagosId)
    {

        return _Contexto.Pagos
        .Include(o => o.PagosDetalle)
        .Where(o => o.PagoId == PagosId)
        .AsTracking()
        .SingleOrDefault();

    }

    public List<Pagos> GetList(Expression<Func<Pagos, bool>> criterio)
    {

        return _Contexto.Pagos.AsNoTracking().Where(criterio).ToList();
    }

}