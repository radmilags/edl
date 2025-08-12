public class Programa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("### TESTANDO HEAP COM ARRAY 'NA MÃO' ###");
        FilaPrioridadeHeapArray filaArray = new FilaPrioridadeHeapArray(3);

        filaArray.Insert(10);
        filaArray.Insert(4);
        filaArray.Insert(15);
        Console.WriteLine("Tamanho: " + filaArray.Size() + ", Mínimo: " + filaArray.Min());
        
        Console.WriteLine("Inserindo mais um para forçar o Rehash...");
        filaArray.Insert(3);
        Console.WriteLine("Tamanho: " + filaArray.Size() + ", Mínimo: " + filaArray.Min());

        Console.WriteLine("\nRemovendo em ordem de prioridade:");
        while (!filaArray.IsEmpty())
        {
            Console.WriteLine("Removido: " + filaArray.RemoveMin());
        }

        Console.WriteLine("\n---------------------------------------\n");

        Console.WriteLine("### TESTANDO HEAP COM OBJETOS NÓ ###");
        FilaPrioridadeHeapNos filaNos = new FilaPrioridadeHeapNos();

        filaNos.Insert(10);
        filaNos.Insert(4);
        filaNos.Insert(15);
        filaNos.Insert(20);
        filaNos.Insert(3);
        Console.WriteLine("Tamanho: " + filaNos.Size() + ", Mínimo: " + filaNos.Min());

        Console.WriteLine("\nRemovendo em ordem de prioridade:");
        while (!filaNos.IsEmpty())
        {
            Console.WriteLine("Removido: " + filaNos.RemoveMin());
        }
    }
}