using System;
using System.Collections; // Necessário para ArrayList

public class PilhaComArrayList
{
    // --- Renomeado de _lista para pilha ---
    private ArrayList pilha; 

    public PilhaComArrayList()
    {
        // --- Alterado aqui ---
        pilha = new ArrayList();
    }

    // Retorna o número de elementos na pilha
    public int Count
    {
        // --- Alterado aqui ---
        get { return pilha.Count; }
    }

    // Verifica se a pilha está vazia
    public bool IsEmpty
    {
        // --- Alterado aqui ---
        get { return pilha.Count == 0; }
    }

    // Adiciona um item ao topo da pilha (Push)
    public void Push(object item)
    {
        // --- Alterado aqui ---
        pilha.Add(item);
    }

    // Remove e retorna o item do topo da pilha (Pop)
    public object Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("A pilha está vazia.");
        }

        // --- Alterado aqui ---
        object item = pilha[pilha.Count - 1];
        
        // --- Alterado aqui ---
        pilha.RemoveAt(pilha.Count - 1);
        
        return item;
    }

    // Retorna o item do topo da pilha sem removê-lo (Peek)
    public object Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("A pilha está vazia.");
        }

        // --- Alterado aqui ---
        return pilha[pilha.Count - 1];
    }

    // Limpa a pilha
    public void Clear()
    {
        // --- Alterado aqui ---
        pilha.Clear();
    }
}

// --- Exemplo de Uso (continua igual) ---
public class ExemploArrayList
{
    public static void Main(string[] args)
    {
        // O nome da CLASSE continua o mesmo
        PilhaComArrayList minhaPilha = new PilhaComArrayList(); 
        
        minhaPilha.Push(10);
        minhaPilha.Push(20);
        minhaPilha.Push("Olá"); 

        Console.WriteLine($"Item no topo (Peek): {minhaPilha.Peek()}"); 

        try
        {
            string s = (string)minhaPilha.Pop(); 
            Console.WriteLine($"Pop: {s}");

            int i = (int)minhaPilha.Pop(); 
            Console.WriteLine($"Pop: {i}");
            
            int j = (int)minhaPilha.Pop(); 
            Console.WriteLine($"Pop: {j}");

            minhaPilha.Pop(); // Lança Exceção
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}