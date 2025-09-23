using System;
public class No
{
    public int elemento;
    public No? esquerdo;
    public No? direito;

    public No(int elemento)
    {
        this.elemento = elemento;
        esquerdo = null;
        direito = null;
    }
}
