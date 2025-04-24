using System;

public class FilaVaziaException : Exception
{
    public FilaVaziaException(string mensagem) : base(mensagem) { }
}
