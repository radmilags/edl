using System;
using System.Collections.Generic;
class Fila
{
    private object[] fila;
    private int size;
    private int n_elementos;

    private int i, f;

    public Fila(int capacidade)
    {
        fila = new Fila[capacidade];
        i = 0;
        f = i + 1;
        n_elementos = 0;
    }

    public void Enqueue(object o)
    {
        fila[i] = o; // trabalhar as excecoes fila cheia
        f++;
        n_elementos++;
    }

    public int Size()
    {
        return size;
    }

    public object Dequeue()
    {
        object elemento = array[i];
        i = (i + 1) % n;
        n_elementos--;
        return elemento;
        
    }
}