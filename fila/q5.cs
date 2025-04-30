using System;
using System.Collections.Generic;

public class Fila<T>
{
    private List<T> elementos;

    public Fila()
    {
        elementos = new List<T>();
    }

    // Adiciona um elemento ao final da fila
    public void Enfileirar(T item)
    {
        elementos.Add(item);
    }

    // Remove e retorna o primeiro elemento da fila
    public T Desenfileirar()
    {
        if (EstaVazia())
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        T primeiro = elementos[0];
        elementos.RemoveAt(0);
        return primeiro;
    }

    // Retorna o primeiro elemento sem remover
    public T Espiar()
    {
        if (EstaVazia())
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        return elementos[0];
    }

    // Retorna true se a fila estiver vazia
    public bool EstaVazia()
    {
        return elementos.Count == 0;
    }

    // Retorna o número de elementos na fila
    public int Tamanho()
    {
        return elementos.Count;
    }
}
