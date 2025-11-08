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
        Inicio.SetProximo(Final);
        Final.SetAnterior(Inicio);
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
        //ve se isso ai ta certo, ne mulher
        Console.Write("[");
        No? atual = Inicio.GetProximo();
        while (atual != Final)
        {
            Console.Write(atual.GetElemento());
            if (atual.GetProximo() != Final)
            {
                Console.Write(", ");
            }
            atual = atual.GetProximo();
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
        return Inicio.GetProximo();
    }

    public No? last()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("Sequência vazia, more.");
        }
        return Final.GetAnterior();
    }

    public No? before(No n)
    {
        if (n == Inicio.GetProximo())
        {
            throw new InvalidOperationException("Não há nó antes do primeiro, more.");
        }
        return n.GetAnterior();
    }

    public No? after(No n)
    {
        if (n == Final.GetAnterior())
        {
            throw new InvalidOperationException("Não há nó depois do último, more.");
        }
        return n.GetProximo();
    }

    public void insertFirst(object o)
    {
        No novoNo = new No(o);
        No antigoPrimeiro = Inicio.GetProximo();

        novoNo.SetProximo(antigoPrimeiro);
        novoNo.SetAnterior(Inicio);
        antigoPrimeiro.SetAnterior(novoNo);
        Inicio.SetProximo(novoNo);
        size++;
    }

    public void insertLast(object o)
    {
        No novoNo = new No(o);
        No antigoUltimo = Final.GetAnterior();

        novoNo.SetAnterior(antigoUltimo);
        novoNo.SetProximo(Final);
        antigoUltimo.SetProximo(novoNo);
        Final.SetAnterior(novoNo);
        size++;
    }

    public void insertBefore(No n, object o)
    {
        No noDeTras = n.GetAnterior();
        No novoNo = new No(o);

        novoNo.SetProximo(n);
        novoNo.SetAnterior(noDeTras);
        noDeTras.SetProximo(novoNo);
        n.SetAnterior(novoNo);
        size++;
    }

    public void insertAfter(No n, object o)
    {
        No noDaFrente = n.GetProximo();
        No novoNo = new No(o);

        novoNo.SetProximo(noDaFrente);
        novoNo.SetAnterior(n);
        n.SetProximo(novoNo);
        noDaFrente.SetAnterior(novoNo);
        size++;
    }

    public object Remove(No n)
    {
        No anterior = n.GetAnterior();
        No proximo = n.GetProximo();

        anterior.SetProximo(proximo);
        proximo.SetAnterior(anterior);
        size--;
        return n.GetElemento();
    }

    public object replaceElement(No n, object o)
    {
        object antigo = n.GetElemento();
        n.SetElemento(o);
        return antigo;
    }

    public void swapElements(No n, No q)
    {
        object temp = n.GetElemento();
        n.SetElemento(q.GetElemento());
        q.SetElemento(temp);
    }
    
    public object elemAtRank(int r)
    {
        No no = atRank(r);
        return no.GetElemento();
    }
    
    public object replaceAtRank(int r, object o)
    {
        No noParaTrocar = atRank(r);
        object antigoElemento = noParaTrocar.GetElemento();
        noParaTrocar.SetElemento(o);
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
            atual = Inicio.GetProximo();
            for (int i = 0; i < r; i++)
            {
                atual = atual.GetProximo();
            }
        }
        else
        {
            atual = Final.GetAnterior();
            for (int i = size - 1; i > r; i--)
            {
                atual = atual.GetAnterior();
            }
        }
        return atual;
    }

    public int rankOf(No n)
    {
        No atual = Inicio.GetProximo();
        int r = 0;
        while (atual != n && atual != Final)
        {
            atual = atual.GetProximo();
            r++;
        }
        
        if (atual == Final)
        {
            throw new InvalidOperationException("Nó não encontrado na sequência, more.");
        }
        return r;
    }
}