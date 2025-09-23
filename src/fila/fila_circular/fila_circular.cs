using System;

public class FilaCircular<T> //ver se isso aqui ta certo
{
    private T[] array;
    private int capacidade;
    private int tamanho;
    private int frente;
    private int traseira;


    public FilaCircular(int capacidade)
    {
      this.capacidade = capacidade;
      array = new T[capacidade];
      tamanho = 0;
      frente = 0;
      traseira = -1;
    }


    public void Enqueue(T item)
    {
      if (tamanho == capacidade)
      {
        DuplicarCapacidade();
      }


      traseira = (traseira + 1) % capacidade;
      array[traseira] = item;
      tamanho++;
    }


    public T Dequeue()
    {
      if (IsEmpty())
      {
        throw new InvalidOperationException("A fila está vazia.");
      }


      T itemRemovido = array[frente];
      frente = (frente + 1) % capacidade;
      tamanho--;
      return itemRemovido;
    }


    public T Front()
    {
      if (IsEmpty())
      {
        throw new InvalidOperationException("A fila está vazia.");
      }


      return array[frente];
    }


    public bool IsEmpty()
    {
        return tamanho == 0;
    }


    public int Size()
    {
        return tamanho;
    }


    private void DuplicarCapacidade()
    {
      int novaCapacidade = capacidade * 2;
      T[] novoArray = new T[novaCapacidade];


      for (int i = 0; i < tamanho; i++)
      {
        novoArray[i] = array[(frente + i) % capacidade];
      }


      array = novoArray;
      capacidade = novaCapacidade;
      frente = 0;
      traseira = tamanho - 1;
    }
}


class Program {
  public static void Main (string[] args)
  {
    FilaCircular<int> fila = new FilaCircular<int>(3);
    fila.Enqueue(1);
    fila.Enqueue(2);
    fila.Enqueue(3);
   
    Console.WriteLine(fila.Dequeue());
    fila.Enqueue(4);
   
    Console.WriteLine(fila.Dequeue());
    Console.WriteLine(fila.Dequeue());
    Console.WriteLine(fila.Dequeue());
   
    fila.Enqueue(5);
    Console.WriteLine(fila.Front());


  }
}