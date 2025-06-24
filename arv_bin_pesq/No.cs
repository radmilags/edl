public class No<T>
{
    public T Valor { get; set; }

    // nó filho à esquerda (valores menores)
    public No<T>? FilhoEsquerda { get; set; }

    // nó filho à direita (valores maiores)
    public No<T>? FilhoDireita { get; set; }

    public No(T valor)
    {
        this.Valor = valor;
        this.FilhoEsquerda = null;
        this.FilhoDireita = null;
    }
}
