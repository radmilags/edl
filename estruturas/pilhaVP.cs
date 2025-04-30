using System;
public class Pilha{
  private int[] ArrayPilha;
  private int tamanho = 0; //numero de elementos iniciais numa pilha
  private int topoV = -1; //início da pilha
  private int topoP; //fim da pilha
  private int capacidade; // tamanho inicial do array


  public Pilha(int n){
    capacidade = n;
    topoP = n;
    ArrayPilha = new int[n];
  }

  public void InserirV(int n){
    if(tamanho < capacidade){
      ArrayPilha[++topoV] = n;
      tamanho++;
    }
    else{
      this.DobraArray();
    }
  }
  public void InserirP(int n){
   
   if(tamanho < capacidade){
      ArrayPilha[--topoP] = n;
      tamanho++;
    }
    else{
      this.DobraArray();
    }
  }
  public void DobraArray(){
    int[] NovoArray = new int[capacidade*2];
    for(int i = 0; i <= topoV; i++){
      NovoArray[i] = ArrayPilha[i];
    }
   
    for (int i = capacidade - 1; i >= topoP; i--)
    {
      NovoArray[capacidade*2 - (capacidade - i)] = ArrayPilha[i];
    }
   
    ArrayPilha = NovoArray;
  }
  public int[] GetArray(){
    return ArrayPilha;
  }
}

class Program {
  public static void Main (string[] args)
  {
    Pilha p = new Pilha(7);
    for(int i = 0; i < 8; i++){
      if(i%2==0){
        p.InserirV(i);
      }
      else{
        p.InserirP(i);
      }
    }
    int[] resultado = p.GetArray();
    foreach(int i in resultado){
      Console.WriteLine(i);
    }
  }
}