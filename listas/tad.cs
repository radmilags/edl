/*Implemente o TAD Vetor utilizando array*/
using System;


public class Vetor{
  private int[] Array;
  private int tamanho; //guardar o tamanho para depois duplicar
  private int capacidade = 0; //n de elementos


  public Vetor(int tamanho){
    Array = new int[tamanho];
    this.tamanho = tamanho;
  }
  public void AdicionaElemento(int n){
    if(capacidade < tamanho) Array[capacidade++] = n;
    else this.DuplicaArray(n);
  }
  public void DuplicaArray(int n){
    int novoTamanho = tamanho*2;
    int[] novoArray = new int[novoTamanho];
    for(int i = 0; i < tamanho; i++){
      novoArray[i] = Array[i];
    }
    novoArray[tamanho] = n;
    capacidade++;
    Array = novoArray;
    this.tamanho = novoTamanho;


  }
  public void GetElemento(int n){
    if(n >= tamanho) Console.WriteLine("O índice fornecido não existe dentro do array");
    else Console.WriteLine(Array[n]);
  }
  public void RetornaArray(){
    foreach(int i in Array) Console.WriteLine(i);
  }


  public void RemoveElemento(int n){ //indice
    Console.WriteLine($"Removendo o elemento do indice {n}");
    if(n < tamanho){
      capacidade--;
      for(int i = n+1; i < tamanho; i++){
        Console.WriteLine($"Array[{i-1}] = {Array[i]}");
        Array[i-1] = Array[i];
        if(i == tamanho-1) Array[i] = 0; //se chegou no ultimo, deixa o ultimo zero que é o padrao do array int
        //se fosse strings ou generico seria null
      }
    }
    else{Console.WriteLine("O índice fornecido não existe dentro do array");}
  }
}


class Program {
  public static void Main (string[] args)
  {
    Vetor v = new Vetor(2);
    v.AdicionaElemento(1);
    v.AdicionaElemento(2);
    v.RetornaArray();
    v.AdicionaElemento(3);
    // v.AdicionaElemento(4);
    v.RetornaArray();
    v.GetElemento(4);
    v.RemoveElemento(2);
    v.RetornaArray();
  }
}
