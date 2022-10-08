namespace coreEscuela.Entidades
{
    public class Evaluacion:ObjetoEscuelaBase{
        public Alumno Alumno { get;  set; }
        public Asignatura Asignatura { get;  set; }
        public float Nota { get;  set; }

        public override String ToString(){
            return $"Nota= {Nota}, Alumno= {Alumno.Nombre} , Asignatura= {Asignatura.Nombre} ";
        }
    
    }
}