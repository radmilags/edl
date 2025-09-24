using System;
using System.Collections.Generic;
public class Pilha_Encadeada
{
    private No? topo; 
    private int capacidade;
    private int tamanho = 0;
    private object[] arrayPilha;

    public Pilha_Encadeada(int capacidade)
    {
        this.capacidade = capacidade;
        arrayPilha = new object[capacidade];

    }

    public void Push(object elemento)
    {
        if (tamanho < capacidade)
        {
            No novoNo = new No(elemento);
            novoNo.proximo = topo;
            topo = novoNo;
            arrayPilha[tamanho] = elemento;
            tamanho++;
        }
        else
        {


        }
    }

    public void DobraArray()
    {

    }
}