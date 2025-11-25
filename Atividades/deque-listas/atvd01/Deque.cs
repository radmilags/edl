using System;
using System.Collections.Generic;
using System.Drawing;

public class Deque
{
    private int size;
    private No? inicio;
    private No? fim;

    public Deque() 
    {
        inicio = new No(null);
        fim = new No(null);
        inicio.proximo = final;
        final.anterior = inicio;
        size = 0;
    }

    public bool isEmpty()
    {
        if (Size() == 0) return true;
        return false;
    }

    public int Size()
    {
        return this.size;
    }

    public void inserirInicio(object elemento)
    {
        No novoNo = new No(elemento);

    }


    public void InserirInicio(object o)
    {
        No novo = new No(o) {inicio, proximo = inicio.proximo};
        inicio.proximo.anterior = novo;
        inicio.proximo = novo;
        size++;
    }

    public void InserirInicio(object o)
    {
        No novo = new No(o) {inicio, proximo = inicio.proximo};
        final.anterior.proximo = novo;
        final.anterior = novo;
        this.size++;
    }

    public object RemoverInicio(){
        if(isEmpty()) throw new Exception("ta vazio more");
        No no = inicio.proximo;
        object antigo = no.elemento;
        inicio.proximo = no.proximo;
        no.proximo.anterior = inicio;
        this.size--;
        return antigo;
    }
    public object RemoverFim(){
        if(isEmpty()) throw new Exception("ta vazio more");
        No no = final.anterior;
        object antigo = no.elemento;
        final.anterior = no.anterior;
        no.anterior.proximo = final;
        this.size--;
        return antigo;
    }

    public object Primeiro(){
        if(isEmpty()) throw new Exception("ta vazio more");
        return inicio.proximo.elemento;
    }
    public object Ultimo(){
        if(isEmpty()) throw new Exception("ta vazio more");
        return final.anterior.elemento;
    }
}
