using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreEscuela.Entidades
{
    public class Curso
    {
        internal TipoEscuela jornada;

        public string? Nombre { get;  set; }
        public string Uniqid { get; private set; }
        public TiposJornada Tipo { get; set; }
        public List<Asignatura>? listAsignatura{ get; set; }
        public List<Alumno>? listAlumno{ get; set; }

        //constructor
        public Curso(string nom, TiposJornada jornada): base()
        {
            Nombre=nom;
            Tipo=jornada;
            
        }
        public Curso()
        {
            Uniqid=Guid.NewGuid().ToString();
            
        }
    }
}