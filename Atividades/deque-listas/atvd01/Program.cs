using System;

class Program
{
    public static void Main(string[] args)
    {
        Deque deque = new Deque(10, 0);

        Console.WriteLine(deque.isEmpty());
        deque.Enqueue(10);
        Console.WriteLine(deque.isEmpty());

        deque.PrintaFila();
    }
}