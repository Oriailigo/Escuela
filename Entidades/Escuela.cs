using coreEscuela.Util;
using Escuela.Entidades;

namespace coreEscuela.Entidades
{
    public class Escuela:ObjetoEscuelaBase, ILugar{
         public TipoEscuela Tipo{get; set;}
         public List<Curso> listCurso { get; set; }
         public string Ceo {get; set;}
         public string Direccion {get; set;}
         public int AñoCreacion { get; set; }
         public DateTime? Fecha  {get; set;} // que tenga valor por defecto nulo.
         public void timbre(){
            Console.Beep(2000, 3000);
        }
        // tostring
        public override string ToString()
        {
            return $"Nombre: {Nombre} CEO: {Ceo} AñoCreacion: {AñoCreacion}"+System.Environment.NewLine+"  Tipo: {Tipo}";
        }

        // uso de otro constructor con atributos opcionales
        public Escuela(string Nombre,int año, string Direccion=" "): base(){
            (Nombre,AñoCreacion)=(Nombre,año);
            this.Direccion=Direccion;// el atributo Direccion es opcional
        }
         public void limpiarLugar(){
            Printer.DrawLine(50);
            Console.WriteLine("Se va a limpiar la escuela");
            
            foreach (var curso in listCurso)
            {
                curso.limpiarLugar();
            }
            Printer.Beep(1000, cant:3);
            Printer.WriteTitle($"Escuela= {Nombre} limpia!!!");
        }
    }
}