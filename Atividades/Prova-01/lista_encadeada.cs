using System;

public class ListaEncadeada
{
    private class No
    {
        public int Valor;
        public No Proximo;

        public No(int valor) => Valor = valor;
    }

    private No primeiro;

    public void Inserir(int valor)
    {
        No novo = new No(valor);
        if (primeiro == null)
            primeiro = novo;
        else
        {
            No atual = primeiro;
            while (atual.Proximo != null)
                atual = atual.Proximo;
            atual.Proximo = novo;
        }
    }

    public void Remover(int valor)
    {
        if (primeiro == null) return;
        if (primeiro.Valor == valor)
        {
            primeiro = primeiro.Proximo;
            return;
        }

        No atual = primeiro;
        while (atual.Proximo != null && atual.Proximo.Valor != valor)
            atual = atual.Proximo;

        if (atual.Proximo != null)
            atual.Proximo = atual.Proximo.Proximo;
    }

    public void Imprimir()
    {
        No atual = primeiro;
        while (atual != null)
        {
            Console.Write($"{atual.Valor} -> ");
            atual = atual.Proximo;
        }
        Console.WriteLine("null");
    }
}

class Program {
  public static void Main (string[] args)
  {
    
  }
}
