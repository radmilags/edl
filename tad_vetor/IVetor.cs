// Arquivo: IVetor.cs

public interface IVetor<T>
{
    // Adiciona um item no final do vetor.
    void Adicionar(T item);

    // Adiciona um item em uma posição específica
    void AdicionarEm(int indice, T item);

    // Remove um item na posição específica
    T RemoverEm(int indice);

    // Get o item de uma posição específica
    T Obter(int indice);

    bool Contem(T item);

    int IndiceDe(T item);

    // n elementos
    int Tamanho { get; }

    bool EstaVazio { get; }
}