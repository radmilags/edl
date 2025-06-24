using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" TESTANDO LISTA COM ARRAY ");
        ILista<int> listaDeInteiros = new ListaArray<int>();
        TestarListaDeInteiros(listaDeInteiros);
        TestarRedimensionamentoArray(); 

        Console.WriteLine(" TESTANDO LISTA DUPLAMENTE ENCADEADA ");
        ILista<string> listaDeStrings = new ListaDuplamenteEncadeada<string>();
        TestarListaDeStrings(listaDeStrings);
    }

    static void TestarListaDeInteiros(ILista<int> lista)
    {
        Console.WriteLine("1. Adicionando elementos");
        lista.Adicionar(10);
        lista.Adicionar(20);
        lista.Adicionar(30);
        lista.AdicionarNoInicio(5);
        Console.WriteLine($"Lista: {lista}");

        Console.WriteLine("2. Adicionando na posição 2");
        lista.AdicionarNaPosicao(2, 15);
        Console.WriteLine($"Lista: {lista}");

        Console.WriteLine("3. Removendo elementos");
        Console.WriteLine($"Removeu do fim: {lista.RemoverDoFim()}");
        Console.WriteLine($"Lista: {lista}");

        Console.WriteLine($"Removeu da posição 0: {lista.RemoverDaPosicao(0)}");
        Console.WriteLine($"Lista: {lista}"); 
        
        Console.WriteLine("4. Buscando informações");
        Console.WriteLine($"Elemento na posição 1: {lista.Obter(1)}");
        Console.WriteLine($"Índice do elemento 10: {lista.IndiceDe(10)}");
        Console.WriteLine($"Contém o elemento 99? {lista.Contem(99)}");
        Console.WriteLine($"Tamanho da lista: {lista.Tamanho()}");

        Console.WriteLine("5. Limpando a lista");
        lista.Limpar();
        Console.WriteLine($"Lista: {lista}");
    }

    static void TestarListaDeStrings(ILista<string> lista)
    {
        
        Console.WriteLine("1. Adicionando elementos");
        lista.Adicionar("Agua");
        lista.Adicionar("Terra");
        lista.Adicionar("Fogo");
        lista.AdicionarNoInicio("Ar");
        Console.WriteLine($"Lista: {lista}");

        Console.WriteLine("2. Adicionando na posição 2");
        lista.AdicionarNaPosicao(2, "Relampago");
        Console.WriteLine($"Lista: {lista}");

        Console.WriteLine("3. Removendo elementos");
        Console.WriteLine($"Removeu do fim: {lista.RemoverDoFim()}");
        Console.WriteLine($"Lista: {lista}");
    }
    
    static void TestarRedimensionamentoArray()
    {
        ILista<int> lista = new ListaArray<int>();
        
        lista.Adicionar(1);
        lista.Adicionar(2);
        lista.Adicionar(3);
        lista.Adicionar(4);
        Console.WriteLine(lista);
        
        Console.WriteLine("Dobrar capacidade");
        lista.Adicionar(5);
        Console.WriteLine(lista);

        lista.RemoverDoFim();
        lista.RemoverDoFim();
        lista.RemoverDoFim();
        Console.WriteLine(lista);

        Console.WriteLine("Reduz o tamanho");
        lista.RemoverDoFim();
        Console.WriteLine(lista);
    }
}