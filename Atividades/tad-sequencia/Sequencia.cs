using System;

public class Sequencia
{
    private No? Inicio;
    private No? Final;
    private int size;

    public Sequencia()
    {
        Inicio = new No(null);
        Final = new No(null);
        Inicio.Proximo = Final;
        Final.Anterior = Inicio;
        size = 0;
    }

    public int Size()
    {
        return size;
    }

    public bool isEmpty()
    {
        if (size == 0) return true;
        return false;
    }
    
    public void PrintaSequencia()
    {
        //ve ai esse metodo
        
        Console.Write("[");
        No? atual = Inicio.Proximo;
        while (atual != Final)
        {
            Console.Write(atual.Elemento);
            if (atual.Proximo != Final)
            {
                Console.Write(", ");
            }
            atual = atual.Proximo;
        }
        Console.Write("]");
        Console.WriteLine();
    }

    public No? first()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("Sequência vazia, more.");
        }
        return Inicio.Proximo;
    }

    public No? last()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("Sequência vazia, more.");
        }
        return Final.Anterior;
    }

    public No? before(No n)
    {
        if (n == Inicio.Proximo)
        {
             throw new InvalidOperationException("Não há nó antes do primeiro, more.");
        }
        return n.Anterior;
    }

    public No? after(No n)
    {
        if (n == Final.Anterior)
        {
             throw new InvalidOperationException("Não há nó depois do último, more.");
        }
        return n.Proximo;
    }

    public void insertFirst(object o)
    {
        No novoNo = new No(o);
        No antigoPrimeiro = Inicio.Proximo;

        novoNo.Proximo = antigoPrimeiro;
        novoNo.Anterior = Inicio;
        antigoPrimeiro.Anterior = novoNo;
        Inicio.Proximo = novoNo;
        size++;
    }

    public void insertLast(object o)
    {
        No novoNo = new No(o);
        No antigoUltimo = Final.Anterior;

        novoNo.Anterior = antigoUltimo;
        novoNo.Proximo = Final;
        antigoUltimo.Proximo = novoNo;
        Final.Anterior = novoNo;
        size++;
    }

    public void insertBefore(No n, object o)
    {
        No noDeTras = n.Anterior;
        No novoNo = new No(o);

        novoNo.Proximo = n;
        novoNo.Anterior = noDeTras;
        noDeTras.Proximo = novoNo;
        n.Anterior = novoNo;
        size++;
    }

    public void insertAfter(No n, object o)
    {
        No noDaFrente = n.Proximo;
        No novoNo = new No(o);

        novoNo.Proximo = noDaFrente;
        novoNo.Anterior = n;
        n.Proximo = novoNo;
        noDaFrente.Anterior = novoNo;
        size++;
    }

    public object remove(No n)
    {
        No anterior = n.Anterior;
        No proximo = n.Proximo;

        anterior.Proximo = proximo;
        proximo.Anterior = anterior;
        size--;
        return n.Elemento;
    }

    public object replaceElement(No n, object o)
    {
        object antigo = n.Elemento;
        n.Elemento = o;
        return antigo;
    }

    public void swapElements(No n, No q)
    {
        object temp = n.Elemento;
        n.Elemento = q.Elemento;
        q.Elemento = temp;
    }
    
    public object elemAtRank(int r)
    {
        No no = atRank(r);
        return no.Elemento;
    }
    
    public object replaceAtRank(int r, object o)
    {
        No noParaTrocar = atRank(r);
        object antigoElemento = noParaTrocar.Elemento;
        noParaTrocar.Elemento = o;
        return antigoElemento;
    }

    public void insertAtRank(int r, object o)
    {
        if (r == 0)
        {
            insertFirst(o);
            return;
        }
        if (r == size)
        {
            insertLast(o);
            return;
        }

        No noDaFrente = atRank(r);
        insertBefore(noDaFrente, o);
    }

    public object removeAtRank(int r)
    {
        No noParaRemover = atRank(r);
        return remove(noParaRemover);
    }
    
    public No atRank(int r)
    {
        if (r < 0 || r >= size)
        {
            throw new IndexOutOfRangeException("Rank inválido, more.");
        }

        No atual;
        if (r < size / 2)
        {
            atual = Inicio.Proximo;
            for (int i = 0; i < r; i++)
            {
                atual = atual.Proximo;
            }
        }
        else
        {
            atual = Final.Anterior;
            for (int i = size - 1; i > r; i--)
            {
                atual = atual.Anterior;
            }
        }
        return atual;
    }

    public int rankOf(No n)
    {
        No atual = Inicio.Proximo;
        int r = 0;
        while (atual != n && atual != Final)
        {
            atual = atual.Proximo;
            r++;
        }
        
        if (atual == Final)
        {
            throw new InvalidOperationException("Nó não encontrado na sequência, more.");
        }
        return r;
    }
}