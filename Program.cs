using coreEscuela.App;
using coreEscuela.Entidades;
using coreEscuela.Util;
using static System.Console; // simplifico el codigo para que sea mas legible
    class Program{
            static void Main(string[] args)
            {
                var engine= new EscuelaEngine();
                engine.inicializar();
                Printer.WriteTitle("Bienvenidos a la escuela");
                // Printer.Beep(3000,500,5);
                // escuela.cursos=null;
               
                ImprimirCursos(engine.Escuela.cursos);
                Printer.WriteTitle("Imprime evalucaiones de los alumnos");
                ImprimirEvaluaciones(engine.Escuela.cursos);

                // Console.WriteLine("sonar timbre");
                // escuela.timbre();
            //    Console.WriteLine(escuela.ToString());
                // Console.WriteLine($"nom= {curso1.Nombre}, id= {curso1.uniqid}"+System.Environment.NewLine);


            }

    private static void ImprimirCursos(Curso[] arrayCursos)
    {
        if(arrayCursos!=null){
            Printer.WriteTitle("Cursos de la Escuela");
            foreach (var item in arrayCursos)
            {
                WriteLine($"curso= {item.Nombre} {item.Uniqid}"+ System.Environment.NewLine);
            }
        }
        
    }
    private static void ImprimirEvaluaciones(Curso[] arrayCursos)
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
