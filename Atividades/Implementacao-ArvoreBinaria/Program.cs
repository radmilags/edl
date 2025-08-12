using System;
using System.Collections.Generic;

public class No
{
    public int Valor;
    public No Esquerdo;
    public No Direito;

    public No(int valor)
    {
        this.Valor = valor;
        this.Esquerdo = null;
        this.Direito = null;
    }
}

public class ArvoreBinariaPesquisa
{
    private No raiz;

    public ArvoreBinariaPesquisa()
    {
        this.raiz = null;
    }

    private No InsertRecursivo(No noAtual, int valor)
    {
        if (noAtual == null)
        {
            return new No(valor);
        }

        if (valor < noAtual.Valor)
        {
            noAtual.Esquerdo = InsertRecursivo(noAtual.Esquerdo, valor);
        }
        else if (valor > noAtual.Valor)
        {
            noAtual.Direito = InsertRecursivo(noAtual.Direito, valor);
        }

        return noAtual;
    }

    public void Insert(int valor)
    {
        this.raiz = InsertRecursivo(this.raiz, valor);
    }

    private No SearchRecursivo(No noAtual, int valor)
    {
        if (noAtual == null || noAtual.Valor == valor)
        {
            return noAtual;
        }

        if (valor < noAtual.Valor)
        {
            return SearchRecursivo(noAtual.Esquerdo, valor);
        }

        return SearchRecursivo(noAtual.Direito, valor);
    }

    public bool Search(int valor)
    {
        return SearchRecursivo(this.raiz, valor) != null;
    }
    
    private int EncontrarMenorValor(No no)
    {
        int menorValor = no.Valor;
        while (no.Esquerdo != null)
        {
            menorValor = no.Esquerdo.Valor;
            no = no.Esquerdo;
        }
        return menorValor;
    }

    private No RemoveRecursivo(No noAtual, int valor)
    {
        if (noAtual == null) return noAtual;

        if (valor < noAtual.Valor)
        {
            noAtual.Esquerdo = RemoveRecursivo(noAtual.Esquerdo, valor);
        }
        else if (valor > noAtual.Valor)
        {
            noAtual.Direito = RemoveRecursivo(noAtual.Direito, valor);
        }
        else
        {
            if (noAtual.Esquerdo == null)
                return noAtual.Direito;
            else if (noAtual.Direito == null)
                return noAtual.Esquerdo;

            noAtual.Valor = EncontrarMenorValor(noAtual.Direito);
            noAtual.Direito = RemoveRecursivo(noAtual.Direito, noAtual.Valor);
        }
        
        return noAtual;
    }

    public void Remove(int valor)
    {
        this.raiz = RemoveRecursivo(this.raiz, valor);
    }

    private void MostrarRecursivo(No no, string indent, bool ultimo)
    {
        Console.Write(indent);
        if (ultimo)
        {
            Console.Write("└───");
            indent += "    ";
        }
        else
        {
            Console.Write("├───");
            indent += "│   ";
        }
        Console.WriteLine(no.Valor);

        var filhos = new List<No>();
        if (no.Esquerdo != null) filhos.Add(no.Esquerdo);
        if (no.Direito != null) filhos.Add(no.Direito);

        for (int i = 0; i < filhos.Count; i++)
        {
            MostrarRecursivo(filhos[i], indent, i == filhos.Count - 1);
        }
    }

    public void Mostrar()
    {
        if (this.raiz != null)
        {
            MostrarRecursivo(this.raiz, "", true);
        }
        else
        {
            Console.WriteLine("Árvore vazia.");
        }
    }
}


public class Programa
{
    public static void Main(string[] args)
    {
        ArvoreBinariaPesquisa arvore = new ArvoreBinariaPesquisa();

        Console.WriteLine(" Construindo a árvore inicial");
        arvore.Insert(10);
        arvore.Insert(5);
        arvore.Insert(15);
        arvore.Insert(2);
        arvore.Insert(8);
        arvore.Insert(22);
        
        arvore.Mostrar();

        Console.WriteLine("Testando busca ");
        Console.WriteLine("Buscando pelo valor 8: " + (arvore.Search(8) ? "Encontrado" : "Não Encontrado"));
        Console.WriteLine("Buscando pelo valor 99: " + (arvore.Search(99) ? "Encontrado" : "Não Encontrado"));

        Console.WriteLine("Inserindo o valor 25");
        arvore.Insert(25);
        arvore.Mostrar();

        Console.WriteLine("Removendo o valor 5 (nó com dois filhos)");
        arvore.Remove(5);
        arvore.Mostrar();

        Console.WriteLine("Removendo o valor 2 (nó folha)");
        arvore.Remove(2);
        arvore.Mostrar();

        Console.WriteLine("Removendo o valor 15 (nó com um filho)");
        arvore.Remove(15);
        arvore.Mostrar();
    }
}