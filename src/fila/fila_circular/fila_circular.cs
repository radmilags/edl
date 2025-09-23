using System;

public class FilaCircular<T>
{
    private T[] array;

    private int n; 
    private int capacidade;
    private int tamanho;
    private int i;
    private int f;


    public FilaCircular(int capacidade)
    {
      this.capacidade = capacidade;
      array = new T[capacidade];
      tamanho = 0;
      i = 0;
      f = -1;
    }


    public void Enqueue(T item)
    {
      if (tamanho == capacidade)
      {
        DuplicarCapacidade();
      }


      f = (f + 1) % capacidade;
      array[f] = item;
      tamanho++;
    }


    public T Dequeue()
    {
      if (IsEmpty())
      {
        throw new InvalidOperationException("A fila está vazia.");
      }

      T itemRemovido = array[i];
      i = (i + 1) % capacidade;
      tamanho--;
      return itemRemovido;
    }


    public T Front()
    {
      if (IsEmpty())
      {
        throw new InvalidOperationException("A fila está vazia.");
      }


      return array[i];
    }


    public bool IsEmpty()
    {
        return tamanho == 0;
    }


  public int Size()
  {
    // return (n - i + f) % n;
    return tamanho;
    }


    private void DuplicarCapacidade()
    {
      int novaCapacidade = capacidade * 2;
      T[] novoArray = new T[novaCapacidade];


      for (int i = 0; i < tamanho; i++)
      {
        novoArray[i] = array[(i + i) % capacidade];
      }


      array = novoArray;
      capacidade = novaCapacidade;
      i = 0;
      f = tamanho - 1;
    }
}