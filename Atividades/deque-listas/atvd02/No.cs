using System;

public class No
{
    public object elemento;
    public No? proximo;

    public No(object elemento)
    {
        this.elemento = elemento;
        this.proximo = null;
    }
}
