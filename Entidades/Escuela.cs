namespace coreEscuela.Entidades
{
    public class Escuela{
         public string Nombre {get; set;}
         public TipoEscuela Tipo{get; set;}
         public Curso[] cursos { get; set; }
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

        // constructor
        
        public Escuela(){

        }

        // uso de otro constructor con atributos opcionales
        public Escuela(string Nombre,int año, string Direccion=" "): base(){
            (Nombre,AñoCreacion)=(Nombre,año);
            this.Direccion=Direccion;// el atributo Direccion es opcional
        }
    }
}