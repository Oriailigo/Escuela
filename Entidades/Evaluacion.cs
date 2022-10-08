namespace coreEscuela.Entidades
{
    public class Evaluacion{
        public string Nombre { get;  set; }
        public Alumno Alumno { get;  set; }
        public Asignatura Asignatura { get;  set; }
        public float Nota { get;  set; }
        public string Uniqid { get; private set; }

        public Evaluacion()
        {
            Uniqid=Guid.NewGuid().ToString();
            
        }
    }
}