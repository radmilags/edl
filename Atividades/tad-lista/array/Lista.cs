using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public class Lista
{
    object[] lista;
    int size; // numero de elementos
    int capacidade;
    public Lista(int capacidade)
    {
        lista = new object[capacidade];
        this.capacidade = capacidade;
        size = 0;
    }

    public bool isFirst(object o)
    {
        if (First() == o) return true;
        return false;
    }

    public bool isLast(object o)
    {
        if (Last() == o) return true;
        return false;
    }

    public object First()
    {
        return lista[0];
    }

    public object Last()
    {
        return lista[size - 1];
    }

    public object Before(int posicao)
    {
        if (posicao < 0) throw new IndexOutOfRangeException("Indíce incorreto, né more"); // caso o indice seja menor que o do primeiro
        return lista[posicao - 1];
    }

    public object After(int posicao)
    {
        if (posicao > Size()) throw new IndexOutOfRangeException("Indíce grande demais, more"); // caso o indíce seja maior que o numero de elementos
        return lista[posicao + 1];
    }

    public void ReplaceElement(int posicao, object elemento) //ver o tratamento de excecao
    {
        lista[posicao] = elemento;
    }

    public void SwapElements(int p1, int p2)
    {
        object objeto1 = lista[p1];
        object objeto2 = lista[p2];

        lista[p1] = objeto2;
        lista[p2] = objeto1;
    }

    public void insertBefore(int posicao, object elemento) //Insere um novo elemento o antes da posição n
    {
        if (posicao < 0 || posicao > size)
        {
            throw new IndexOutOfRangeException("Posição de inserção inválida, more.");
        }
        
        if (TaCheia()) DobraArray();
        for (int i = size; i > posicao; i--)
        {
            lista[i] = lista[i - 1];
        }

        lista[posicao] = elemento; 
        size++;
    }

    public void insertAfter(int posicao, object elemento)
    {
        if (TaCheia()) DobraArray();
        for (int i = size; i > posicao; i--) lista[i] = lista[i - 1];
        
        lista[posicao+1] = elemento;
        size++;
    }

    public void insertFirst(object elemento)
    {
        if (TaCheia()) DobraArray();

        for (int i = size; i > 0; i--)
        {
            lista[i] = lista[i - 1];
        }
        lista[0] = elemento;
        size++;
    }

    public void insertLast(object elemento)
    {
        if (TaCheia()) DobraArray();
        lista[size] = elemento;
        size++;
    }

    public object Remove(int posicao)
    {
        if (isEmpty())
        {
            throw new IndexOutOfRangeException("Lista vazia, more.");
        }

        if (posicao < 0 || posicao >= size)
        {
            throw new IndexOutOfRangeException("Posição inválida, more.");
        }

        object elemento = lista[posicao];
        

        for (int i = posicao; i < size - 1; i++)
        {
            lista[i] = lista[i + 1];
        }

        size--;

        lista[size] = null; // ultimo elemento agr é null

        return elemento;
    }

    public int Size()
    {
        return size; // n elementos
    }

    public bool isEmpty()
    {
        if (size == 0) return true;
        return false;
    }

    public void DobraArray()
    {
        this.capacidade = capacidade * 2;
        object[] novaLista = new object[this.capacidade];

        for (int i = 0; i < size; i++)
        {
            novaLista[i] = lista[i];
        }
        lista = novaLista;
    }
    public bool TaCheia()
    {
        if (capacidade == size) return true;
        return false;
    }

    public void PrintaLista()
    {
        Console.WriteLine("Printando a lista");
        Console.Write("[");
        foreach (object i in lista)
        {
            if (i != null) Console.Write($"{i}, ");
            else Console.Write("null, ");
        }
        Console.Write("]");
        Console.WriteLine();
    }

    public void PrintaLista()
    {
        Console.WriteLine("Printando a lista (Encadeada):");
        Console.Write("[");
        No atual = this.Inicio.Proximo;
        while (atual != this.Final)
        {
            Console.Write(atual.Elemento);

            if (atual.Proximo != this.Final)
            {
                Console.Write(", ");
            }
            atual = atual.Proximo;
        }
        Console.Write("]");
        Console.WriteLine();
    }
}