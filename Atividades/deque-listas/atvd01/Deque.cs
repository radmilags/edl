using System;
using System.Collections.Generic;
using System.Drawing;

public class Deque
{
    private int size;
    private No inicio; 
    private No final;  

    public Deque() 
    {
        inicio = new No(null);
        final = new No(null);

        inicio.proximo = final;
        final.anterior = inicio;
        
        size = 0;
    }

    public bool isEmpty()
    {
        return size == 0;
    }

    public int Size()
    {
        return this.size;
    }

    public void InserirInicio(object o)
    {
        No novo = new No(o);
        
        novo.anterior = inicio;
        novo.proximo = inicio.proximo;

        inicio.proximo.anterior = novo; 
        inicio.proximo = novo;        
        
        size++;
    }

    public void InserirFinal(object o)
    {
        No novo = new No(o);

        novo.proximo = final;
        novo.anterior = final.anterior;

        final.anterior.proximo = novo; 
        final.anterior = novo;        
        
        this.size++;
    }

    public object RemoverInicio()
    {
        if(isEmpty()) throw new Exception("ta vazio more");
        
        No noAntigo = inicio.proximo; 
        object dado = noAntigo.elemento;

        inicio.proximo = noAntigo.proximo;
        noAntigo.proximo.anterior = inicio;

        noAntigo.proximo = null;
        noAntigo.anterior = null;

        this.size--;
        return dado;
    }

    public object RemoverFim()
    {
        if(isEmpty()) throw new Exception("ta vazio more");

        No noAntigo = final.anterior; 
        object dado = noAntigo.elemento;

        final.anterior = noAntigo.anterior;
        noAntigo.anterior.proximo = final;

        noAntigo.proximo = null;
        noAntigo.anterior = null;

        this.size--;
        return dado;
    }

    public object Primeiro()
    {
        if(isEmpty()) throw new Exception("ta vazio more");
        return inicio.proximo.elemento;
    }

    public object Ultimo()
    {
        if(isEmpty()) throw new Exception("ta vazio more");
        return final.anterior.elemento;
    }
}
