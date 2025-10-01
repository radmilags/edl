/*Projete uma classe que contenha duas pilhas, uma “vermelha” e outra “preta” e suas operações são adaptações “coloridas” das operações habituais sobre pilhas. 
Por exemplo, esta classe deve prover uma operação de push vermelha e uma operação de push preta. Usando um ÚNICO ARRAY cuja a capacidade é limitada por um 
tamanho N que é sempre maior do que os tamanhos somados das duas pilhas. A pilha “vermelha” pode começar no início do array e a pilha “preta” pode começar no final do array. 

OBS.: Sempre que o array (que contém as duas pilhas) estiver cheio utilizar a estratégia de duplicação do tamanho do array.
OBS.: Sempre que o array (que contém as duas pilhas) estiver com 1/3 de utilização, usar a estratégia de REDUÇÃO do tamanho do array pela metade.
*/

using System;
using System.Linq;

public class Pilha{
  private object[] ArrayPilha;
  private int tamanho = 0; //numero de elementos iniciais numa pilha - nao to mais usando isso
  private int topoV = -1; //inicio da pilha
  private int topoP; //fim da pilha
  private int capacidade; // tamanho inicial do array

  public Pilha(int capacidade){
    this.capacidade = capacidade;
    topoP = capacidade;
    ArrayPilha = new object[capacidade];
  }

  public void InserirV(object n) {
    if (topoV + 1 == topoP) DobraArray();
    topoV++;
    ArrayPilha[topoV] = n;
  }

  public void InserirP(object n) {
    if (topoV + 1 == topoP) DobraArray();
    topoP--;
    ArrayPilha[topoP] = n;
  }
  public void DobraArray()
  {
    Console.WriteLine("o array dobrou");
    object[] NovoArray = new object[capacidade * 2];
    for (int i = 0; i <= topoV; i++)
    {
      NovoArray[i] = ArrayPilha[i];
    }

    for (int i = capacidade - 1; i >= topoP; i--)
    {
      NovoArray[capacidade * 2 - (capacidade - i)] = ArrayPilha[i];
    }

    ArrayPilha = NovoArray;
    topoP = this.topoP + this.capacidade; 
    capacidade = this.capacidade * 2;  
  }

  public object PopV(){
    if (topoV < 0) throw new InvalidOperationException("Pilha vermelha está vazia.");
    ArrayPilha[topoV] = null;
    object elemento = ArrayPilha[topoV];
    topoV--;
    VerificaTamanho();
    return elemento;
  }
  public object PopP(){
    if (topoP >= capacidade) throw new InvalidOperationException("Pilha preta está vazia.");
    ArrayPilha[topoP] = null;
    object elemento = ArrayPilha[topoP];
    topoP++;
    VerificaTamanho();
    return elemento;
  }
  public object TopV(){
     if (topoV < 0) 
      throw new InvalidOperationException("Pilha vermelha está vazia.");
    return ArrayPilha[topoV];
  }

  public object TopP(){
    if (topoP >= capacidade) 
      throw new InvalidOperationException("Pilha preta está vazia.");
    return ArrayPilha[topoP];
  }

  public int IndiceTopV(){
    return topoV;
  }

  public int IndiceTopP(){
    return topoP;
  }

  public int Capacidade(){
    return capacidade;
  }

  public int TamanhoV() {
    return topoV + 1;
  }
  public int TamanhoP() {
    return capacidade - topoP;
  }
  public int TamanhoTotal() {
    return TamanhoV() + TamanhoP();
  }
  public object[] GetArray()
  {
    return ArrayPilha;
  }

  public void VerificaTamanho() {

    if (capacidade > 1 && TamanhoTotal() <= capacidade / 3) {
        int novaCapacidade = capacidade / 2;
        object[] novoArray = new object[novaCapacidade];

        for (int i = 0; i <= topoV; i++) {
          novoArray[i] = ArrayPilha[i];
        }

        int elementosPreta = capacidade - topoP;
        int novoTopoP = novaCapacidade - elementosPreta;
      
        for (int i = 0; i < elementosPreta; i++) {
            novoArray[novoTopoP + i] = ArrayPilha[topoP + i];
        }
      
        ArrayPilha = novoArray;
        capacidade = novaCapacidade;
        topoP = novoTopoP;
    }
}

 
  
  public void PrintaPilha() {
    
    foreach(object i in ArrayPilha){
      if(i != null) Console.WriteLine(i);
    }
  }
}

