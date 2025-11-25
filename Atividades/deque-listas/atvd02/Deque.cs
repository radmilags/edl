using System;
public class Deque
{
    private int size;
    private No? inicio; 
    private No? final;  

    public Deque() 
    {
        inicio = null;
        final = null;
        size = 0;
    }

    public bool isEmpty()
    {
        return size == 0;
    }

    public int Size()
    {
        return this.size;
    }

    public void InserirInicio(object o)
    {
        No novo = new No(o);
        
        if (isEmpty())
        {
            inicio = novo;
            final = novo; 
        }
        else
        {
            novo.proximo = inicio;
            inicio = novo;
        }
        
        size++;
    }

    public void InserirFinal(object o)
    {
        No novo = new No(o);

        if (isEmpty())
        {
            inicio = novo;
            final = novo;
        }
        else
        {
            final.proximo = novo; 
            final = novo;
        }
        
        this.size++;
    }

    public object RemoverInicio()
    {
        if(isEmpty()) throw new Exception("ta vazio more");
        
        object antigo = inicio.elemento;
        inicio = inicio.proximo;

        size--;

        if (size == 0)
        {
            final = null;
        }

        return antigo;
    }
    public object RemoverFim()
    {
        if(isEmpty()) throw new Exception("ta vazio more");

        object antigo = final.elemento;

        if (inicio == final)
        {
            inicio = null;
            final = null;
        }
        else
        {
            No atual = inicio;
            while (atual.proximo != final)
            {
                atual = atual.proximo;
            }

            final = atual;
            final.proximo = null;
        }

        this.size--;
        return antigo;
    }

    public object Primeiro()
    {
        if(isEmpty()) throw new Exception("ta vazio more");
        return inicio.elemento;
    }

    public object Ultimo()
    {
        if(isEmpty()) throw new Exception("ta vazio more");
        return final.elemento;
    }
}