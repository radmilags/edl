using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Cria uma nova árvore de inteiros
        var arvore = new ArvoreBinariaPesquisa<int>();
        
        Console.WriteLine("=================================================");
        Console.WriteLine("    ÁRVORE BINÁRIA DE PESQUISA - DEMONSTRAÇÃO    ");
        Console.WriteLine("=================================================\n");

        Console.WriteLine("--> Inserindo valores: 10, 5, 15, 2, 8, 22...\n");
        arvore.Inserir(10);
        arvore.Inserir(5);
        arvore.Inserir(15);
        arvore.Inserir(2);
        arvore.Inserir(8);
        arvore.Inserir(22);
        
        Console.WriteLine("ESTRUTURA DA ÁRVORE APÓS INSERÇÕES INICIAIS:");
        arvore.Mostrar();
        Console.WriteLine("-------------------------------------------------\n");
        
        // Exemplo continuando as operações
        Console.WriteLine("--> Inserindo o valor 25...\n");
        arvore.Inserir(25);

        Console.WriteLine("ESTRUTURA DA ÁRVORE APÓS INSERIR 25:");
        arvore.Mostrar();
        Console.WriteLine("-------------------------------------------------\n");

        Console.WriteLine("--> Removendo o valor 5...\n");
        arvore.Remover(5);

        Console.WriteLine("ESTRUTURA DA ÁRVORE APÓS REMOVER 5:");
        arvore.Mostrar();
        Console.WriteLine("-------------------------------------------------\n");
        
        Console.WriteLine("--> Buscando valores:");
        Console.WriteLine("Buscar 15: " + (arvore.Buscar(15) ? "Encontrado" : "Não encontrado"));
        Console.WriteLine("Buscar 99: " + (arvore.Buscar(99) ? "Não encontrado" : "Encontrado"));
        Console.WriteLine("\n--> Percurso Em-Ordem (valores em ordem crescente):");
        arvore.EmOrdem();
        
        Console.WriteLine("\n=================================================");
        Console.WriteLine("                 FIM DA EXECUÇÃO                 ");
        Console.WriteLine("=================================================");
    }
}
