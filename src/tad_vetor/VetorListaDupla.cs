using System;

public class VetorListaDupla<T> : IVetor<T>
{
    // Classe interna para representar cada nó da lista.
    private class No
    {
        public T Valor { get; set; }
        public No Proximo { get; set; }
        public No Anterior { get; set; }

        public No(T valor)
        {
            this.Valor = valor;
            this.Proximo = null;
            this.Anterior = null;
        }
    }

    private No primeiro;
    private No ultimo;
    private int tamanho;

    public VetorListaDupla()
    {
        primeiro = null;
        ultimo = null;
        tamanho = 0;
    }

    public int Tamanho => tamanho;
    public bool EstaVazio => tamanho == 0;

    // Adiciona no final da lista.
    public void Adicionar(T item)
    {
        No novoNo = new No(item);
        if (EstaVazio)
        {
            primeiro = novoNo;
            ultimo = novoNo;
        }
        else
        {
            ultimo.Proximo = novoNo;
            novoNo.Anterior = ultimo;
            ultimo = novoNo;
        }
        tamanho++;
    }

    // Adiciona em um índice específico.
    public void AdicionarEm(int indice, T item)
    {
        if (indice < 0 || indice > tamanho)
        {
            throw new IndexOutOfRangeException("Índice inválido para inserção.");
        }

        // Se for no final, reaproveita o método Adicionar
        if (indice == tamanho)
        {
            Adicionar(item);
            return;
        }

        No novoNo = new No(item);
        if (indice == 0) // Inserção no começo
        {
            novoNo.Proximo = primeiro;
            primeiro.Anterior = novoNo;
            primeiro = novoNo;
        }
        else // Inserção no meio
        {
            No noAtual = ObterNoEm(indice);
            No noAnterior = noAtual.Anterior;

            novoNo.Proximo = noAtual;
            novoNo.Anterior = noAnterior;
            noAnterior.Proximo = novoNo;
            noAtual.Anterior = novoNo;
        }
        tamanho++;
    }

    // Remove de um índice específico.
    public T RemoverEm(int indice)
    {
        if (indice < 0 || indice >= tamanho)
        {
            throw new IndexOutOfRangeException("Índice inválido para remoção.");
        }

        No noParaRemover;
        if (tamanho == 1) // Removendo o único elemento
        {
            noParaRemover = primeiro;
            primeiro = null;
            ultimo = null;
        }
        else if (indice == 0) // Removendo o primeiro
        {
            noParaRemover = primeiro;
            primeiro = primeiro.Proximo;
            primeiro.Anterior = null;
        }
        else if (indice == tamanho - 1) // Removendo o último
        {
            noParaRemover = ultimo;
            ultimo = ultimo.Anterior;
            ultimo.Proximo = null;
        }
        else // Removendo do meio
        {
            noParaRemover = ObterNoEm(indice);
            noParaRemover.Anterior.Proximo = noParaRemover.Proximo;
            noParaRemover.Proximo.Anterior = noParaRemover.Anterior;
        }

        tamanho--;
        return noParaRemover.Valor;
    }

    // Obtém o valor em um índice.
    public T Obter(int indice)
    {
        return ObterNoEm(indice).Valor;
    }

    // Verifica se contém o item.
    public bool Contem(T item)
    {
        return IndiceDe(item) != -1;
    }

    // Retorna o índice de um item.
    public int IndiceDe(T item)
    {
        No atual = primeiro;
        for (int i = 0; i < tamanho; i++)
        {
            if (atual.Valor.Equals(item))
            {
                return i;
            }
            atual = atual.Proximo;
        }
        return -1;
    }

    // Método privado para buscar um nó pelo índice.
    // Otimizado: busca do início ou do fim, dependendo do que for mais perto.
    private No ObterNoEm(int indice)
    {
        if (indice < 0 || indice >= tamanho)
        {
            throw new IndexOutOfRangeException("Índice fora do intervalo do vetor.");
        }

        No atual;
        if (indice < tamanho / 2) // Se está na primeira metade, começa do início
        {
            atual = primeiro;
            for (int i = 0; i < indice; i++)
            {
                atual = atual.Proximo;
            }
        }
        else // Se está na segunda metade, começa do fim
        {
            atual = ultimo;
            for (int i = tamanho - 1; i > indice; i--)
            {
                atual = atual.Anterior;
            }
        }
        return atual;
    }
    
    // Método auxiliar para facilitar a visualização nos testes.
    public override string ToString()
    {
        if(EstaVazio) return "[]";
        
        No atual = primeiro;
        string s = "[";
        while(atual.Proximo != null)
        {
            s += $"{atual.Valor}, ";
            atual = atual.Proximo;
        }
        s += $"{atual.Valor}]";
        return s;
    }
}