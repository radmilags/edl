using System;

public class ABPArray
{
    private int[] chaves;
    private object[] elementos;
    private int capacidade;
    private int tamanho;

    public ABPArray(int capacidadeInicial)
    {
        this.capacidade = capacidadeInicial;
        this.chaves = new int[this.capacidade]; 
        this.elementos = new object[this.capacidade];
        this.tamanho = 0;
    }

    public int size()
    {
        return this.tamanho;
    }

    public bool isEmpty()
    {
        return this.tamanho == 0;
    }
    
    private int getIndiceEsquerda(int indice)
    {
        return 2 * indice + 1;
    }

    private int getIndiceDireita(int indice)
    {
        return 2 * indice + 2;
    }

    private void duplicarCapacidade()
    {
        int novoTam = this.capacidade * 2;
        int[] novasChaves = new int[novoTam];
        object[] novosElementos = new object[novoTam];

        for (int i = 0; i < this.capacidade; i++)
        {
            nevasChaves[i] = this.chaves[i];
            novosElementos[i] = this.elementos[i];
        }

        this.chaves = novasChaves;
        this.elementos = novosElementos;
        this.capacidade = novoTam;
    }

    public void Insert(int chave, object elemento)
    {
        if (isEmpty())
        {
            if (this.tamanho >= this.capacidade) duplicarCapacidade();
            this.chaves[0] = chave;
            this.elementos[0] = elemento;
            this.tamanho = 1;
            return;
        }

        int indiceAtual = 0;
        
        while (indiceAtual < this.capacidade && this.elementos[indiceAtual] != null)
        {
            if (chave == this.chaves[indiceAtual])
            {
                this.elementos[indiceAtual] = elemento;
                return;
            }
            else if (chave < this.chaves[indiceAtual])
            {
                indiceAtual = getIndiceEsquerda(indiceAtual);
            }
            else
            {
                indiceAtual = getIndiceDireita(indiceAtual);
            }
        }
        
        if (indiceAtual >= this.capacidade)
        {
            duplicarCapacidade();
        }
        
        if (indiceAtual < this.capacidade)
        {
            this.chaves[indiceAtual] = chave;
            this.elementos[indiceAtual] = elemento;
            this.tamanho++;
        }
    }

    public int Find(int chave)
    {
        int indiceAtual = 0;
        
        while (indiceAtual < this.capacidade && this.elementos[indiceAtual] != null)
        {
            if (chave == this.chaves[indiceAtual])
            {
                return indiceAtual;
            }
            else if (chave < this.chaves[indiceAtual])
            {
                indiceAtual = getIndiceEsquerda(indiceAtual);
            }
            else
            {
                indiceAtual = getIndiceDireita(indiceAtual);
            }
        }
        return -1;
    }

    public void Remove(int chave)
    {
        int indice = Find(chave);
        if (indice == -1) return;

        int indiceEsquerda = getIndiceEsquerda(indice);
        int indiceDireita = getIndiceDireita(indice);

        bool temFilhoEsquerda = indiceEsquerda < this.capacidade && this.elementos[indiceEsquerda] != null;
        bool temFilhoDireita = indiceDireita < this.capacidade && this.elementos[indiceDireita] != null;

        if (!temFilhoEsquerda && !temFilhoDireita)
        {
            this.elementos[indice] = null;
            this.tamanho--;
        }
        else if (!temFilhoDireita)
        {
            substituirComFilho(indice, indiceEsquerda);
            this.tamanho--;
        }
        else if (!temFilhoEsquerda)
        {
            substituirComFilho(indice, indiceDireita);
            this.tamanho--;
        }
        else
        {
            int indiceSucessor = encontrarIndiceMinimo(indiceDireita);
            this.chaves[indice] = this.chaves[indiceSucessor];
            this.elementos[indice] = this.elementos[indiceSucessor];

            removerSucessor(indiceSucessor);
            this.tamanho--;
        }
    }

    private void substituirComFilho(int indicePai, int indiceFilho)
    {
        this.chaves[indicePai] = this.chaves[indiceFilho];
        this.elementos[indicePai] = this.elementos[indiceFilho];
        this.chaves[indiceFilho] = 0;
        this.elementos[indiceFilho] = null;
    }

    private void removerSucessor(int indiceSucessor)
    {
        int indiceEsquerda = getIndiceEsquerda(indiceSucessor);
        int indiceDireita = getIndiceDireita(indiceSucessor);
        int indiceFilho = -1;

        if (indiceEsquerda < this.capacidade && this.elementos[indiceEsquerda] != null)
        {
            indiceFilho = indiceEsquerda;
        }
        else if (indiceDireita < this.capacidade && this.elementos[indiceDireita] != null)
        {
            indiceFilho = indiceDireita;
        }

        if (indiceFilho != -1)
        {
            this.chaves[indiceSucessor] = this.chaves[indiceFilho];
            this.elementos[indiceSucessor] = this.elementos[indiceFilho];
            this.chaves[indiceFilho] = 0;
            this.elementos[indiceFilho] = null;
        }
        else
        {
            this.chaves[indiceSucessor] = 0;
            this.elementos[indiceSucessor] = null;
        }
    }

    private int encontrarIndiceMinimo(int indice)
    {
        while (getIndiceEsquerda(indice) < this.capacidade && this.elementos[getIndiceEsquerda(indice)] != null)
        {
            indice = getIndiceEsquerda(indice);
        }
        return indice;
    }
    
    public void InOrder(int indice)
    {
        if (indice >= this.capacidade || this.elementos[indice] == null)
            return;

        InOrder(getIndiceEsquerda(indice));
        
        Console.Write(this.chaves[indice] + " ");
        
        InOrder(getIndiceDireita(indice));
    }
    
    public void PrintaArvore()
    {
        for (int i = 0; i < this.capacidade; i++)
        {
            if (this.elementos[i] != null)
            {
                Console.WriteLine("Index " + i + ": Chave " + this.chaves[i]);
            }
        }
    }
}
