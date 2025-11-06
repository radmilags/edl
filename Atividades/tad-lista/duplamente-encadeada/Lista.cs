public class Lista
{

    private No Inicio;
    private No Final;
    private int size;

    public Lista()
    {
        this.Inicio = new No(null); //utilizando o no sentinela
        this.Final = new No(null); //utilizando o no sentinela - ver melhor como funciona isso ai

        this.Inicio.Proximo = this.Final;
        this.Final.Anterior = this.Inicio;

        this.size = 0;
    }

    public bool isEmpty()
    {
        if (size == 0) return true;
        return false;
    }

    public bool isFirst(object o)
    {
        if (First() == o) return true;
        return false;
    }

    public bool isLast(object o)
    {
        if (Last() == o) return true;
        return false;
    }

    public bool isFirst(object elemento)
    {
        if (isEmpty()) return false;
        if (First() == elemento) return true;
        return false;
    }

    public bool isLast(object elemento)
    {
        if (isEmpty()) return false; // Se ta não pode ser o último
        if (Last() == elemento) return true;
        return false;
    }

    public void insertLast(object elemento)
    {
        No novoNo = new No(elemento);
        No antigoUltimo = Final.Anterior;
        novoNo.Anterior = antigoUltimo;
        novoNo.Proximo = Final;
        antigoUltimo.Proximo = novoNo;
        Final.Anterior = novoNo;
        size++;

    }

    public void insertFirst(object elemento)
    {
        //refazer esses métodos no papel pois sao muito confusos
        No novoNo = new No(elemento);
        No antigoPrimeiro = Inicio.Proximo;
        novoNo.Proximo = antigoPrimeiro;
        antigoPrimeiro.Anterior = novoNo;
        novoNo.Anterior = Inicio;
        Inicio.Proximo = novoNo;

        size++;
    }
    
    public object RemoveFirst()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("A lista está vazia, more.");
        }

        No noParaRemover = this.Inicio.Proximo;
        No proximoNo = noParaRemover.Proximo;

        Inicio.Proximo = proximoNo;
        proximoNo.Anterior = Inicio;
        size--;
        return noParaRemover.Elemento;
    }

    public object RemoveLast()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("A lista está vazia, more.");
        }

        No noParaRemover = Final.Anterior;
        No anteriorNo = noParaRemover.Anterior;
        anteriorNo.Proximo = Final;
        Final.Anterior = anteriorNo;
        size--;

        return noParaRemover.Elemento;
    }
    private No GetNo(int posicao)
    {
        if (posicao < 0 || posicao >= this.size)
        {
            throw new IndexOutOfRangeException("Posição inválida, more.");
        }

        if (posicao < size / 2)
        {
            No atual = Inicio.Proximo;
            for (int i = 0; i < posicao; i++)
            {
                atual = atual.Proximo;
            }
            return atual;
        }
        else
        {
            No atual = Final.Anterior;
            for (int i = size - 1; i > posicao; i--)
            {
                atual = atual.Anterior;
            }
            return atual;
        }
    }

    public object Remove(int posicao)
    {
        No noParaRemover = GetNo(posicao);
        No anterior = noParaRemover.Anterior;
        No proximo = noParaRemover.Proximo;
        anterior.Proximo = proximo;
        proximo.Anterior = anterior;

        size--;
        return noParaRemover.Elemento;
    }

    public void ReplaceElement(int posicao, object elemento)
    {
        No noParaTrocar = GetNo(posicao);
        noParaTrocar.Elemento = elemento;
    }

    public void insertBefore(int posicao, object elemento)
    {
        if (posicao == 0)
        {
            insertFirst(elemento);
            return;
        }

        if (posicao == this.size)
        {
            insertLast(elemento);
            return;
        }

        No noDaFrente = GetNo(posicao);
        No noDeTras = noDaFrente.Anterior;
        No novoNo = new No(elemento);
        
        novoNo.Proximo = noDaFrente;
        novoNo.Anterior = noDeTras;

        noDeTras.Proximo = novoNo;
        noDaFrente.Anterior = novoNo;

        this.size++;
    }

    public void insertAfter(int posicao, object elemento)
    {
        if (posicao == size - 1)
        {
            insertLast(elemento);
            return;
        }

        No noAtual = GetNo(posicao);
        No noDaFrente = noAtual.Proximo;
        No novoNo = new No(elemento);

        novoNo.Proximo = noDaFrente;
        novoNo.Anterior = noAtual;

        noAtual.Proximo = novoNo;
        noDaFrente.Anterior = novoNo;

        size++;
    }

    
}