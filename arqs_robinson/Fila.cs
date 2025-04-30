public class No
{
    public object Dado { get; set; }
    public No Proximo { get; set; }

    public No(object dado)
    {
        Dado = dado;
        Proximo = null;
    }
}

public class Fila : IFila
{
    private No inicio;
    private No fim;
    private int tamanho;

    public Fila(int capacidadeInicial, int modoCrescimento)
    {
        inicio = null;
        fim = null;
        tamanho = 0;
    }

    public void Enqueue(object o)
    {
        No novoNo = new No(o);
        if (IsEmpty())
        {
            inicio = fim = novoNo;
        }
        else
        {
            fim.Proximo = novoNo;
            fim = novoNo;
        }
        tamanho++;
    }

    public object Dequeue()
    {
        if (IsEmpty())
        {
            throw new FilaVaziaException("Fila vazia.");
        }

        object dado = inicio.Dado;
        inicio = inicio.Proximo;
        tamanho--;

        if (inicio == null)
            fim = null;

        return dado;
    }

    public object First()
    {
        if (IsEmpty())
        {
            throw new FilaVaziaException("Fila vazia.");
        }
        return inicio.Dado;
    }

    public int Size()
    {
        return tamanho;
    }

    public bool IsEmpty()
    {
        return tamanho == 0;
    }
}
