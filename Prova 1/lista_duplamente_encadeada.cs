using System;
public class ListaDuplamenteEncadeada
{
    private class No
    {
        public int Valor;
        public No Anterior, Proximo;
        public No(int valor) => Valor = valor;
    }

    private No primeiro, ultimo;

    public void Inserir(int valor)
    {
        No novo = new No(valor);
        if (primeiro == null)
            primeiro = ultimo = novo;
        else
        {
            ultimo.Proximo = novo;
            novo.Anterior = ultimo;
            ultimo = novo;
        }
    }

    public void Remover(int valor)
    {
        No atual = primeiro;
        while (atual != null && atual.Valor != valor)
            atual = atual.Proximo;

        if (atual == null) return;

        if (atual.Anterior != null)
            atual.Anterior.Proximo = atual.Proximo;
        else
            primeiro = atual.Proximo;

        if (atual.Proximo != null)
            atual.Proximo.Anterior = atual.Anterior;
        else
            ultimo = atual.Anterior;
    }

    public void Imprimir()
    {
        No atual = primeiro;
        while (atual != null)
        {
            Console.Write($"{atual.Valor} <-> ");
            atual = atual.Proximo;
        }
        Console.WriteLine("null");
    }
}


class Program{
  public static void Main(string[] args){

  }
}
