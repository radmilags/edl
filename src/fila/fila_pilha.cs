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

    // novo elemento no topo
    public void Adiciona(T item)
    {
        Node<T> newNode = new Node<T>(item);
        newNode.Next = top;
        top = newNode;
    }

    // retorna o primeiro elemento e remove
    public T Pop()
    {
        // verifica se está vazia, ou seja, nao tem topo
        if (IsEmpty())
        {
            throw new InvalidOperationException("A pilha está vazia.");
        }

        // 
        T data = top.Data;
        top = top.Next;
        return data;
    }


    public bool IsEmpty()
    {
        return top == null;
    }
}

