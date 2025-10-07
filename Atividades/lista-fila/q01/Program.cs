using System;

static void Program(string[] args)
{
    Fila fila = new Fila(100);
    fila.Enqueue(5);
    fila.Enqueue(3);
    fila.Dequeue();
    fila.Enqueue(2);
    fila.Enqueue(8);
    fila.Dequeue();
    fila.Dequeue();
    fila.Enqueue(9);
    fila.Enqueue(1);
    fila.Dequeue();
    fila.Enqueue(7);
    fila.Enqueue(6);
    fila.Dequeue();
    fila.Dequeue();
    fila.Enqueue(4);
    fila.Enqueue(7);
    fila.Dequeue();
}