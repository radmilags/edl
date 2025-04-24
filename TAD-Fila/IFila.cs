public interface IFila
{
    void Enqueue(object o);
    object Dequeue();
    object First();
    int Size();
    bool IsEmpty();
}
