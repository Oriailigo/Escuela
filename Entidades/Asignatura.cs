namespace coreEscuela.Entidades
{
    public class Asignatura{
        public string? Nombre { get;  set; }
        public string Uniqid { get; private set; }

        public List<Alumno>? listAlumno{ get;  set; }

        public Asignatura()
        {
            Uniqid=Guid.NewGuid().ToString();
            
        }
    }
}