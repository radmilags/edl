using System;

class Program
{
    public static void Main(string[] args)
    {
        Deque deque = new Deque();

        Console.WriteLine(deque.Size());

        deque.InserirInicio(1);
        deque.InserirFinal(2);
        deque.InserirInicio(3);
        deque.InserirFinal(4);

        Console.WriteLine(deque.Size()); 
        

        Console.WriteLine(deque.Primeiro()); 
        Console.WriteLine(deque.Ultimo());    

        Console.WriteLine(deque.RemoverInicio()); 
        Console.WriteLine(deque.RemoverFim());    
        
        Console.WriteLine(deque.Size()); 
        Console.WriteLine(deque.Primeiro()); 
        Console.WriteLine(deque.Ultimo());    

        deque.RemoverFim();
        deque.RemoverInicio();

        Console.WriteLine(deque.Size());
        Console.WriteLine(deque.isEmpty());
    }
}