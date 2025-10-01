using System;
class Program {
  public static void Main(string[] args) {
    Pilha p = new Pilha(4); 

    p.InserirV(1);
    p.InserirV(2);
    // p.PrintaPilha();

    p.InserirP(3);
    p.InserirP(4);

    Console.WriteLine("Printando a pilha");
    p.PrintaPilha();
    // p.PrintaPilha();

    // Console.WriteLine("Topo Vermelho");
    // Console.WriteLine(p.TopV()); //retorna o elemento que ta no topo
    // Console.WriteLine("Topo Preto");
    // Console.WriteLine(p.TopP());
    
    p.InserirV(5); // DobraArray()
    p.InserirP(6);
    Console.WriteLine("Printando a pilha");
    p.PrintaPilha();
    // p.PrintaPilha(); //novapilha

    // Console.WriteLine("Indice Topo Vermelho");
    // Console.WriteLine(p.IndiceTopV());
    // Console.WriteLine("Indice Topo Preto");
    // Console.WriteLine(p.IndiceTopP());
    // Console.WriteLine(p.Capacidade());

    // Console.WriteLine("Pop Vermelho");
    // Console.WriteLine(p.PopV());
    // Console.WriteLine("Pop Preto");
    // Console.WriteLine(p.PopP());
    // p.PrintaPilha();

    p.PopV();
    p.PopV();
    p.PopP();

    Console.WriteLine("Printando a pilha");
    p.PrintaPilha();
  }
}
