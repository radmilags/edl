public class Lista
{

    private No Inicio;
    private No Final;
    private int size;

    public Lista()
    {
        this.Inicio = null;
        this.Final = null;
        this.size = 0;
    }

    public bool isEmpty()
    {
        if (size == 0) return true;
        return false;
    }

    public bool isFirst(object o)
    {
        if (First() == o) return true;
        return false;
    }

    public bool isLast(object o)
    {
        if (Last() == o) return true;
        return false;
    }

    public object First()
    {
        return this.Inicio.Proximo();
    }
    
    public object Last()
    {
        return this.Final.Anterior();
    }
}