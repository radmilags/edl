using System;

public class No
{
    public int elemento;
    public No parent;
    public No esquerdo;
    public No direito;

    public No(int elem, No noParent)
    {
        elemento = elem;
        parent = noParent;
        esquerdo = null;
        direito = null;
    }
}

public class ArvBin
{
    private No raiz;
    private int contadorNos;
    
    public ArvBin() { raiz = null; contadorNos = 0; }
    public No root() { return raiz; }
    public int size() { return contadorNos; }

    public void Insert(int elem) { raiz = InsertRecursivo(raiz, null, elem); }
    private No InsertRecursivo(No noAtual, No noParent, int elem)
    {
        if (noAtual == null) { contadorNos++; return new No(elem, noParent); }
        if (elem < noAtual.elemento) { noAtual.esquerdo = InsertRecursivo(noAtual.esquerdo, noAtual, elem); }
        else if (elem > noAtual.elemento) { noAtual.direito = InsertRecursivo(noAtual.direito, noAtual, elem); }
        return noAtual;
    }

    // --- MÉTODO DE BUSCA NECESSÁRIO ---
    public bool Search(int elem)
    {
        return SearchRecursivo(raiz, elem);
    }
    private bool SearchRecursivo(No noAtual, int elem)
    {
        if (noAtual == null) return false;
        if (elem == noAtual.elemento) return true;
        if (elem < noAtual.elemento) return SearchRecursivo(noAtual.esquerdo, elem);
        else return SearchRecursivo(noAtual.direito, elem);
    }
}

// --- CLASSE COM A SOLUÇÃO SIMPLIFICADA ---
public class SolucaoProva
{
    public ArvBin intersecaoArv(ArvBin A, ArvBin B)
    {
        ArvBin C = new ArvBin();
        PercorrerEVerificar(A.root(), B, C);
        return C;
    }

    private void PercorrerEVerificar(No noA, ArvBin B, ArvBin C)
    {
        if (noA != null)
        {
            if (B.Search(noA.elemento))
            {
                C.Insert(noA.elemento);
            }
            PercorrerEVerificar(noA.esquerdo, B, C);
            PercorrerEVerificar(noA.direito, B, C);
        }
    }
}