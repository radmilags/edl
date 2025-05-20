using System;
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

//