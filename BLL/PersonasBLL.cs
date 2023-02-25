using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class PersonasBLL
{
    private Contexto _Contexto;

    public PersonasBLL(Contexto contexto){
        _Contexto= contexto;
    }

    public bool Existe(int PersonaId){

        return _Contexto.Personas.Any(o=> o.PersonaId==PersonaId);
    }

    private bool Insertar( Personas Persona){
        _Contexto.Personas.Add(Persona);

        return _Contexto.SaveChanges()>0;
    }

    private bool Modificar(Personas Persona){
        _Contexto.Entry(Persona).State = EntityState.Modified;

        return _Contexto.SaveChanges()>0;

    }

    public bool Guardar(Personas Persona){
        if(!Existe(Persona.PersonaId)){
            return this.Insertar(Persona);
        }
        else{
            return this.Modificar(Persona);
        }
    }

    public bool Eliminar (Personas Persona){
        _Contexto.Entry(Persona).State= EntityState.Deleted;

        return _Contexto.SaveChanges()>0;
    }

    public Personas? Buscar( int PersonaId){
     return _Contexto.Personas.Where(o=> o.PersonaId == PersonaId).AsTracking().SingleOrDefault();
    }

    public List<Personas> GetList(Expression<Func<Personas,bool>>criterio){

        return _Contexto.Personas.AsNoTracking().Where(criterio).ToList();
    }


    
}