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
        int tamanhoA = A.size();
        int[] elementosA = new int[tamanhoA];
        int indiceA = 0;
        PreencherArrayEmOrdem(A.root(), elementosA, ref indiceA);

        int tamanhoB = B.size();
        int[] elementosB = new int[tamanhoB];
        int indiceB = 0;
        PreencherArrayEmOrdem(B.root(), elementosB, ref indiceB);

        int tamanhoMaxIntersecao = tamanhoA < tamanhoB ? tamanhoA : tamanhoB;
        int[] intersecaoTemp = new int[tamanhoMaxIntersecao];
        int contadorIntersecao = 0;

        int ptrA = 0;
        int ptrB = 0;

        while (ptrA < tamanhoA && ptrB < tamanhoB)
        {
            if (elementosA[ptrA] == elementosB[ptrB])
            {
                intersecaoTemp[contadorIntersecao] = elementosA[ptrA];
                contadorIntersecao++;
                ptrA++;
                ptrB++;
            }
            else if (elementosA[ptrA] < elementosB[ptrB])
            {
                ptrA++;
            }
            else
            {
                ptrB++;
            }
        }

        ArvBin C = new ArvBin();
        for(int i = 0; i < contadorIntersecao; i++)
        {
            C.Insert(intersecaoTemp[i]);
        }

        return C;
    }
}
public class Programa
{
    public static void Main(string[] args)
    {
        ArvBin A = new ArvBin();
        int[] dadosA = { 3, 5, 6, 10, 17 };
        foreach(var elem in dadosA) A.Insert(elem);

        ArvBin B = new ArvBin();
        int[] dadosB = { 1, 3, 5, 6, 10, 18, 20 };
        foreach(var elem in dadosB) B.Insert(elem);
        
        Console.WriteLine("--- Questão 1: Interseção de Árvores Binárias de Pesquisa ---");
        Console.WriteLine("Elementos da Árvore A: " + string.Join(", ", dadosA));
        Console.WriteLine("Elementos da Árvore B: " + string.Join(", ", dadosB));

        SolucaoProva solucao = new SolucaoProva();
        ArvBin C = solucao.intersecaoArv(A, B);

        Console.WriteLine("\nResultado da Interseção (em ordem):");
        
        int[] resultadoFinal = new int[C.size()];
        int indice = 0;
        new SolucaoProva().PreencherArrayEmOrdemPublico(C.root(), resultadoFinal, ref indice);
        
        Console.WriteLine(string.Join(", ", resultadoFinal));
    }
}
public partial class SolucaoProva
{
    public void PreencherArrayEmOrdemPublico(No no, int[] array, ref int indice)
    {
        if (no == null) return;
        PreencherArrayEmOrdemPublico(no.esquerdo, array, ref indice);
        array[indice] = no.elemento;
        indice++;
        PreencherArrayEmOrdemPublico(no.direito, array, ref indice);
    }
}