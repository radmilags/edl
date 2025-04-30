/* 1. Descreva o estado da fila (inicialmente vazia) após cada uma das operações a seguir: (R-4.2)
enqueue(5), enqueue(3), dequeue(), enqueue(2), enqueue(8), dequeue(), dequeue(),
enqueue(9), enqueue(1), dequeue(), enqueue(7), enqueue(6), dequeue(), dequeue(),
enqueue(4), enqueue (7), dequeue().*/
using System;

public class Fila<T>
{
    private Node<T> primeiro;
    private Node<T> ultimo;

    public Fila()
    {
        primeiro = null;
        ultimo = null;
    }

    public void Enqueue(T valor)
    {
        Node<T> novoNo = new Node<T>(valor);

        if (ultimo != null)
        {
            ultimo.Proximo = novoNo;
        }
        ultimo = novoNo;

        if (primeiro == null)
        {
            primeiro = novoNo;
        }
    }

    public T Dequeue()
    {
        if (primeiro == null)
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        T valorRemovido = primeiro.Valor;
        primeiro = primeiro.Proximo;

        if (primeiro == null)
        {
            ultimo = null;
        }

        return valorRemovido;
    }

    public void MostrarFila()
    {
        if (primeiro == null)
        {
            Console.WriteLine("Fila vazia.");
            return;
        }

        Node<T> atual = primeiro;
        while (atual != null)
        {
            Console.Write(atual.Valor + " ");
            atual = atual.Proximo;
        }
        Console.WriteLine();
    }

    private class Node<U>
    {
        public U Valor;
        public Node<U> Proximo;

        public Node(U valor)
        {
            Valor = valor;
            Proximo = null;
        }
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Fila<int> fila = new Fila<int>();

        fila.Enqueue(5);
        fila.MostrarFila();  // Estado da fila após enqueue(5)

        fila.Enqueue(3);
        fila.MostrarFila();  // Estado da fila após enqueue(3)

        fila.Dequeue();
        fila.MostrarFila();  // Estado da fila após dequeue()

        fila.Enqueue(2);
        fila.MostrarFila();  // Estado da fila após enqueue(2)

        fila.Enqueue(8);
        fila.MostrarFila();  // Estado da fila após enqueue(8)

        fila.Dequeue();
        fila.MostrarFila();  // Estado da fila após dequeue()

        fila.Dequeue();
        fila.MostrarFila();  // Estado da fila após dequeue()

        fila.Enqueue(9);
        fila.MostrarFila();  // Estado da fila após enqueue(9)

        fila.Enqueue(1);
        fila.MostrarFila();  // Estado da fila após enqueue(1)

        fila.Dequeue();
        fila.MostrarFila();  // Estado da fila após dequeue()

        fila.Enqueue(7);
        fila.MostrarFila();  // Estado da fila após enqueue(7)

        fila.Enqueue(6);
        fila.MostrarFila();  // Estado da fila após enqueue(6)

        fila.Dequeue();
        fila.MostrarFila();  // Estado da fila após dequeue()

        fila.Dequeue();
        fila.MostrarFila();  // Estado da fila após dequeue()

        fila.Enqueue(4);
        fila.MostrarFila();  // Estado da fila após enqueue(4)

        fila.Enqueue(7);
        fila.MostrarFila();  // Estado da fila após enqueue(7)

        fila.Dequeue();
        fila.MostrarFila();  // Estado da fila após dequeue()
    }
}
