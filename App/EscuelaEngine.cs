using coreEscuela.Entidades;
namespace coreEscuela.App
{
    public sealed class EscuelaEngine
    {
        public coreEscuela.Entidades.Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
        }
        //Sobrecargas de metodos:
         public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            Boolean traeEvaluaciones=true,
            Boolean traeAlumnos=true,
            Boolean traeAsignaturas=true,
            Boolean traeCursos=true
            )
        {

            return GetObjetoEscuelaBases(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
           out int conteoEvaluaciones,
           bool traeEvaluaciones = true,
           bool traeAlumnos = true,
           bool traeAsignaturas = true,
           bool traeCursos = true
           )
        {

            return GetObjetoEscuelaBases(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
         public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
           out int conteoEvaluaciones,
           out int contAlumnos,
           bool traeEvaluaciones = true,
           bool traeAlumnos = true,
           bool traeAsignaturas = true,
           bool traeCursos = true
           )
        {

            return GetObjetoEscuelaBases(out conteoEvaluaciones, out contAlumnos, out int dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
           out int conteoEvaluaciones,
           out int contAlumnos,
           out int conteoAsignaturas,
           bool traeEvaluaciones = true,
           bool traeAlumnos = true,
           bool traeAsignaturas = true,
           bool traeCursos = true
           )
        {

            return GetObjetoEscuelaBases(out conteoEvaluaciones, out contAlumnos, out conteoAsignaturas, out int dummy);
        }
        
        
        // devuelve verdadero si incluye evaluaiones
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int contAlumnos,
            out int contAsignaturas,
            out int contCursos,
            out int contEvaluaciones,
            Boolean traeEvaluaciones=true,
            Boolean traeAlumnos=true,
            Boolean traeAsignaturas=true,
            Boolean traeCursos=true

            ){
                contAlumnos=0;
                contAsignaturas=0;
                contEvaluaciones=0;
                contCursos=0;
                var listObj=new List<ObjetoEscuelaBase>();
                listObj.Add(Escuela);
                if(traeCursos){ // tiene cursos
                    listObj.AddRange(Escuela.listCurso);
                }
                contCursos+=Escuela.listCurso.Count;
                foreach (var curso in Escuela.listCurso)
                {   
                    if(traeAsignaturas){ // tiene asignaturas
                        listObj.AddRange(curso.listAsignatura);
                    }
                    contAsignaturas+=curso.listAsignatura.Count;
                    if(traeAlumnos){ // tiene alumnos
                        listObj.AddRange(curso.listAlumno);
                    }
                    contAlumnos+=curso.listAlumno.Count;
                    if(traeEvaluaciones){// tiene evaluaciones
                        foreach (var alumno in curso.listAlumno)
                            {

                                listObj.AddRange(alumno.listEvaluacion);
                                contEvaluaciones+=alumno.listEvaluacion.Count;
                                
                            }
                    }
                }
            return listObj.AsReadOnly();
        }
    
        // public List<ObjetoEscuelaBase> GetObjetoEscuelaBases(){ // este metodo ya no sirve
        //     var listObj=new List<ObjetoEscuelaBase>();
        //     listObj.Add(Escuela);
        //     listObj.AddRange(Escuela.listCurso);
        //     foreach (var curso in Escuela.listCurso)
        //     {
        //         listObj.AddRange(curso.listAsignatura);
        //         listObj.AddRange(curso.listAlumno);
        //         foreach (var alumno in curso.listAlumno)
        //         {
        //             listObj.AddRange(alumno.listEvaluacion);
                    
        //         }
        //     }
        //     return listObj;
        // }
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