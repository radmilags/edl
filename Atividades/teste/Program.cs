using System;
using System.Collections;

public class Pilha
{
    ArrayList pilha;

    public Pilha()
    {
        pilha = new ArrayList();
    }

    // Adiciona ao topo
    public void Push(object o)
    {
        pilha.Add(o);
    }

    // Remove e retorna o topo
    public object Pop()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("A pilha está vazia.");
        }

        object o = pilha[pilha.Count - 1];
        pilha.RemoveAt(pilha.Count - 1); // Remove
        
        return o;
    }

    // --- NOVO MÉTODO ADICIONADO ---
    // Apenas retorna o topo (não remove)
    public object Top()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("A pilha está vazia.");
        }

        // Apenas retorna o último item, sem removê-lo
        return pilha[pilha.Count - 1]; 
    }
    // --- FIM DO NOVO MÉTODO ---

    public int Size()
    {
        return pilha.Count;
    }

    public bool isEmpty()
    {
        return pilha.Count == 0;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Pilha pilha = new Pilha();

        pilha.Push(10);
        pilha.Push(5); // '5' é o topo

        // --- EXEMPLO USANDO Top() ---
        
        // 1. Usando Top() para "espiar" o topo
        Console.WriteLine($"Item no topo (Top): {pilha.Top()}"); // Saída: 5
        
        // 2. Verificando o tamanho (ainda deve ser 2)
        Console.WriteLine($"Tamanho (depois do Top): {pilha.Size()}"); // Saída: 2

        // 3. Usando Pop() para remover o topo
        Console.WriteLine($"Item removido (Pop): {pilha.Pop()}"); // Saída: 5

        // 4. Verificando o tamanho (agora deve ser 1)
        Console.WriteLine($"Tamanho (depois do Pop): {pilha.Size()}"); // Saída: 1

        // 5. Espiando o novo topo
        Console.WriteLine($"Novo topo (Top): {pilha.Top()}"); // Saída: 10
    }
}