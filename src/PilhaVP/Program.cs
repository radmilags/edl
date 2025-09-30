using System;

class Program {
  public static void Main(string[] args) {
    Pilha p = new Pilha(); 

    Console.WriteLine("Inserindo elementos na pilha vermelha:");
    p.InserirV(1);
    p.InserirV(2);
    p.PrintaPilha();

    Console.WriteLine("Inserindo elementos na pilha preta:");
    p.InserirP(3);
    p.InserirP(4);
    p.PrintaPilha();

    Console.WriteLine("Inserindo mais elementos para forçar duplicação:");
    p.InserirV(5); // DobraArray
    p.InserirP(6);
    p.PrintaPilha();

    Console.WriteLine("Top das pilhas:");
    Console.WriteLine("Topo Vermelho: " + p.TopV());
    Console.WriteLine("Topo Preto: " + p.TopP());

    Console.WriteLine("Removendo elementos:");
    Console.WriteLine("Pop Vermelho: " + p.PopV());
    Console.WriteLine("Pop Preto: " + p.PopP());
    p.PrintaPilha();

    Console.WriteLine("Redução da pilha:");
    p.PopV();
    p.PopV();
    p.PopP();
    p.VerificaTamanho(); //redução do array
    p.PrintaPilha();

    Console.WriteLine("Inserindo novamente após redução:");
    p.InserirP(7);
    p.InserirV(8);
    p.PrintaPilha();

    Console.WriteLine("Topo após reinserções:");
    Console.WriteLine("Topo Vermelho: " + p.TopV());
    Console.WriteLine("Topo Preto: " + p.TopP());
  }
}
