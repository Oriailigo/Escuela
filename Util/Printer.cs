using static System.Console;
namespace coreEscuela.Util

{
    public static class  Printer{
        public static void DrawLine(int tam=10){
            WriteLine("".PadLeft(tam,'-'));
        }
        public static void WriteTitle(String title){
            var tamaño=title.Length+4;
            DrawLine(tamaño);
            WriteLine($"|  {title}  |");
            DrawLine(tamaño);
        }

        public static void Beep(int fr=2000,int duracion=500,int cant=1){
              while(cant-->0){
                System.Console.Beep(fr,duracion);
              }
              
        }
    }
}