using System;

public class Vetor
{
    object[] vetor; 
    int size;
    int capacidade;
    
    public Vetor(int capacidade)
    {
        vetor = new object[capacidade]; 
        this.capacidade = capacidade; 
        size = 0;
    }

    public object elemAtRank(int r)
    {
        if (r < 0 || r >= size)
        {
            throw new IndexOutOfRangeException("Colocação (rank) inválida, more.");
        }
        return vetor[r]; 
    }

    public object replaceAtRank(int r, object o)
    {
        if (r < 0 || r >= size)
        {
            throw new IndexOutOfRangeException("Colocação (rank) inválida, more.");
        }
        object antigoElemento = vetor[r]; 
        vetor[r] = o; 
        return antigoElemento;
    }

    public void insertAtRank(int r, object o)
    {
        if (r < 0 || r > size)
        {
            throw new IndexOutOfRangeException("Colocação (rank) inválida, more.");
        }
        
        if (TaCheia())
        {
            DobraArray();
        }

        for (int i = size; i > r; i--)
        {
            vetor[i] = vetor[i - 1]; 
        }

        vetor[r] = o; 
        size++;
    }

    public object removeAtRank(int r)
    {
        if (isEmpty() || r < 0 || r >= size)
        {
            throw new IndexOutOfRangeException("Colocação (rank) inválida ou vetor vazio, more.");
        }

        object elemento = vetor[r]; 
        
        for (int i = r; i < size - 1; i++)
        {
            vetor[i] = vetor[i + 1]; 
        }

        size--;
        vetor[size] = null; 

        return elemento;
    }
    
    public int size()
    {
        return size;
    }

    public bool isEmpty()
    {
        if (size == 0) return true;
        return false;
    }
    
    private void DobraArray()
    {
        capacidade = capacidade * 2; 
        object[] novoVetor = new object[capacidade]; 

        for (int i = 0; i < size; i++)
        {
            novoVetor[i] = vetor[i]; 
        }
        vetor = novoVetor; 
    }
    
    private bool TaCheia()
    {
        if (capacidade == size) return true;
        return false;
    }

    public void PrintaVetor()
    {
        Console.WriteLine("Printando o Vetor:");
        Console.Write("[");
        for(int i = 0; i < size; i++)
        {
            Console.Write($"{vetor[i]}"); 
            if (i < size - 1)
            {
                 Console.Write(", ");
            }
        }
        Console.Write("]");
        Console.WriteLine($" (Tamanho={size}, Capacidade={capacidade})");
    }
}