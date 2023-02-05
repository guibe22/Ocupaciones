using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class PagosDetalleBLL
{
    private Contexto _Contexto;
    public PagosDetalleBLL(Contexto contexto){
        _Contexto= contexto;
    }

    public bool Existe(int Id){

        return _Contexto.PagosDetalle.Any(o=> o.Id==Id);
    }

    private bool Insertar(PagosDetalle PagoDetalle){
        _Contexto.PagosDetalle.Add(PagoDetalle);

        return _Contexto.SaveChanges() >0;
    }

    private bool Modificar(PagosDetalle PagoDetalle){
        _Contexto.Entry(PagoDetalle).State = EntityState.Modified;

        return _Contexto.SaveChanges() >0;

    }


    public bool Guardar( PagosDetalle PagoDetalle){
        if(!Existe(PagoDetalle.Id)){
            return this.Insertar(PagoDetalle);
        }
        else{
            return this.Modificar(PagoDetalle);
        }
    }

    public bool Eliminar (PagosDetalle PagoDetalle){
        _Contexto.Entry(PagoDetalle).State= EntityState.Deleted;

    return _Contexto.SaveChanges() >0;
    }

    public PagosDetalle? Buscar( int Id){

        return _Contexto.PagosDetalle.Where( o => o.Id==Id).AsTracking().SingleOrDefault();

    }

    public List<PagosDetalle> GetList(Expression<Func<PagosDetalle,bool>>criterio){

        return _Contexto.PagosDetalle.AsNoTracking().Where(criterio).ToList();
    }

    
}