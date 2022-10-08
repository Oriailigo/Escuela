using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase
    {
        // internal TipoEscuela jornada;
        public TiposJornada Jornada { get; set; }
        public List<Asignatura>? listAsignatura{ get; set; }
        public List<Alumno>? listAlumno{ get; set; }

        //constructor
        // public Curso(TiposJornada jornada): base()
        // {
        //     Tipo=jornada;
            
        // }
    
    }
}