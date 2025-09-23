class Program {
  public static void Main (string[] args)
  {
    FilaCircular<int> fila = new FilaCircular<int>(3);
    fila.Enqueue(1);
    fila.Enqueue(2);
    fila.Enqueue(3);
   
    Console.WriteLine(fila.Dequeue());
    fila.Enqueue(4);
   
    Console.WriteLine(fila.Dequeue());
    Console.WriteLine(fila.Dequeue());
    Console.WriteLine(fila.Dequeue());
   
    fila.Enqueue(5);
    Console.WriteLine(fila.Front());

  }
}