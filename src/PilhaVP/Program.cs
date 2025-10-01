using System;
class Program {
  public static void Main(string[] args) {
    Pilha p = new Pilha(4); 

    Console.WriteLine("Inserindo elementos na pilha vermelha:");
    p.InserirV(1);
    p.InserirV(2);
    // p.PrintaPilha();

    Console.WriteLine("Inserindo elementos na pilha preta:");
    p.InserirP(3);
    p.InserirP(4);
    // p.PrintaPilha();

    p.InserirV(5); // DobraArray()
    p.InserirP(6);
    // p.PrintaPilha(); //novapilha

    Console.WriteLine("Topo Vermelho");
    Console.WriteLine(p.TopV());
    Console.WriteLine("Topo Preto");
    Console.WriteLine(p.TopP());

    Console.WriteLine("Pop Vermelho");
    Console.WriteLine(p.PopV());
    Console.WriteLine("Pop Preto");
    Console.WriteLine(p.PopP());
    // p.PrintaPilha();

    Console.WriteLine("Pop na pilha");
    p.PopV();
    p.PopV();
    p.PopP();
    // p.PrintaPilha();
  }
}
