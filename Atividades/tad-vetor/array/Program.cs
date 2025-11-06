using System;

class Program
{
    public static void Main(string[] args)
    {
        Vetor vetor = new Vetor(4);

        vetor.insertAtRank(0, 10);
        vetor.PrintaVetor();
        
        vetor.insertAtRank(1, 20);
        vetor.PrintaVetor();

        vetor.insertAtRank(0, 30);
        vetor.PrintaVetor();

        vetor.replaceAtRank(1, 99);
        vetor.PrintaVetor();
        
        vetor.insertAtRank(3, 40);
        vetor.PrintaVetor();
        
        vetor.insertAtRank(4, 50);
        vetor.PrintaVetor();

        object removido = vetor.removeAtRank(2);
        vetor.PrintaVetor();
        
        Console.WriteLine(removido);
        Console.WriteLine(vetor.elemAtRank(0));
        Console.WriteLine(vetor.size());
    }
}