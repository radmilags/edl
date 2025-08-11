using System;
using System.Collections.Generic;

#nullable enable

// Implementa uma Árvore Binária de Pesquisa (BST) genérica.
// A restrição "where T : IComparable<T>" garante que o tipo T pode ser comparado.
public class ArvoreBinariaPesquisa<T> where T : IComparable<T>
{
    // O nó raiz da árvore.
    public No<T>? Raiz { get; private set; }

    public ArvoreBinariaPesquisa()
    {
        Raiz = null;
    }

    // --- INSERÇÃO ---
    public void Inserir(T valor)
    {
        Raiz = InserirRecursivo(Raiz, valor);
    }

    private No<T> InserirRecursivo(No<T>? no, T valor)
    {
        // Caso base: encontrou um espaço vazio para inserir o novo nó.
        if (no == null)
        {
            return new No<T>(valor);
        }

        int comparacao = valor.CompareTo(no.Valor);

        if (comparacao < 0)
        {
            no.FilhoEsquerda = InserirRecursivo(no.FilhoEsquerda, valor);
        }
        else if (comparacao > 0)
        {
            no.FilhoDireita = InserirRecursivo(no.FilhoDireita, valor);
        }
        
        return no;
    }

    // --- BUSCA ---
    public bool Buscar(T valor)
    {
        return BuscarRecursivo(Raiz, valor);
    }

    private bool BuscarRecursivo(No<T>? no, T valor)
    {
        if (no == null) return false;

        int comparacao = valor.CompareTo(no.Valor);

        if (comparacao == 0) return true;
        
        return comparacao < 0
            ? BuscarRecursivo(no.FilhoEsquerda, valor)
            : BuscarRecursivo(no.FilhoDireita, valor);
    }

    // --- REMOÇÃO ---
    public void Remover(T valor)
    {
        Raiz = RemoverRecursivo(Raiz, valor);
    }

    private No<T>? RemoverRecursivo(No<T>? no, T valor)
    {
        if (no == null) return null;

        int comparacao = valor.CompareTo(no.Valor);

        if (comparacao < 0) {
            no.FilhoEsquerda = RemoverRecursivo(no.FilhoEsquerda, valor);
        } else if (comparacao > 0) {
            no.FilhoDireita = RemoverRecursivo(no.FilhoDireita, valor);
        } else {
            // Encontrou o nó a ser removido.
            // Caso 1: Nó com 0 ou 1 filho.
            if (no.FilhoEsquerda == null) return no.FilhoDireita;
            if (no.FilhoDireita == null) return no.FilhoEsquerda;

            // Caso 2: Nó com 2 filhos.
            // Substitui o valor do nó pelo menor valor da subárvore direita.
            no.Valor = EncontrarMenorValor(no.FilhoDireita);
            // Remove o nó que continha esse menor valor.
            no.FilhoDireita = RemoverRecursivo(no.FilhoDireita, no.Valor);
        }
        return no;
    }

    // Encontra o menor valor em uma subárvore (indo sempre para a esquerda).
    private T EncontrarMenorValor(No<T> no)
    {
        while (no.FilhoEsquerda != null)
        {
            no = no.FilhoEsquerda;
        }
        return no.Valor;
    }

    // --- PERCURSOS ---
    public void EmOrdem() { EmOrdemRecursivo(Raiz); Console.WriteLine(); }
    private void EmOrdemRecursivo(No<T>? no)
    {
        if (no != null)
        {
            EmOrdemRecursivo(no.FilhoEsquerda);
            Console.Write(no.Valor + " ");
            EmOrdemRecursivo(no.FilhoDireita);
        }
    }
    
    // --- EXIBIÇÃO ---
    public void Mostrar()
    {
        if (Raiz == null)
        {
            Console.WriteLine("Árvore vazia.");
            return;
        }
        MostrarRecursivo(Raiz, "", true, true);
    }
    
    // Imprime a estrutura hierárquica da árvore.
    private void MostrarRecursivo(No<T> no, string prefixo, bool ehUltimo, bool ehRaiz)
    {
        if (ehRaiz) {
            Console.WriteLine($"<RAIZ>── {no.Valor}");
        } else {
            Console.WriteLine($"{prefixo}{(ehUltimo ? "└── " : "├── ")}{no.Valor}");
        }

        var filhos = new List<No<T>?>();
        if (no.FilhoEsquerda != null) filhos.Add(no.FilhoEsquerda);
        if (no.FilhoDireita != null) filhos.Add(no.FilhoDireita);

        for (int i = 0; i < filhos.Count; i++)
        {
            string novoPrefixo = prefixo + (ehUltimo || ehRaiz ? "     " : "│    ");
            MostrarRecursivo(filhos[i]!, novoPrefixo, i == filhos.Count - 1, false);
        }
    }
}
