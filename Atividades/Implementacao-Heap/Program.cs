using System;
using System.Collections.Generic;

public class FilaPrioridadeHeap
{
    private List<int> heap;

    public FilaPrioridadeHeap()
    {
        heap = new List<int>();
    }

    private int IndicePai(int i) => (i - 1) / 2;
    private int IndiceFilhoEsquerdo(int i) => 2 * i + 1;
    private int IndiceFilhoDireito(int i) => 2 * i + 2;

    private void Troca(int i, int j)
    {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }

    private void SobeHeap(int indice)
    {
        if (indice > 0 && heap[indice] < heap[IndicePai(indice)])
        {
            Troca(indice, IndicePai(indice));
            SobeHeap(IndicePai(indice));
        }
    }

    private void DesceHeap(int indice)
    {
        int menorIndice = indice;
        int esquerdo = IndiceFilhoEsquerdo(indice);
        int direito = IndiceFilhoDireito(indice);

        if (esquerdo < Size() && heap[esquerdo] < heap[menorIndice])
        {
            menorIndice = esquerdo;
        }

        if (direito < Size() && heap[direito] < heap[menorIndice])
        {
            menorIndice = direito;
        }

        if (indice != menorIndice)
        {
            Troca(indice, menorIndice);
            DesceHeap(menorIndice);
        }
    }

    public void Insert(int valor)
    {
        heap.Add(valor);
        SobeHeap(heap.Count - 1);
    }

    public int RemoveMin()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A fila de prioridade está vazia.");
        }

        int minimo = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        DesceHeap(0);

        return minimo;
    }

    public int Min()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A fila de prioridade está vazia.");
        }
        return heap[0];
    }

    public int Size()
    {
        return heap.Count;
    }

    public bool IsEmpty()
    {
        return heap.Count == 0;
    }
}


public class Programa
{
    public static void Main(string[] args)
    {
        FilaPrioridadeHeap filaDePrioridade = new FilaPrioridadeHeap();

        Console.WriteLine("A fila está vazia? " + filaDePrioridade.IsEmpty());

        Console.WriteLine("\nInserindo elementos: 10, 4, 15, 20, 3...");
        filaDePrioridade.Insert(10);
        filaDePrioridade.Insert(4);
        filaDePrioridade.Insert(15);
        filaDePrioridade.Insert(20);
        filaDePrioridade.Insert(3);

        Console.WriteLine("A fila está vazia? " + filaDePrioridade.IsEmpty());
        Console.WriteLine("Tamanho da fila: " + filaDePrioridade.Size());
        Console.WriteLine("Elemento de maior prioridade (mínimo): " + filaDePrioridade.Min());

        Console.WriteLine("\nRemovendo elementos em ordem de prioridade:");
        while (!filaDePrioridade.IsEmpty())
        {
            Console.WriteLine("Removido: " + filaDePrioridade.RemoveMin() + " | Tamanho atual: " + filaDePrioridade.Size());
        }

        Console.WriteLine("\nA fila está vazia? " + filaDePrioridade.IsEmpty());
    }
}