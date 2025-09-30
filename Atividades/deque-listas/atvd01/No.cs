using System;
public class No
{
    public object elemento;
    public No? proximo;
    public No? anterior;

    public No(object elemento)
    {
        this.elemento = elemento;
        this.anterior = null;
        this.proximo = null;
    }
}
