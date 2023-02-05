using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class PagosBLL
{
    private Contexto _Contexto;

    public PagosBLL(Contexto contexto){
        _Contexto = contexto;
    }

    public bool Existe(int PagosId){
        return _Contexto.Pagos.Any(o => o.PagosId == PagosId);
    }

    private bool Insertar(Pagos Pago){
        _Contexto.Pagos.Add(Pago);

        return _Contexto.SaveChanges() >0;
    }

    private bool Modificar(Pagos Pago){
        _Contexto.Entry(Pago).State = EntityState.Modified;

        return _Contexto.SaveChanges() >0;

    }


    public bool Guardar( Pagos Pago){
        if(!Existe(Pago.PagosId)){
            return this.Insertar(Pago);
        }
        else{
            return this.Modificar(Pago);
        }
    }

    public bool Eliminar (Pagos Pago){
        _Contexto.Entry(Pago).State= EntityState.Deleted;

    return _Contexto.SaveChanges() >0;
    }

    public Pagos? Buscar( int PagosId){

        return _Contexto.Pagos.Where( o => o.PagosId==PagosId).AsTracking().SingleOrDefault();

    }

    public List<Pagos> GetList(Expression<Func<Pagos,bool>>criterio){

        return _Contexto.Pagos.AsNoTracking().Where(criterio).ToList();
    }

}