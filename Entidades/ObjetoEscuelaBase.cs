namespace coreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
            public string? Nombre { get;  set; }
            public string Uniqid { get; private set; }
            public ObjetoEscuelaBase()
            {
                this.Uniqid = Guid.NewGuid().ToString();
                
            }
            public override String ToString(){
                return $"Nombre= {Nombre} id= {Uniqid}";
            }
    }
}