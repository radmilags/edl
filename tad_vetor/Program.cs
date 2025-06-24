using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("INICIANDO TESTES DO TAD VETOR");

        Console.WriteLine("TESTANDO VetorArray<int>");
        var vetorArray = new VetorArray<int>();
        TestarImplementacao(vetorArray);
        TestarRedimensionamentoArray();

        Console.WriteLine("\nTESTANDO VetorListaDupla<int>");
        var vetorLista = new VetorListaDupla<int>();
        TestarImplementacao(vetorLista);
    }

    public static void TestarImplementacao(IVetor<int> vetor)
    {
        Console.WriteLine($"Vetor inicial: {vetor}. Tamanho: {vetor.Tamanho}. Vazio? {vetor.EstaVazio}");
        
        Console.WriteLine("\n Adicionando 10, 20, 30");

        
        vetor.Adicionar(10);
        vetor.Adicionar(20);
        vetor.Adicionar(30);
        Console.WriteLine($"Vetor: {vetor}. Tamanho: {vetor.Tamanho}");
        
        Console.WriteLine("\n Adicionando 99 na posição 1");
        vetor.AdicionarEm(1, 99);
        Console.WriteLine($"Vetor: {vetor}. Tamanho: {vetor.Tamanho}");
        
        Console.WriteLine("\n Adicionando 5 na posição 0 (início)");
        vetor.AdicionarEm(0, 5);
        Console.WriteLine($"Vetor: {vetor}. Tamanho: {vetor.Tamanho}");

        Console.WriteLine($"\n Obtendo elemento no índice 2: {vetor.Obter(2)}");
        Console.WriteLine($" Vetor contém 20? {vetor.Contem(20)}");
        Console.WriteLine($" Vetor contém 77? {vetor.Contem(77)}");
        Console.WriteLine($" Índice do elemento 30: {vetor.IndiceDe(30)}");

        Console.WriteLine($"\n Removendo elemento no índice 1");
        int removido = vetor.RemoverEm(1);
        Console.WriteLine($"Item removido: {removido}. Vetor: {vetor}. Tamanho: {vetor.Tamanho}");
        
        Console.WriteLine("\n Removendo o último elemento");
        vetor.RemoverEm(vetor.Tamanho - 1);
        Console.WriteLine($"Vetor: {vetor}. Tamanho: {vetor.Tamanho}");
    }
    
    public static void TestarRedimensionamentoArray()
    {
        var vetor = new VetorArray<int>(4); // Capacidade inicial 4
        Console.WriteLine($"Tamanho={vetor.Tamanho}, Capacidade={vetor.Capacidade}");

        Console.WriteLine("\n Adicionando 4 elementos para encher o vetor");
        for (int i = 1; i <= 4; i++)
        {
            vetor.Adicionar(i * 10);
            Console.WriteLine($"Tamanho={vetor.Tamanho}, Capacidade={vetor.Capacidade}");
        }

        Console.WriteLine("(dobrar capacidade)");
        vetor.Adicionar(50);
        Console.WriteLine($"Tamanho={vetor.Tamanho}, Capacidade={vetor.Capacidade}");
        Console.WriteLine($"Vetor atual: {vetor}");

        Console.WriteLine("\n Removendo elementos");
        
        vetor.RemoverEm(vetor.Tamanho - 1);
        Console.WriteLine($"Tamanho={vetor.Tamanho}, Capacidade={vetor.Capacidade}");
        vetor.RemoverEm(vetor.Tamanho - 1);
        Console.WriteLine($"Removido outro. Tamanho={vetor.Tamanho}, Capacidade={vetor.Capacidade}");
        
        vetor.RemoverEm(vetor.Tamanho - 1);
        Console.WriteLine($"Tamanho={vetor.Tamanho}, Capacidade={vetor.Capacidade}");
        Console.WriteLine($"Vetor final: {vetor}");
    }
}