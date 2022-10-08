namespace coreEscuela.Entidades
{
    public class ObjetoEscuelaBase
    {
            public string? Nombre { get;  set; }
            public string Uniqid { get; private set; }
            public ObjetoEscuelaBase()
            {
                this.Uniqid = Guid.NewGuid().ToString();
            }
    }
}