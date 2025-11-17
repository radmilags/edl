using System;
using System.Collections.Generic;
using System.Drawing;

public class Deque
{
    private int size;
    private No? inicio;
    private No? fim;

    public Deque() 
    {
        inicio = null;
        fim = null;
        size = 0;
    }

    public bool isEmpty()
    {
        if (Size() == 0) return true;
        return false;
    }

    public int Size()
    {
        return this.size;
    }

    public void inserirInicio(object elemento)
    {
        No novoNo = new No(elemento);

    }


    public object Dequeue()
    {
        object elemento = array[i];
        i = (i + 1) % tamanho;
        n_elementos--;
        return elemento;
    }

    

    public void PrintaFila() {
        foreach(object o in array){
            Console.WriteLine(o);
        }
    }
}