using System;
using System.Collections.Generic;


public class Pilha<T>
{
    private Stack<T> enfileirarStack;
    private Stack<T> desenfileirarStack;
    public Pilha()
    {
        enfileirarStack = new Stack<T>();
        desenfileirarStack = new Stack<T>();
    }


    public void enfileirar(T item)
    {
        enfileirarStack.Push(item);
    }


    public T desenfileirar()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A fila está vazia.");
        }


        if (desenfileirarStack.Count == 0)
        {
            while (enfileirarStack.Count > 0)
            {
                desenfileirarStack.Push(enfileirarStack.Pop());
            }
        }


        return desenfileirarStack.Pop();
    }


    public bool IsEmpty()
    {
        return enfileirarStack.Count == 0 && desenfileirarStack.Count == 0;
    }


    public int Count()
    {
        return enfileirarStack.Count + desenfileirarStack.Count;
    }
}

class Program {
  public static void Main (string[] args)
  {
    Pilha<int> fila = new Pilha<int>();
    fila.enfileirar(1);
    fila.enfileirar(2);
    fila.enfileirar(3);
   
    Console.WriteLine(fila.desenfileirar());
    Console.WriteLine(fila.desenfileirar());
   
    fila.enfileirar(4);
    Console.WriteLine(fila.desenfileirar());
    Console.WriteLine(fila.desenfileirar());


  }
}