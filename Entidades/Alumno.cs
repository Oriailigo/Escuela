namespace coreEscuela.Entidades
{
    public class Alumno{
        public string? Nombre { get;  set; }
        public string Uniqid { get; private set; }
        public List<Evaluacion> listEvaluacion { get; set; }= new List<Evaluacion>();
        public Alumno()
        {
            this.Uniqid = Guid.NewGuid().ToString();
            this.listEvaluacion = new List<Evaluacion>(){};
        }
    }
}