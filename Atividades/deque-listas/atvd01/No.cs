using System;
public class No
{
    public object? elemento;
    private No? proximo;
    private No? anterior;

    public No(object? elemento)
    {
        this.elemento = elemento;
        anterior = null;
        proximo = null;
    }

    public object GetElemento()
    {
        return elemento;
    }
    public No GetProximo()
    {
        return proximo;
    }

    public No GetAnterior()
    {
        return anterior;
    }
}
