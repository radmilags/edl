using System;

public class No
{
    private object? elemento { get; set; }
    private No? Proximo { get; set; }
    private No? Anterior { get; set; }
    
    public No(object elemento)
    {
        this.elemento = elemento;
        Proximo = null;
        Anterior = null;
    }
}