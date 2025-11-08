using System;

public class No
{
    private object? elemento;
    private No? proximo;
    private No? anterior;

    //tive que fazer os metodos get e set pq a classe nao tava conseguindo acessar

    public No(object? elemento)
    {
        this.elemento = elemento;
        proximo = null;
        anterior = null;
    }

    public object? GetElemento()
    {
        return elemento;
    }

    public No? GetProximo()
    {
        return proximo;
    }

    public No? GetAnterior()
    {
        return anterior;
    }

    public void SetElemento(object? o)
    {
        elemento = o;
    }

    public void SetProximo(No? n)
    {
        proximo = n;
    }

    public void SetAnterior(No? n)
    {
        anterior = n;
    }
}