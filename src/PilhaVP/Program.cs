using System;

class Program {
  public static void Main(string[] args) {
    Pilha p = new Pilha(4); 

    Console.WriteLine("Inserindo elementos na pilha vermelha:");
    p.InserirV(1);
    p.InserirV(2);
    p.PrintaPilha();

    Console.WriteLine("Inserindo elementos na pilha preta:");
    p.InserirP(3);
    p.InserirP(4);
    p.PrintaPilha();

    p.InserirV(5); // DobraArray()
    p.InserirP(6);
    p.PrintaPilha(); //novapilha

    Console.WriteLine("Topo das Pilhas");
    Console.WriteLine("Topo Vermelho: " + p.TopV());
    Console.WriteLine("Topo Preto: " + p.TopP());

    Console.WriteLine("Removendo elementos");
    Console.WriteLine("Pop Vermelho: " + p.PopV());
    Console.WriteLine("Pop Preto: " + p.PopP());
    p.PrintaPilha();

    Console.WriteLine("Redução da pilha:");
    p.PopV();
    p.PopV();
    p.PopP();
    p.VerificaTamanho(); //redução do array
    p.PrintaPilha();

    Console.WriteLine("Novo topo");
    Console.WriteLine("Topo Vermelho: " + p.TopV());
    Console.WriteLine("Topo Preto: " + p.TopP());
  }
}
