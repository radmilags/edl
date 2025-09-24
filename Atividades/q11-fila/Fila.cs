//11. Implemente um deque usando Vector.
using System;
using System.Collections.Generic;
public class Fila
{
    private object[] array;
    private int n_elementos;
    private int n; // tamanho
    private int incremento;
    private int i, f;

    public Fila(int n, int incremento)
    {
        array = new object[n];
        this.n=n; 
        this.incremento=incremento;
    }

    public void Enqueue(object elemento)
    {
        if (Size() == n - 1)
        {
            int novoTam;
            if (incremento == 0) novoTam = n * 2;
            else novoTam = n + incremento;

            object[] novoArray = new object[novoTam];

            int ii = i;

            for (int ff = 0; ff < Size(); ff++)
            {
                novoArray[ff] = array[ii];
                ii = (ii + 1) % n;
            }
            f = Size();
            i = 0;
            n = novoTam;
            array = novoArray;
        }
        array[f] = elemento;
        f = (f + 1) % n;
        n_elementos++;
    }

    public object Dequeue()
    {
        object elemento = array[i];
        i = (i + 1) % n;
        n_elementos--;
        return elemento;
    }

    public object First() {
        return array[i];
    }

    public void Indices()
    {
        Console.WriteLine($"i = {i}, f = {f}");
    }

    public int Size()
    {
        return n;
    }

    public int N_elementos()
    {
        return n_elementos;
    }

    public bool isEmpty()
    {
        if (n_elementos == 0) return true;
        return false;
    }

    public void PrintaFila() {
        foreach(object o in array){
            Console.WriteLine(o);
        }
    }
}