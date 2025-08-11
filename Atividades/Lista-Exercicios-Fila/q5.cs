//5. Implemente uma classe Fila usando a classe Vector para armazenar os elementos internamente.
using System;
public class Vector<T>
{
    private T[] dados;
    private int tamanho;

    public Vector()
    {
        dados = new T[10]; // capacidade inicial
        tamanho = 0;
    }

    public int Tamanho => tamanho;

    public void Adicionar(T elemento)
    {
        if (tamanho == dados.Length)
        {
            Redimensionar();
        }
        dados[tamanho++] = elemento;
    }

    public T Obter(int indice)
    {
        if (indice < 0 || indice >= tamanho)
        {
            throw new IndexOutOfRangeException("Índice inválido.");
        }
        return dados[indice];
    }

    public void RemoverInicio()
    {
        if (tamanho == 0)
        {
            throw new InvalidOperationException("Vector vazio.");
        }

        for (int i = 0; i < tamanho - 1; i++)
        {
            dados[i] = dados[i + 1];
        }

        tamanho--;
        dados[tamanho] = default; // limpar a referência
    }

    private void Redimensionar()
    {
        int novaCapacidade = dados.Length * 2;
        T[] novoArray = new T[novaCapacidade];

        for (int i = 0; i < dados.Length; i++)
        {
            novoArray[i] = dados[i];
        }

        dados = novoArray;
    }

    public bool EstaVazio()
    {
        return tamanho == 0;
    }
}

public class Fila<T>
{
    private Vector<T> elementos;

    public Fila()
    {
        elementos = new Vector<T>();
    }

    public void Enfileirar(T item)
    {
        elementos.Adicionar(item);
    }

    public T Desenfileirar()
    {
        if (elementos.EstaVazio())
        {
            throw new InvalidOperationException("Fila vazia.");
        }

        T item = elementos.Obter(0);
        elementos.RemoverInicio();
        return item;
    }

    public T Espiar()
    {
        if (elementos.EstaVazio())
        {
            throw new InvalidOperationException("Fila vazia.");
        }

        return elementos.Obter(0);
    }

    public bool EstaVazia()
    {
        return elementos.EstaVazio();
    }

    public int Tamanho()
    {
        return elementos.Tamanho;
    }
}

class Program
{
    static void Main()
    {
        Fila<int> fila = new Fila<int>();

        fila.Enfileirar(10);
        fila.Enfileirar(20);
        fila.Enfileirar(30);

        Console.WriteLine("Espiar: " + fila.Espiar()); // 10

        Console.WriteLine("Desenfileirando: " + fila.Desenfileirar()); // 10
        Console.WriteLine("Desenfileirando: " + fila.Desenfileirar()); // 20

        fila.Enfileirar(40);
        Console.WriteLine("Espiar: " + fila.Espiar()); // 30
    }
}
