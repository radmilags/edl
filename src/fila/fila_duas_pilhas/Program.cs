class Program {
  public static void Main (string[] args)
  {
    Pilha<int> fila = new Pilha<int>();
    fila.enfileirar(1);
    fila.enfileirar(2);
    fila.enfileirar(3);
   
    Console.WriteLine(fila.desenfileirar());
    Console.WriteLine(fila.desenfileirar());
   
    fila.enfileirar(4);
    Console.WriteLine(fila.desenfileirar());
    Console.WriteLine(fila.desenfileirar());

  }
}