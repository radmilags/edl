using System;

public class NoABP
{
    public int chave;
    public object elemento;
    public NoABP pai;
    public NoABP esquerda;
    public NoABP direita;

    public NoABP(int chave, object elemento)
    {
        this.chave = chave;
        this.elemento = elemento;
        this.pai = null;
        this.esquerda = null;
        this.direita = null;
    }

    public NoABP(int chave, object elemento, NoABP pai)
    {
        this.chave = chave;
        this.elemento = elemento;
        this.pai = pai;
        this.esquerda = null;
        this.direita = null;
    }
}
