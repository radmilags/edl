using System;
public class No
{
    public object elemento;
    public No proximo {get; set;}
    public No anterior {get; set;}

    public No(object elemento)
    {
        this.elemento = elemento;
        anterior = null;
        proximo = null;
    }
}
