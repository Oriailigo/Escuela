using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreEscuela.Util;
using Escuela.Entidades;

namespace coreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase, ILugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura>? listAsignatura{ get; set; }
        public List<Alumno>? listAlumno{ get; set; }

        public string Direccion { get; set; }

         public  void limpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento del curso...");
            Console.WriteLine($"Curso {Nombre} Limpio");
        }
        

    }
}