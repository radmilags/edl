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
  private double reducao = 1.0/3; // redução para quando a pilha estiver cheia

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
  
  public void VerificaPorcentagem(){
      //n_elementos Vermelhos = topoV+1
      //n_elementos Pretos = capacidade - topoP
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

class Program {
  public static void Main (string[] args) 
  {
    Pilha p = new Pilha(7);
    for(int i = 0; i < 7; i++){
      if(i%2==0){
        p.InserirV(i);
      }
      else{
        p.InserirP(i);
      }
    }
    p.PrintaPilha();
    Console.WriteLine(p.PopV());
    Console.WriteLine(p.PopP());
    p.PrintaPilha();
  }
}

/*
Exceção para o método pop, remoção
public class ExceptionTest
{
    static double SafeDivision(double x, double y)
    {
        if (y == 0)
            throw new DivideByZeroException();
        return x / y;
    }

    public static void Main()
    {
        // Input for test purposes. Change the values to see
        // exception handling behavior.
        double a = 98, b = 0;
        double result;

        try
        {
            result = SafeDivision(a, b);
            Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Attempted divide by zero.");
        }
    }
}

*/