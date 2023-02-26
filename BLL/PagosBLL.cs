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


        _Contexto.Pagos.Add(Pago);

        return _Contexto.SaveChanges() > 0;


    }

      private bool Modificar(Pagos pago)
    {
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