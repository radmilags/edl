using System;

class Program
{
    public static void Main(string[] args)
    {
        Sequencia sequencia = new Sequencia();
        
        sequencia.insertFirst("Ron");
        sequencia.PrintaSequencia();
        
        sequencia.insertFirst("Harry");
        sequencia.PrintaSequencia();
        
        sequencia.insertLast("Luna");
        sequencia.PrintaSequencia();

        sequencia.insertAtRank(2, "Hermione");
        sequencia.PrintaSequencia();
        
        Console.WriteLine(sequencia.elemAtRank(2));

        sequencia.removeAtRank(0);
        sequencia.PrintaSequencia();

        No noParaTrocar = sequencia.atRank(1);
        sequencia.replaceElement(noParaTrocar, "Neville");
        sequencia.PrintaSequencia();

        No noParaRemover = sequencia.atRank(0);
        sequencia.remove(noParaRemover);
        sequencia.PrintaSequencia();
        
    }
}