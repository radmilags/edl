public class No
{
    public object Elemento { get; set; }
    public No? Proximo { get; set; } 
    public No? Anterior { get; set; }
    public No(object elemento)
    {
        this.Elemento = elemento;
        this.Proximo = null;
        this.Anterior = null;
    }
    
}