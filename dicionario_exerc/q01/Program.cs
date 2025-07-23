using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Testando HashTable com Encadeamento (Chaining) ---");
        var htChaining = new HashTableChaining<string, int>();
        htChaining.Insert("Alice", 30);
        htChaining.Insert("Bob", 42);
        htChaining.Insert("Carlos", 25);

        Console.WriteLine($"Valor de 'Bob': {htChaining.Find("Bob")}"); // 42
        Console.WriteLine($"Itens na tabela: {htChaining.Count}"); 

        htChaining.Remove("Alice");
        Console.WriteLine($"Valor de 'Alice' após remoção: {htChaining.Find("Alice")}"); // 0 
        Console.WriteLine($"Itens na tabela: {htChaining.Count}"); // 2

        Console.WriteLine("\n--- Testando HashTable com Sondagem Linear (Linear Probing) ---");
        var htLinear = new HashTableLinearProbing<string, string>();
        htLinear.Insert("SKU-001", "Laptop");
        htLinear.Insert("SKU-002", "Mouse");
        htLinear.Insert("SKU-003", "Teclado");

        Console.WriteLine($"Valor de 'SKU-002': {htLinear.Find("SKU-002")}"); // Mouse
        Console.WriteLine($"Itens na tabela: {htLinear.Count}"); // 3
        
        htLinear.Remove("SKU-001");
        Console.WriteLine($"Valor de 'SKU-001' após remoção: {htLinear.Find("SKU-001")}"); // null (default)
        Console.WriteLine($"Itens na tabela: {htLinear.Count}"); // 2
        
        htLinear.Insert("SKU-004", "Monitor");
        Console.WriteLine($"Valor de 'SKU-004': {htLinear.Find("SKU-004")}");
        Console.WriteLine($"Itens na tabela: {htLinear.Count}"); // 3
    }
}