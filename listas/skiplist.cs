using System;


public class NoSkipList
{
    public int Valor { get; }
    public NoSkipList[] Proximo { get; }


    public NoSkipList(int valor, int nivel)
    {
        Valor = valor;
        Proximo = new NoSkipList[nivel + 1];
    }
}


public class SkipList
{
    private const int NivelMaximo = 16;
    private readonly Random aleatorio = new Random();
    private int nivel;
    private readonly NoSkipList cabecalho;


    public SkipList()
    {
        cabecalho = new NoSkipList(int.MinValue, NivelMaximo);
    }


    public void Inserir(int valor)
    {
        var atualizacao = new NoSkipList[NivelMaximo + 1];
        var atual = cabecalho;


        for (int i = nivel; i >= 0; i--)
        {
            while (atual.Proximo[i] != null && atual.Proximo[i].Valor < valor)
            {
                atual = atual.Proximo[i];
            }
            atualizacao[i] = atual;
        }


        var novoNivel = GerarNivelAleatorio();
        if (novoNivel > nivel)
        {
            for (int i = nivel + 1; i <= novoNivel; i++)
            {
                atualizacao[i] = cabecalho;
            }
            nivel = novoNivel;
        }


        var novoNo = new NoSkipList(valor, novoNivel);


        for (int i = 0; i <= novoNivel; i++)
        {
            novoNo.Proximo[i] = atualizacao[i].Proximo[i];
            atualizacao[i].Proximo[i] = novoNo;
        }
    }


    public bool Buscar(int valor)
    {
        var atual = cabecalho;


        for (int i = nivel; i >= 0; i--)
        {
            while (atual.Proximo[i] != null && atual.Proximo[i].Valor < valor)
            {
                atual = atual.Proximo[i];
            }
        }


        atual = atual.Proximo[0];


        return atual != null && atual.Valor == valor;
    }


    private int GerarNivelAleatorio()
    {
        int novoNivel = 0;
        while (aleatorio.NextDouble() < 0.5 && novoNivel < NivelMaximo)
        {
            novoNivel++;
        }
        return novoNivel;
    }
}


class Programa
{
    static void Main()
    {
        var skipList = new SkipList();


        skipList.Inserir(3);
        skipList.Inserir(6);
        skipList.Inserir(7);
        skipList.Inserir(9);


        Console.WriteLine(skipList.Buscar(6));
        Console.WriteLine(skipList.Buscar(8));
    }
}
