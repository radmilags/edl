using System;

public class VetorArray<T> : IVetor<T>
{
    private T[] elementos;
    private int tamanho;

    // Construtor que inicia o vetor com uma capacidade inicial.
    public VetorArray(int capacidadeInicial = 4)
    {
        elementos = new T[capacidadeInicial];
        tamanho = 0;
    }

    // n elementos
    public int Tamanho => tamanho;

    public int Capacidade => elementos.Length;

    public bool EstaVazio => tamanho == 0;


    // Adiciona um elemento no final
    public void Adicionar(T item)
    {
        VerificarECrescer();
        elementos[tamanho] = item;
        tamanho++;
    }

    // Adiciona um elemento em um índice específico
    public void AdicionarEm(int indice, T item)
    {
        if (indice < 0 || indice > tamanho)
        {
            throw new IndexOutOfRangeException("Índice inválido para inserção.");
        }

        VerificarECrescer();

        // Desloca os elementos para a direita para abrir espaço
        for (int i = tamanho; i > indice; i--)
        {
            elementos[i] = elementos[i - 1];
        }

        elementos[indice] = item;
        tamanho++;
    }

    // Remove um elemento de um índice específico
    public T RemoverEm(int indice)
    {
        if (indice < 0 || indice >= tamanho)
        {
            throw new IndexOutOfRangeException("Índice inválido para remoção.");
        }

        T itemRemovido = elementos[indice];

        // Desloca os elementos para a esquerda para fechar o buraco
        for (int i = indice; i < tamanho - 1; i++)
        {
            elementos[i] = elementos[i + 1];
        }

        tamanho--;
        elementos[tamanho] = default(T); // Limpa a última posição antiga

        VerificarEEncolher();
        return itemRemovido;
    }

    // get o elemento em um índice
    public T Obter(int indice)
    {
        if (indice < 0 || indice >= tamanho)
        {
            throw new IndexOutOfRangeException("Índice fora do intervalo do vetor.");
        }
        return elementos[indice];
    }

    // Verifica se um elemento existe no vetor
    public bool Contem(T item)
    {
        return IndiceDe(item) != -1;
    }

    // Retorna o índice de um elemento.
    public int IndiceDe(T item)
    {
        for (int i = 0; i < tamanho; i++)
        {
            if (elementos[i].Equals(item))
            {
                return i;
            }
        }
        return -1; // Não encontrou
    }

    private void VerificarECrescer()
    {

        if (tamanho == elementos.Length)
        {
            Redimensionar(elementos.Length * 2);
        }
    }

    private void VerificarEEncolher()
    {

        if (tamanho > 0 && tamanho < elementos.Length / 3)
        {
            int novaCapacidade = Math.Max(elementos.Length / 2, 4);
            Redimensionar(novaCapacidade);
        }
    }

    private void Redimensionar(int novaCapacidade)
    {
        T[] novoArray = new T[novaCapacidade];
        for (int i = 0; i < tamanho; i++)
        {
            novoArray[i] = elementos[i];
        }
        elementos = novoArray;
    }
    
    public override string ToString()
    {
        if(tamanho == 0) return "[]";

        string s = "[";
        for (int i = 0; i < tamanho - 1; i++)
        {
            s += $"{elementos[i]}, ";
        }
        s += $"{elementos[tamanho - 1]}]";
        return s;
    }
}