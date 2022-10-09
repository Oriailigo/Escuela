using coreEscuela.Entidades;
namespace coreEscuela.App
{
    public sealed class EscuelaEngine
    {
        public coreEscuela.Entidades.Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
        }
        // devuelve verdadero si incluye evaluaiones
        public List<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            Boolean traeEvaluaciones,
            Boolean traeAlumnos,
            Boolean traeAsignaturas,
            Boolean traeCursos
            ){
                var listObj=new List<ObjetoEscuelaBase>();
                listObj.Add(Escuela);
                if(traeCursos){ // tiene cursos
                    listObj.AddRange(Escuela.listCurso);
                }
                foreach (var curso in Escuela.listCurso)
                {   
                    if(traeAsignaturas){ // tiene asignaturas
                        listObj.AddRange(curso.listAsignatura);
                    }
                    if(traeAlumnos){ // tiene alumnos
                        listObj.AddRange(curso.listAlumno);
                    }
                    if(traeEvaluaciones){// tiene evaluaciones
                        foreach (var alumno in curso.listAlumno)
                            {
                                listObj.AddRange(alumno.listEvaluacion);
                                
                            }
                    }
                }
            return listObj;
        }
        public List<ObjetoEscuelaBase> GetObjetoEscuelaBases(){
            var listObj=new List<ObjetoEscuelaBase>();
            listObj.Add(Escuela);
            listObj.AddRange(Escuela.listCurso);
            foreach (var curso in Escuela.listCurso)
            {
                listObj.AddRange(curso.listAsignatura);
                listObj.AddRange(curso.listAlumno);
                foreach (var alumno in curso.listAlumno)
                {
                    listObj.AddRange(alumno.listEvaluacion);
                    
                }
            }
            return listObj;
        }
        public void Inicializar()
        {
            Escuela = new coreEscuela.Entidades.Escuela("Platzi Academay", 2012, "calle falsa"
            );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }
        #region metodos de carga
        private void CargarAsignaturas()
        {
            foreach (var item in Escuela.listCurso)
            {
                List<Asignatura> listaAsignatura = new List<Asignatura>(){
                    new Asignatura{Nombre="Lengua"},
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Naturales"}
                };
                item.listAsignatura=listaAsignatura;
                // agregar x alumnos random
                Random rnd=new Random();
                foreach (var asignatura in item.listAsignatura)
                {
                                    
                    int cant=rnd.Next(3,5); // generea numero entre 2 y 5 alimnos.
                    asignatura.listAlumno=(GenerarAlumnos(cant));
                }

            }
        }

        private void CargarEvaluaciones()
        {
//curso /asignatura / alumno /evalaucion
            foreach (var curso in Escuela.listCurso)
            {
                foreach (var asignatura in curso.listAsignatura)
                {
                    foreach (var alumno in asignatura.listAlumno) // hay problemas de que la lista de alumnos en asignatura es null
                    {
                        var rnd= new Random(System.Environment.TickCount);
                       for (int i=0; i<5; i++)
                        {
                            var evaluacion= new Evaluacion{
                                        Nombre=$"nombre: evaluacion {i+1} ",
                                        Alumno=alumno,
                                        Asignatura=asignatura,
                                        Nota=(float)(5*rnd.NextDouble())
                            };
                            alumno.listEvaluacion.Add(evaluacion);
                        }
                    } 
                }   
            }   
        
        }
        
//estoy viendo
        private List<Alumno> GenerarAlumnos(int cant)
        {
            
            String [] nombre={"Oriana","Mica","Lola"};
            String [] nombr1={"Link","Rodri","Lolo"};
            String [] apellido={"Lorens","Moe","John"};
            var listaAlumnos=  from n1 in nombre
                               from n2 in nombr1
                               from a3 in apellido
                               select new Alumno{Nombre=$"{n1} {n2} {a3}"};
            return (List<Alumno>)listaAlumnos.OrderBy((al)=> al.Uniqid).Take(cant).ToList();

        }
        private void CargarCursos()
        {
            Escuela.listCurso = new List<Curso>(){
                        new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana },
                        new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
 
            };

            Random rnd = new Random();
            foreach (var c in Escuela.listCurso)
            {
                int cantRandom = rnd.Next(5, 20);
                c.listAlumno = GenerarAlumnos(cantRandom);
            }
        }

        #endregion        
    }

}