using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Testando HashTable com Encadeamento (Chaining) ---");
        var htChaining = new HashTableChaining<string, int>();
        htChaining.Insert("força", 100);
        htChaining.Insert("magia", 200);
        htChaining.Insert("sabedoria", 300);

        Console.WriteLine($"Valor de 'magia': {htChaining.Find("magia")}"); // 200
        Console.WriteLine($"Itens na tabela: {htChaining.Count}"); // 3

        htChaining.Remove("força");
        Console.WriteLine($"Valor de 'força' após remoção: {htChaining.Find("força")}"); // 0 (default)
        Console.WriteLine($"Itens na tabela: {htChaining.Count}"); // 2

        Console.WriteLine("\n--- Testando HashTable com Sondagem Linear (Linear Probing) ---");
        var htLinear = new HashTableLinearProbing<string, string>();
        htLinear.Insert("elemento", "Fogo");
        htLinear.Insert("planeta", "Marte");
        htLinear.Insert("ferramenta", "Athmame");

        Console.WriteLine($"Valor de 'planeta': {htLinear.Find("planeta")}"); // Marte
        Console.WriteLine($"Itens na tabela: {htLinear.Count}"); // 3
        
        htLinear.Remove("elemento");
        Console.WriteLine($"Valor de 'elemento' após remoção: {htLinear.Find("elemento")}"); // null (default)
        Console.WriteLine($"Itens na tabela: {htLinear.Count}"); // 2
        
        // Inserindo de novo pra ver se ele reutiliza o espaço com lápide
        htLinear.Insert("deusa", "Hécate");
        Console.WriteLine($"Valor de 'deusa': {htLinear.Find("deusa")}");
        Console.WriteLine($"Itens na tabela: {htLinear.Count}"); // 3
    }
}