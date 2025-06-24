public interface ILista<T>
{
    void Adicionar(T elemento);

    void AdicionarNoInicio(T elemento);

    // Adiciona com indice
    void AdicionarNaPosicao(int indice, T elemento);

    T RemoverDoFim();

    T RemoverDoInicio();

    // Remove e retorna com indice
    T RemoverDaPosicao(int indice);

    // Get elemento sem remover
    T Obter(int indice);

    // Retorna o índice da primeira ocorrência de um elemento.
    int IndiceDe(T elemento);

    // Verifica se ten elemento
    bool Contem(T elemento);

    // n elementos
    int Tamanho();

    bool EstaVazia();

    // Remove todos os elementos da lista.
    void Limpar();
}