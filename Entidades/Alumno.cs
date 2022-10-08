namespace coreEscuela.Entidades
{
    public class Alumno:ObjetoEscuelaBase{

        public List<Evaluacion> listEvaluacion { get; set; }= new List<Evaluacion>();
        public Alumno()
        {

            this.listEvaluacion = new List<Evaluacion>(){};
        }
    }
}