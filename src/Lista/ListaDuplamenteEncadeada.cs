using System;
using System.Text; // StringBuilder

public class ListaDuplamenteEncadeada<T> : ILista<T>
{
    private class No
    {
        public T Valor { get; set; }
        public No Proximo { get; set; }
        public No Anterior { get; set; }

        public No(T valor)
        {
            Valor = valor;
        }
    }

    private No _inicio;
    private No _fim;
    private int _tamanho;

    public ListaDuplamenteEncadeada()
    {
        _inicio = null;
        _fim = null;
        _tamanho = 0;
    }

    public int Tamanho() => _tamanho;
    
    public bool EstaVazia() => _tamanho == 0;
    
    private void ValidarIndice(int indice, bool paraAdicionar = false)
    {
        int limiteSuperior = paraAdicionar ? _tamanho : _tamanho - 1;
        if (indice < 0 || indice > limiteSuperior)
        {
            throw new IndexOutOfRangeException($"Índice {indice} está fora do intervalo válido [0, {limiteSuperior}].");
        }
    }
    
    private No ObterNo(int indice)
    {
        ValidarIndice(indice);
        No atual = _inicio;
        for (int i = 0; i < indice; i++)
        {
            atual = atual.Proximo;
        }
        return atual;
    }

    public void Adicionar(T elemento)
    {
        No novoNo = new No(elemento);
        if (EstaVazia())
        {
            _inicio = novoNo;
            _fim = novoNo;
        }
        else
        {
            _fim.Proximo = novoNo;
            novoNo.Anterior = _fim;
            _fim = novoNo;
        }
        _tamanho++;
    }

    public void AdicionarNoInicio(T elemento)
    {
        No novoNo = new No(elemento);
        if (EstaVazia())
        {
            _inicio = novoNo;
            _fim = novoNo;
        }
        else
        {
            novoNo.Proximo = _inicio;
            _inicio.Anterior = novoNo;
            _inicio = novoNo;
        }
        _tamanho++;
    }

    public void AdicionarNaPosicao(int indice, T elemento)
    {
        ValidarIndice(indice, paraAdicionar: true);
        if (indice == 0) { AdicionarNoInicio(elemento); return; }
        if (indice == _tamanho) { Adicionar(elemento); return; }

        No noAtual = ObterNo(indice);
        No noAnterior = noAtual.Anterior;
        No novoNo = new No(elemento);

        novoNo.Proximo = noAtual;
        novoNo.Anterior = noAnterior;
        noAnterior.Proximo = novoNo;
        noAtual.Anterior = novoNo;
        _tamanho++;
    }
    
    public T RemoverDoFim()
    {
        if (EstaVazia()) throw new InvalidOperationException("A lista está vazia.");
        T valorRemovido = _fim.Valor;
        if (_tamanho == 1) { Limpar(); }
        else
        {
            _fim = _fim.Anterior;
            _fim.Proximo = null;
            _tamanho--;
        }
        return valorRemovido;
    }

    public T RemoverDoInicio()
    {
        if (EstaVazia()) throw new InvalidOperationException("A lista está vazia.");
        T valorRemovido = _inicio.Valor;
        if (_tamanho == 1) { Limpar(); }
        else
        {
            _inicio = _inicio.Proximo;
            _inicio.Anterior = null;
            _tamanho--;
        }
        return valorRemovido;
    }

    public T RemoverDaPosicao(int indice)
    {
        ValidarIndice(indice);
        if (indice == 0) return RemoverDoInicio();
        if (indice == _tamanho - 1) return RemoverDoFim();

        No noParaRemover = ObterNo(indice);
        noParaRemover.Anterior.Proximo = noParaRemover.Proximo;
        noParaRemover.Proximo.Anterior = noParaRemover.Anterior;
        _tamanho--;
        return noParaRemover.Valor;
    }
    
    public T Obter(int indice)
    {
        return ObterNo(indice).Valor;
    }
    
    public int IndiceDe(T elemento)
    {
        No atual = _inicio;
        int indiceAtual = 0;
        while (atual != null)
        {
            if (Equals(atual.Valor, elemento)) return indiceAtual;
            atual = atual.Proximo;
            indiceAtual++;
        }
        return -1;
    }
    
    public bool Contem(T elemento)
    {
        return IndiceDe(elemento) != -1;
    }
    
    public void Limpar()
    {
        _inicio = null;
        _fim = null;
        _tamanho = 0;
    }

    public override string ToString()
    {
        if (EstaVazia())
        {
            return "Lista vazia.";
        }

        var sb = new StringBuilder();
        sb.Append($"Lista (tamanho: {_tamanho}): [ ");
        No atual = _inicio;
        while (atual != null)
        {
            sb.Append(atual.Valor);
            if (atual.Proximo != null)
            {
                sb.Append(", ");
            }
            atual = atual.Proximo;
        }
        sb.Append(" ]");
        return sb.ToString();
    }
}