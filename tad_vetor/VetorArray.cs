// Arquivo: VetorArray.cs
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

    // Propriedade para saber o número de elementos.
    public int Tamanho => tamanho;

    // Propriedade para saber a capacidade atual do array interno.
    public int Capacidade => elementos.Length;

    // Propriedade para checar se está vazio.
    public bool EstaVazio => tamanho == 0;


    // Adiciona um elemento no final.
    public void Adicionar(T item)
    {
        VerificarECrescer();
        elementos[tamanho] = item;
        tamanho++;
    }

    // Adiciona um elemento em um índice específico.
    public void AdicionarEm(int indice, T item)
    {
        if (indice < 0 || indice > tamanho)
        {
            throw new IndexOutOfRangeException("Índice inválido para inserção.");
        }

        VerificarECrescer();

        // Desloca os elementos para a direita para abrir espaço.
        for (int i = tamanho; i > indice; i--)
        {
            elementos[i] = elementos[i - 1];
        }

        elementos[indice] = item;
        tamanho++;
    }

    // Remove um elemento de um índice específico.
    public T RemoverEm(int indice)
    {
        if (indice < 0 || indice >= tamanho)
        {
            throw new IndexOutOfRangeException("Índice inválido para remoção.");
        }

        T itemRemovido = elementos[indice];

        // Desloca os elementos para a esquerda para fechar o buraco.
        for (int i = indice; i < tamanho - 1; i++)
        {
            elementos[i] = elementos[i + 1];
        }

        tamanho--;
        elementos[tamanho] = default(T); // Limpa a última posição antiga

        VerificarEEncolher();
        return itemRemovido;
    }

    // Pega o elemento em um índice.
    public T Obter(int indice)
    {
        if (indice < 0 || indice >= tamanho)
        {
            throw new IndexOutOfRangeException("Índice fora do intervalo do vetor.");
        }
        return elementos[indice];
    }

    // Verifica se um elemento existe no vetor.
    public bool Contem(T item)
    {
        return IndiceDe(item) != -1;
    }

    // Retorna o índice de um elemento.
    public int IndiceDe(T item)
    {
        for (int i = 0; i < tamanho; i++)
        {
            // Usa Equals para funcionar com objetos e tipos primitivos.
            if (elementos[i].Equals(item))
            {
                return i;
            }
        }
        return -1; // Não encontrou
    }

    // === MÉTODOS PRIVADOS DE REDIMENSIONAMENTO ===

    private void VerificarECrescer()
    {
        // Se o vetor está cheio, dobra a capacidade.
        if (tamanho == elementos.Length)
        {
            Redimensionar(elementos.Length * 2);
        }
    }

    private void VerificarEEncolher()
    {
        // Se a ocupação for menor que 1/3, corta a capacidade pela metade.
        // A segunda condição evita encolher para um tamanho muito pequeno (ex: 2 -> 1).
        if (tamanho > 0 && tamanho < elementos.Length / 3)
        {
             // Garante que não vamos diminuir abaixo da capacidade inicial padrão.
            int novaCapacidade = Math.Max(elementos.Length / 2, 4);
            Redimensionar(novaCapacidade);
        }
    }

    private void Redimensionar(int novaCapacidade)
    {
        Console.WriteLine($"      -> [DEBUG] Redimensionando de {Capacidade} para {novaCapacidade}");
        T[] novoArray = new T[novaCapacidade];
        for (int i = 0; i < tamanho; i++)
        {
            novoArray[i] = elementos[i];
        }
        elementos = novoArray;
    }
    
    // Método auxiliar para facilitar a visualização nos testes.
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