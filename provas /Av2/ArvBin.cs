class ArvBin{
    public ArvBin(){

    }
}
using System;

// --- Estrutura Básica da Árvore Binária de Pesquisa (BST) ---
public class No
{
    public int elemento;
    public No pai;
    public No esquerdo;
    public No direito;

    public No(int elem, No noPai)
    {
        elemento = elem;
        pai = noPai;
        esquerdo = null;
        direito = null;
    }
}

public class ArvBin
{
    private No raiz;
    private int contadorNos;

    public ArvBin()
    {
        raiz = null;
        contadorNos = 0;
    }

    // Método de acesso, conforme nomenclatura do professor
    public No root()
    {
        return raiz;
    }

    // Método genérico, conforme nomenclatura do professor
    public int size()
    {
        return contadorNos;
    }

    // Método de atualização para construir a árvore
    public void Insert(int elem)
    {
        raiz = InsertRecursivo(raiz, null, elem);
    }

    private No InsertRecursivo(No noAtual, No noPai, int elem)
    {
        if (noAtual == null)
        {
            contadorNos++;
            return new No(elem, noPai);
        }

        if (elem < noAtual.elemento)
        {
            noAtual.esquerdo = InsertRecursivo(noAtual.esquerdo, noAtual, elem);
        }
        else if (elem > noAtual.elemento)
        {
            noAtual.direito = InsertRecursivo(noAtual.direito, noAtual, elem);
        }
        
        return noAtual;
    }
}

// --- CLASSE COM O MÉTODO DA PROVA ---
public class SolucaoProva
{
    private int ContarNos(No no)
    {
        if (no == null) return 0;
        return 1 + ContarNos(no.esquerdo) + ContarNos(no.direito);
    }

    private void PreencherArrayEmOrdem(No no, int[] array, ref int indice)
    {
        if (no == null) return;
        
        PreencherArrayEmOrdem(no.esquerdo, array, ref indice);
        array[indice] = no.elemento;
        indice++;
        PreencherArrayEmOrdem(no.direito, array, ref indice);
    }

    public ArvBin intersecaoArv(ArvBin A, ArvBin B)
    {
        
}
