using coreEscuela.App;
using coreEscuela.Entidades;
using coreEscuela.Util;
using Escuela.Entidades;
using static System.Console; // simplifico el codigo para que sea mas legible
    class Program{
            static void Main(string[] args)
            {
                var engine= new EscuelaEngine();
                engine.Inicializar();
                Printer.WriteTitle("Bienvenidos a la escuela");
                
                ImprimirCursos(engine.Escuela.listCurso);
                Printer.WriteTitle("Imprime evalucaiones de los alumnos");
                ImprimirEvaluaciones(engine.Escuela.listCurso);

                Printer.DrawLine(50);
                Printer.DrawLine(50);
                Printer.DrawLine(50);
                Printer.WriteTitle("Pruebas de Polimorfismo");
                var alumnoTest=new Alumno(){
                    Nombre="lolo",
                };
                ObjetoEscuelaBase ob=alumnoTest;
                int dummy=0;
                var listObj= engine.GetObjetoEscuelaBases(
                    out int contEvaluaciones,
                    out dummy,
                    out dummy,
                    out dummy,
                    traeCursos:true, 
                    traeAlumnos:true, 
                    traeAsignaturas:true, 
                    traeEvaluaciones:true);
                // vamos a aplicar el tema del polimorfismo con interfaces (ILugar)
                // var listaIlugar= from obj in listObj
                //                  where obj is Alumno 
                //                  select (Alumno) obj;
                //engine.Escuela.limpiarLugar();

                // Console.WriteLine("sonar timbre");
                // escuela.timbre();
            //    Console.WriteLine(escuela.ToString());
                // Console.WriteLine($"nom= {curso1.Nombre}, id= {curso1.uniqid}"+System.Environment.NewLine);


            }

    private static void ImprimirCursos(List<Curso> arrayCursos)
    {
        if(arrayCursos!=null){
            Printer.WriteTitle("Cursos de la Escuela");
            foreach (var item in arrayCursos)
            {
                WriteLine($"curso= {item.Nombre} {item.Uniqid}"+ System.Environment.NewLine);
            }
        }
        
    }
    private static void ImprimirEvaluaciones(List<Curso> arrayCursos)
    {
        if(arrayCursos!=null){
            Printer.WriteTitle("Cursos de la Escuela");
            foreach (var curso in arrayCursos)
            {
                foreach (var asignatura in curso.listAsignatura)
                {
                    Printer.WriteTitle($"Asignatura= {asignatura.Nombre}");
                    foreach (var alumno in asignatura.listAlumno)
                    { 
                        WriteLine($"Alumno= {alumno.Nombre} "+ System.Environment.NewLine);   
                        foreach (var evaluacion in alumno.listEvaluacion)
                        {
                            WriteLine($"Evaluacion= {evaluacion.Nombre} con Nota= {evaluacion.Nota}"+ System.Environment.NewLine);   
                            
                        }
                    }

                }

            }
        }
        
    }
}
