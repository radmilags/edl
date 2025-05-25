using System;

class TesteFila
{
    static void Main(string[] args)
    {
        Fila f = new Fila(1, 0);
        f.Enqueue(1);
        f.Enqueue(2);
        f.Enqueue(3);
        f.Enqueue(4);

        try
        {
            Console.WriteLine(f.First());
            f.Dequeue();
            Console.WriteLine(f.First()); 
            f.Dequeue();
            Console.WriteLine(f.First()); 
            f.Dequeue();
            Console.WriteLine(f.First()); 
            f.Dequeue();
            Console.WriteLine(f.First()); 
            f.Dequeue();                  
        }
        catch (FilaVaziaException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
