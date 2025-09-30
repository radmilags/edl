using System;

class Program
{
    public static void Main(string[] args)
    {
        Fila fila = new Fila(10, 0);

        Console.WriteLine(fila.isEmpty());
        fila.Enqueue(10);
        Console.WriteLine(fila.isEmpty());

        fila.PrintaFila();
    }
}