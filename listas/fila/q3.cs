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


public class Queue<T>
{
    private Node<T> front;
    private Node<T> rear;


    public Queue()
    {
        front = null;
        rear = null;
    }


    public void Enqueue(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (rear == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
    }


    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A fila está vazia.");
        }


        T data = front.Data;
        front = front.Next;
        if (front == null)
        {
            rear = null;
        }
        return data;
    }


    public bool IsEmpty()
    {
        return front == null;
    }
}


public class Stack<T>
{
    private Node<T> top;


    public Stack()
    {
        top = null;
    }


    public void Adiciona(T item)
    {
        Node<T> newNode = new Node<T>(item);
        newNode.Next = top;
        top = newNode;
    }


    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A pilha está vazia.");
        }


        T data = top.Data;
        top = top.Next;
        return data;
    }


    public bool IsEmpty()
    {
        return top == null;
    }
}






class Program {
  public static void Main (string[] args)
  {
    Queue<int> fila = new Queue<int>();
    fila.Enqueue(1);
    fila.Enqueue(2);
    fila.Enqueue(3);


    Console.WriteLine(fila.Dequeue());
    Console.WriteLine(fila.Dequeue());


    Stack<string> pilha = new Stack<string>();


    //lembrar que PUSH é EMPURRAR - IN
    //Adiciona = método Push
    pilha.Adiciona("R");
    pilha.Adiciona("A");
    pilha.Adiciona("D");


   
    //adicionar metodo que retorna os elementos de uma pilha
    Console.WriteLine(pilha);
   
    Console.WriteLine(pilha.Pop());
    Console.WriteLine(pilha.Pop());


  }
}