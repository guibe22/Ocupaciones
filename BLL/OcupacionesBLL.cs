using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class OcupacionesBLL
{
    private Contexto _Contexto;
    public OcupacionesBLL(Contexto contexto){
        _Contexto= contexto;
    }

    public bool Existe(int ocupacionId){
        return _Contexto.Opcupaciones.Any(o=> o.OcupacionId==ocupacionId);
    }

    private bool Insertar (Ocupaciones Ocupacion ){
        _Contexto.Opcupaciones.Add(Ocupacion);
        return _Contexto.SaveChanges() >0;
    }

    private bool Modificar (Ocupaciones Ocupacion){
        _Contexto.Entry(Ocupacion).State = EntityState.Modified;
        return  _Contexto.SaveChanges() >0;
    }

    public bool Guardar( Ocupaciones Ocupacion){
        if(!Existe(Ocupacion.OcupacionId)){
            return this.Insertar(Ocupacion);
        }
        else{
            return this.Modificar(Ocupacion);
        }
    }

    public bool Eliminar (Ocupaciones Ocupacion){
        _Contexto.Entry(Ocupacion).State = EntityState.Deleted;
        return _Contexto.SaveChanges() >0;
    }    

    public Ocupaciones? Buscar(int OcupacionId){

        return _Contexto.Opcupaciones.Where(o => o.OcupacionId== OcupacionId).AsTracking().SingleOrDefault();
    }

    public List<Ocupaciones> GetList(Expression<Func<Ocupaciones,bool>>criterio){
        return _Contexto.Opcupaciones.AsNoTracking().Where(criterio).ToList();
        
    }
}