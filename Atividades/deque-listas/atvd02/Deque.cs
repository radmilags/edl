using System;
using System.Collections.Generic;

public class Deque
{
    private object[] array;
    private int n_elementos;
    private int tamanho; // tamanho
    private int incremento;
    private int i, f;

    public Deque(int tamanho, int incremento) // if incremento == 0; estratégia de duplicacao senao estrategia do incremento
    {
        array = new object[tamanho];
        this.tamanho=tamanho; 
        this.incremento=incremento;
    }

    public void Enqueue(object elemento)
    {
        if (Size() == tamanho - 1)
        {
            int novoTam;
            if (incremento == 0) novoTam = tamanho * 2;
            else novoTam = tamanho + incremento;

            object[] novoArray = new object[novoTam];

            int ii = i;

            for (int ff = 0; ff < Size(); ff++)
            {
                novoArray[ff] = array[ii];
                ii = (ii + 1) % tamanho;
            }
            f = Size();
            i = 0;
            tamanho = novoTam;
            array = novoArray;
        }
        array[f] = elemento;
        f = (f + 1) % tamanho;
        n_elementos++;
    }

    public object Dequeue()
    {
        object elemento = array[i];
        i = (i + 1) % tamanho;
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
        return tamanho;
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