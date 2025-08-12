using System;

public class FilaPrioridadeHeapArray
{
    private int[] heap;
    private int tamanho;
    private int capacidade;

    public FilaPrioridadeHeapArray(int capacidadeInicial = 10)
    {
        this.capacidade = capacidadeInicial;
        this.heap = new int[this.capacidade];
        this.tamanho = 0;
    }

    private void GarantirCapacidade()
    {
        if (tamanho == capacidade)
        {
            capacidade *= 2;
            int[] novoHeap = new int[capacidade];
            for (int i = 0; i < tamanho; i++)
            {
                novoHeap[i] = heap[i];
            }
            heap = novoHeap;
        }
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

        if (esquerdo < tamanho && heap[esquerdo] < heap[menorIndice])
        {
            menorIndice = esquerdo;
        }
        if (direito < tamanho && heap[direito] < heap[menorIndice])
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
        GarantirCapacidade();
        heap[tamanho] = valor;
        tamanho++;
        SobeHeap(tamanho - 1);
    }

    public int RemoveMin()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Fila vazia.");
        
        int minimo = heap[0];
        heap[0] = heap[tamanho - 1];
        tamanho--;
        DesceHeap(0);
        return minimo;
    }

    public int Min()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Fila vazia.");
        
        return heap[0];
    }

    public int Size() => tamanho;
    public bool IsEmpty() => tamanho == 0;
}