using System;

public class No
{
    public int elemento;
    public No? parent;
    public No? esquerdo;
    public No? direito;

    public No(int elem, No? noParent)
    {
        elemento = elem;
        parent = noParent;
        esquerdo = null;
        direito = null;
    }
}

public class ArvBin
{
    private No? raiz;
    private int contadorNos;

    public ArvBin()
    {
        raiz = null;
        contadorNos = 0;
    }

    public No? root()
    {
        return raiz;
    }

    public int size()
    {
        return contadorNos;
    }

    public void Insert(int elem)
    {
        raiz = InsertRecursivo(raiz, null, elem);
    }

    private No InsertRecursivo(No? noAtual, No? noParent, int elem)
    {
        if (noAtual == null)
        {
            contadorNos++;
            return new No(elem, noParent);
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
    
    public bool Search(int elem)
    {
        return SearchRecursivo(raiz, elem);
    }

    private bool SearchRecursivo(No? noAtual, int elem)
    {
        if (noAtual == null) return false;
        if (elem == noAtual.elemento) return true;
        if (elem < noAtual.elemento) return SearchRecursivo(noAtual.esquerdo, elem);
        else return SearchRecursivo(noAtual.direito, elem);
    }
}

public class SolucaoProva
{
    public ArvBin intersecaoArv(ArvBin A, ArvBin B)
    {
        ArvBin C = new ArvBin();
        PercorrerEVerificar(A.root(), B, C);
        return C;
    }

    private void PercorrerEVerificar(No? noA, ArvBin B, ArvBin C)
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

public class Programa
{
    // Método auxiliar para contar os nós, agora dentro da classe de teste
    private static int ContarNos(No? no)
    {
        if (no == null) return 0;
        return 1 + ContarNos(no.esquerdo) + ContarNos(no.direito);
    }

    // Método auxiliar para preencher o array de resultado
    private static void ExtrairElementos(No? no, int[] array, ref int indice)
    {
        if (no != null)
        {
            ExtrairElementos(no.esquerdo, array, ref indice);
            array[indice] = no.elemento;
            indice++;
            ExtrairElementos(no.direito, array, ref indice);
        }
    }

    public static void Main(string[] args)
    {
        ArvBin A = new ArvBin();
        int[] dadosA = { 3, 5, 6, 10, 17 };
        foreach(var elem in dadosA) A.Insert(elem);

        ArvBin B = new ArvBin();
        int[] dadosB = { 1, 3, 5, 6, 10, 18, 20 };
        foreach(var elem in dadosB) B.Insert(elem);
        
        Console.WriteLine("Elementos da Árvore A: " + string.Join(", ", dadosA));
        Console.WriteLine("Elementos da Árvore B: " + string.Join(", ", dadosB));

        SolucaoProva solucao = new SolucaoProva();
        ArvBin C = solucao.intersecaoArv(A, B);

        Console.WriteLine("\nResultado da Interseção (em ordem):");
        
        // Lógica "na mão" para exibir o resultado
        int tamanhoResultado = ContarNos(C.root());
        int[] resultadoFinal = new int[tamanhoResultado];
        int indice = 0;
        ExtrairElementos(C.root(), resultadoFinal, ref indice);
        
        Console.WriteLine(string.Join(", ", resultadoFinal));
    }
}