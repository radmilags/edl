class Program {
  public static void Main (string[] args)
  {
    Queue<int> fila = new Queue<int>();
    fila.Enqueue(1);
    fila.Enqueue(2);
    fila.Enqueue(3);


    Console.WriteLine(fila.Dequeue());
    Console.WriteLine(fila.Dequeue());


    Stack<string> pilha = new Stack<string>();


    //lembrar que PUSH é EMPURRAR - IN
    //Adiciona = método Push
    pilha.Adiciona("R");
    pilha.Adiciona("A");
    pilha.Adiciona("D");


   
    //adicionar metodo que retorna os elementos de uma pilha
    Console.WriteLine(pilha);
   
    Console.WriteLine(pilha.Pop());
    Console.WriteLine(pilha.Pop());


  }
}