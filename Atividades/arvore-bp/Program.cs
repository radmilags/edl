public class Programa
{
    public static void Main(string[] args)
    {
        ABPArray abp = new ABPArray(30); 
        
        abp.Insert(10, "Raiz");
        abp.Insert(5, "Cinco");
        abp.Insert(15, "Quinze");
        abp.Insert(2, "Dois");
        abp.Insert(8, "Oito");
        abp.Insert(22, "VinteDois");
        abp.Mostrar();

        Console.Write("Travessia InOrder (Ordenada): ");
        abp.InOrder(0);

        abp.Insert(25, "VinteCinco");
        abp.Mostrar();
        
        abp.Remove(5);
        abp.Mostrar();

        Console.Write("Travessia InOrder (Final): ");
        abp.InOrder(0);
        Console.WriteLine();
        Console.WriteLine("Tamanho final: " + abp.size());
    }
}

