using coreEscuela.Entidades;
using coreEscuela.Util;
using System.Linq;

namespace coreEscuela.App
{
    public class EscuelaEngine
    {
        public Escuela? Escuela{get; set;}
        public EscuelaEngine()
        {
        }

        public void inicializar()
        {
            //inicializar Escuela
            this.Escuela = new Escuela("Platzi Academy", 2012);
            this.Escuela.Tipo = TipoEscuela.prescolar;
            this.Escuela.Ceo = "Freddy Vega";

            CargarCursos();
            
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private void CargarAsignaturas()
        {
            foreach (var item in Escuela.cursos)
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


          
            // foreach (var cursos in Escuela.cursos)
            // {
            //     foreach (var asignatura in cursos.listAsignatura)
            //     {
            //         Printer.WriteTitle(asignatura.Nombre);
            //     }
                
            // }
        }

        private void CargarEvaluaciones()
        {
//curso /asignatura / alumno /evalaucion
            foreach (var curso in Escuela.cursos)
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
                               select new Alumno{Nombre=$"{n1}{n2}{a3}"};
            return (List<Alumno>)listaAlumnos.OrderBy((al)=> al.Uniqid).Take(cant).ToList();

        }

        private void CargarCursos()
        {
            Curso[] arrayCursos ={
                    new Curso(){
                    Nombre="301", jornada=TipoEscuela.prescolar },
                    new Curso(){
                    Nombre="201" },
                    new Curso(){
                    Nombre="301" },
                };

            Escuela.cursos = arrayCursos;
            Random rnd=new Random();
            foreach (var curso in Escuela.cursos)
            {
                int cant=rnd.Next(3,5); // generea numero entre 2 y 5 alimnos.
                curso.listAlumno=(GenerarAlumnos(cant));
            }
        }

        // profe code

        // private void CargarAsignaturas()
        // {
        //     foreach (var curso in Escuela.cursos)
        //     {
        //         var listaAsignaturas = new List<Asignatura>(){
        //                     new Asignatura{Nombre="Matemáticas"} ,
        //                     new Asignatura{Nombre="Educación Física"},
        //                     new Asignatura{Nombre="Castellano"},
        //                     new Asignatura{Nombre="Ciencias Naturales"}
        //         };
        //         curso.listAsignatura = listaAsignaturas;
        //     }
        // }

        // private List<Alumno> GenerarAlumnosAlAzar( int cantidad)
        // {
        //     string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        //     string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        //     string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        //     var listaAlumnos =  from n1 in nombre1
        //                         from n2 in nombre2
        //                         from a1 in apellido1
        //                         select new Alumno{ Nombre=$"{n1} {n2} {a1}" };
            
        //     return listaAlumnos.OrderBy( (al)=> al.Uniqid ).Take(cantidad).ToList();
        // }

        // private void CargarCursos()
        // {
            
        //     Curso[] arrayCursos ={
        //             new Curso(){
        //             Nombre="301", jornada=TipoEscuela.prescolar },
        //             new Curso(){
        //             Nombre="201" },
        //             new Curso(){
        //             Nombre="301" },
        //         };

        //     Escuela.cursos = arrayCursos;
            
        //     Random rnd = new Random();
        //     foreach(var curso in Escuela.cursos)
        //     {
        //         int cantRandom = rnd.Next(3, 5);
        //         curso.listAlumno = GenerarAlumnosAlAzar(cantRandom);

        //     }
        // }
    }
}