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

        return _Contexto.SaveChanges() >0;
    }

    private bool Modificar(Prestamos prestamo){
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