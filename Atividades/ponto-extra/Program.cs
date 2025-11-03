using System;
using System.Collections;

public class Pilha{
    ArrayList pilha;
    //private int top; nao foi preciso

    public Pilha(){
        pilha = new ArrayList();
    }

    public void Push(object o)
    {
        pilha.Add(o);
    }
    
    public object Top()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("A pilha está vazia.");
        }

        return pilha[pilha.Count - 1]; 
    }

    public object Pop(){
        if (isEmpty())
        {
            throw new InvalidOperationException("A pilha está vazia.");
        }

        object o = pilha[pilha.Count - 1];
        pilha.RemoveAt(pilha.Count - 1);
        
        return o;
    }

    public int Size(){
        return pilha.Count;
    }

    public bool isEmpty(){
        return pilha.Count == 0;
    }

}

class Program{
    public static void Main(string[] args){
        Pilha pilha = new Pilha();

        pilha.Push(10);
        pilha.Push(5);

        Console.WriteLine(pilha.Pop());
        Console.WriteLine(pilha.Pop());
        Console.WriteLine(pilha.Pop());
    }
}