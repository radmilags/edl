using System;
class Program
{
    public static void Main(string[] args)
    {
        Fila fila = new Fila(10, 0);

        fila.Enqueue(1);
        fila.Enqueue(2);
        fila.Enqueue(3);
        fila.Enqueue(4);
        fila.Enqueue(5);

        // fila.PrintaFila();
        // Console.WriteLine(fila.N_elementos());

        // Console.WriteLine(fila.Dequeue());
        // Console.WriteLine(fila.N_elementos());
        // fila.PrintaFila();

        fila.Indices();
    }
}