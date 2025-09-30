/*Projete uma classe que contenha duas pilhas, uma “vermelha” e outra “preta” e suas operações são adaptações “coloridas” das operações habituais sobre pilhas. 
Por exemplo, esta classe deve prover uma operação de push vermelha e uma operação de push preta. Usando um ÚNICO ARRAY cuja a capacidade é limitada por um 
tamanho N que é sempre maior do que os tamanhos somados das duas pilhas. A pilha “vermelha” pode começar no início do array e a pilha “preta” pode começar no final do array. 

OBS.: Sempre que o array (que contém as duas pilhas) estiver cheio utilizar a estratégia de duplicação do tamanho do array.
OBS.: Sempre que o array (que contém as duas pilhas) estiver com 1/3 de utilização, usar a estratégia de REDUÇÃO do tamanho do array pela metade.
*/

using System;

public class Pilha{
  private int[] ArrayPilha;
  private int tamanho = 0; //numero de elementos iniciais numa pilha
  private int topoV = -1; //inicio da pilha
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

  public int PopV(){
    if(topoV > -1) return ArrayPilha[topoV--];
    else return -1;
  }
  public int PopP(){
    if(topoP <= capacidade) return ArrayPilha[topoP++];
    else return -1;
  }
  public int TopV(){
    return ArrayPilha[topoV];
  }

  public int TopP(){
    return ArrayPilha[topoP];
  }
  public int[] GetArray(){
    return ArrayPilha;
  }

  public void VerificaTamanho() {

    //n_elementos Vermelhos = topoV+1
    //n_elementos Pretos = capacidade - topoP
    int totalElementos = topoV + 1 + (capacidade - topoP); // elementos das duas pilhas
    if (capacidade > 1 && totalElementos <= capacidade / 3) {
        int novaCapacidade = capacidade / 2;
        int[] novoArray = new int[novaCapacidade];

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
      Console.Write("[ ");
      for (int i=0; i < this.capacidade; i++) {
        Console.Write(ArrayPilha[i]);
        Console.Write(", ");
      }
      Console.WriteLine("] ");
      Console.WriteLine($"top vermelho: {topoV} top preto: {topoP}");
    
    // foreach(int i in ArrayPilha){
    //     Console.WriteLine(i);
    // }
  }
}

