using System;
using System.Collections.Generic;
class Fila
{
    private object[] fila;
    private int size; // tamanho total da fila, independente se tem elementos ou nao
    private int n_elementos; // numero exato de elementos que tem na fila

    private int i, f;

    public Fila(int capacidade)
    {
        fila = new Fila[capacidade];
        i = 0;
        f = i + 1;
        n_elementos = 0;
        size = capacidade;
    }

    public void Enqueue(object o)
    {
        fila[f] = elemento;
        f = (f + 1) % n;
        n_elementos++;
        foreach (object o in fila)
        {
            if (o != null) Console.WriteLine(o);
            else Console.WriteLine(null);
        }
    }

    public int Size()
    {
        return size;
    }

    public object Dequeue()
    {
        object elemento = fila[i];
        i = (i + 1) % n;
        n_elementos--;
        foreach (object o in fila)
        {
            if (o != null) Console.WriteLine(o);
            else Console.WriteLine(null);
        }
        return elemento;
    }

    public int NElementos()
    {
        return n_elementos;
    }

    public object First()
    {
        return fila[i];
    }

    public bool isEmpty()
    {
        if (n_elementos == 0) return true; // depois mude essa verificacao para um tratamento de exceções
        // utilizar o encontro do inicio com o fim 
        // if(i == f) --> lista vazia
        return false;
    }
}