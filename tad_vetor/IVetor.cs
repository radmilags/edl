// Arquivo: IVetor.cs

public interface IVetor<T>
{
    // Adiciona um item no final do vetor.
    void Adicionar(T item);

    // Adiciona um item em uma posição específica.
    void AdicionarEm(int indice, T item);

    // Remove um item na posição específica.
    T RemoverEm(int indice);

    // Obtém o item de uma posição específica.
    T Obter(int indice);

    // Verifica se o vetor contém um determinado item.
    bool Contem(T item);

    // Retorna o índice da primeira ocorrência de um item
    int IndiceDe(T item);

    // n elementos
    int Tamanho { get; }

    bool EstaVazio { get; }
}