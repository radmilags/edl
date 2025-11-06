using System;

class Program
{
    public static void Main(string[] args)
    {
        Lista lista = new Lista();
        
        lista.insertLast(1);
        lista.PrintaLista();
        
        lista.insertFirst(2);
        lista.PrintaLista();
        
        lista.insertLast(3);
        lista.PrintaLista();
        
        lista.RemoveFirst();
        lista.PrintaLista();
        
        lista.insertLast(4);
        lista.PrintaLista();

        lista.RemoveLast();
        lista.PrintaLista();
        
        lista.ReplaceElement(0, 99);
        lista.PrintaLista();

        lista.Remove(0);
        lista.PrintaLista();
        
        Console.WriteLine(lista.Size());
    }
}