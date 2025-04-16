using System;

public class Node<T>
{
  public T Data { get; set; }
  public Node<T> Next { get; set; }


  public Node(T data)
  {
    Data = data;
    Next = null;
  }
}


public class Pilha<T>
{
  private Node<T> topo;


  public Pilha()
  {
    topo = null;
  }


  public void Empilhar(T item)
  {
    Node<T> novoNode = new Node<T>(item);
    novoNode.Next = topo;
    topo = novoNode;
  }


  public T Desempilhar()
  {
    if (EstaVazia())
    {
      throw new InvalidOperationException("A pilha está vazia.");
    }


    T elementoDesempilhado = topo.Data;
    topo = topo.Next;
    return elementoDesempilhado;
  }


  public T Topo()
  {
    if (EstaVazia())
    {
      throw new InvalidOperationException("A pilha está vazia.");
    }


    return topo.Data;
  }


  public bool EstaVazia()
  {
    return topo == null;
  }
}

class Program {
  public static void Main (string[] args)
  {
    Pilha<int> pilha = new Pilha<int>();
    pilha.Empilhar(1);
    pilha.Empilhar(2);
    pilha.Empilhar(3);
   
    Console.WriteLine(pilha.Topo());
    Console.WriteLine(pilha.Desempilhar());
    Console.WriteLine(pilha.Desempilhar());
   
    pilha.Empilhar(4);
    Console.WriteLine(pilha.Topo());


  }
}