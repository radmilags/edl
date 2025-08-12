using System;
using System.Collections.Generic;

public class No
{
    public int Valor { get; set; }
    public No Pai { get; set; }
    public No Esquerdo { get; set; }
    public No Direito { get; set; }

    public No(int valor)
    {
        this.Valor = valor;
    }
}

public class FilaPrioridadeHeapNos
{
    private No raiz;
    private int tamanho;

    public FilaPrioridadeHeapNos()
    {
        this.raiz = null;
        this.tamanho = 0;
    }
    
    private void TrocaValores(No no1, No no2)
    {
        int temp = no1.Valor;
        no1.Valor = no2.Valor;
        no2.Valor = temp;
    }

    private void SobeHeap(No no)
    {
        if (no.Pai != null && no.Valor < no.Pai.Valor)
        {
            TrocaValores(no, no.Pai);
            SobeHeap(no.Pai);
        }
    }

    private void DesceHeap(No no)
    {
        No menor = no;
        if (no.Esquerdo != null && no.Esquerdo.Valor < menor.Valor)
            menor = no.Esquerdo;
        
        if (no.Direito != null && no.Direito.Valor < menor.Valor)
            menor = no.Direito;
        
        if (menor != no)
        {
            TrocaValores(no, menor);
            DesceHeap(menor);
        }
    }

    public void Insert(int valor)
    {
        No novoNo = new No(valor);
        tamanho++;
        if (raiz == null)
        {
            raiz = novoNo;
            return;
        }

        Queue<No> filaAuxiliar = new Queue<No>();
        filaAuxiliar.Enqueue(raiz);

        while (true)
        {
            No atual = filaAuxiliar.Dequeue();
            if (atual.Esquerdo == null)
            {
                atual.Esquerdo = novoNo;
                novoNo.Pai = atual;
                break;
            }
            else
            {
                filaAuxiliar.Enqueue(atual.Esquerdo);
            }

            if (atual.Direito == null)
            {
                atual.Direito = novoNo;
                novoNo.Pai = atual;
                break;
            }
            else
            {
                filaAuxiliar.Enqueue(atual.Direito);
            }
        }
        SobeHeap(novoNo);
    }

    public int RemoveMin()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Fila vazia.");
        
        int valorMinimo = raiz.Valor;
        if (tamanho == 1)
        {
            raiz = null;
            tamanho--;
            return valorMinimo;
        }

        Queue<No> filaAuxiliar = new Queue<No>();
        filaAuxiliar.Enqueue(raiz);
        No ultimoNo = null;

        while (filaAuxiliar.Count > 0)
        {
            ultimoNo = filaAuxiliar.Dequeue();
            if (ultimoNo.Esquerdo != null)
                filaAuxiliar.Enqueue(ultimoNo.Esquerdo);
            if (ultimoNo.Direito != null)
                filaAuxiliar.Enqueue(ultimoNo.Direito);
        }

        raiz.Valor = ultimoNo.Valor;
        if (ultimoNo.Pai.Direito == ultimoNo)
            ultimoNo.Pai.Direito = null;
        else
            ultimoNo.Pai.Esquerdo = null;

        tamanho--;
        DesceHeap(raiz);
        return valorMinimo;
    }

    public int Min()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Fila vazia.");
        return raiz.Valor;
    }
    
    public int Size() => tamanho;
    public bool IsEmpty() => tamanho == 0;
}