using System;
using System.Collections;

public class Pilha{
    ArrayList pilha;

    public Pilha(){
        pilha = new ArrayList();
    }

    public void Push(object o){
        pilha.Add(o);
        topo++;
    }

    public object Pop(){
        if(isEmpty()) throw new InvalidOperationException("A pilha está vazia.");
        pilha.Remove;
    }

    public int Size(){
        return pilha.Count;
    }

    public bool isEmpty(){
        if(pilha.Count == 0) return true;
        return false;
    }

}

class Program{
    public static void Main(string[] args){
        ArrayList pilha = new ArrayList();

        pilha.Push(10);
        pilha.Push(5);

        Console.WriteLine(pilha.Pop());
    }
}