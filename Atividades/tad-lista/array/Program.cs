using System;

class Program
{
    public static void Main(string[] args)
    {
        Lista lista = new Lista(10);
        lista.insertLast(1);
        lista.PrintaLista();
        lista.insertFirst(2);
        lista.PrintaLista();
        lista.insertAfter(0, 4);
        lista.PrintaLista();
        lista.insertBefore(1, 5);
        lista.PrintaLista();
        // Console.WriteLine(lista.Size());
    }
}