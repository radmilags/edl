using System;
using System.Collections.Generic;

public enum EstadoSlot { VAZIO, OCUPADO, REMOVIDO }

public enum TecnicaSondagem { Linear, HashDuplo }

public class ParChaveValor<TChave, TValor>
{
    public TChave Chave { get; set; }
    public TValor Valor { get; set; }
    public EstadoSlot Estado { get; set; }

    public ParChaveValor()
    {
        Estado = EstadoSlot.VAZIO;
    }
}

public class TabelaHash<TChave, TValor>
{
    private ParChaveValor<TChave, TValor>[] tabela;
    private int tamanho;
    private int capacidade;
    private TecnicaSondagem tecnicaSondagem;
    private const double FATOR_CARGA_MAXIMO = 0.7;

    public TabelaHash(TecnicaSondagem tecnica, int capacidadeInicial = 13)
    {
        this.capacidade = capacidadeInicial;
        this.tecnicaSondagem = tecnica;
        this.tabela = new ParChaveValor<TChave, TValor>[this.capacidade];
        for (int i = 0; i < this.capacidade; i++)
        {
            tabela[i] = new ParChaveValor<TChave, TValor>();
        }
        this.tamanho = 0;
    }

    private int HashPrimario(TChave chave)
    {
        return Math.Abs(chave.GetHashCode()) % capacidade;
    }

    private int HashSecundario(TChave chave)
    {
        int primoPequeno = 7;
        return primoPequeno - (Math.Abs(chave.GetHashCode()) % primoPequeno);
    }

    private void Rehash()
    {
        Console.WriteLine($"\nFATOR DE CARGA ATINGIDO! FAZENDO REHASH PARA O DOBRO DO TAMANHO.\n");
        
        ParChaveValor<TChave, TValor>[] tabelaAntiga = this.tabela;
        int capacidadeAntiga = this.capacidade;

        this.capacidade *= 2;
        this.tamanho = 0;
        this.tabela = new ParChaveValor<TChave, TValor>[this.capacidade];
        for (int i = 0; i < this.capacidade; i++)
        {
            tabela[i] = new ParChaveValor<TChave, TValor>();
        }

        for (int i = 0; i < capacidadeAntiga; i++)
        {
            if (tabelaAntiga[i].Estado == EstadoSlot.OCUPADO)
            {
                InsertItem(tabelaAntiga[i].Chave, tabelaAntiga[i].Valor);
            }
        }
    }

    public void InsertItem(TChave chave, TValor valor)
    {
        if ((double)(tamanho + 1) / capacidade > FATOR_CARGA_MAXIMO)
        {
            Rehash();
        }

        int indice = HashPrimario(chave);
        int passo = (tecnicaSondagem == TecnicaSondagem.HashDuplo) ? HashSecundario(chave) : 1;
        int tentativas = 0;

        while (tentativas < capacidade)
        {
            if (tabela[indice].Estado == EstadoSlot.VAZIO || tabela[indice].Estado == EstadoSlot.REMOVIDO)
            {
                tabela[indice].Chave = chave;
                tabela[indice].Valor = valor;
                tabela[indice].Estado = EstadoSlot.OCUPADO;
                tamanho++;
                return;
            }

            if (tabela[indice].Estado == EstadoSlot.OCUPADO && tabela[indice].Chave.Equals(chave))
            {
                tabela[indice].Valor = valor;
                return;
            }

            indice = (indice + passo) % capacidade;
            tentativas++;
        }

        throw new InvalidOperationException("A tabela hash está cheia.");
    }

    public TValor FindElement(TChave chave)
    {
        int indice = HashPrimario(chave);
        int passo = (tecnicaSondagem == TecnicaSondagem.HashDuplo) ? HashSecundario(chave) : 1;
        int tentativas = 0;

        while (tabela[indice].Estado != EstadoSlot.VAZIO && tentativas < capacidade)
        {
            if (tabela[indice].Estado == EstadoSlot.OCUPADO && tabela[indice].Chave.Equals(chave))
            {
                return tabela[indice].Valor;
            }

            indice = (indice + passo) % capacidade;
            tentativas++;
        }
        
        return default(TValor);
    }

    public TValor RemoveElement(TChave chave)
    {
        int indice = HashPrimario(chave);
        int passo = (tecnicaSondagem == TecnicaSondagem.HashDuplo) ? HashSecundario(chave) : 1;
        int tentativas = 0;

        while (tabela[indice].Estado != EstadoSlot.VAZIO && tentativas < capacidade)
        {
            if (tabela[indice].Estado == EstadoSlot.OCUPADO && tabela[indice].Chave.Equals(chave))
            {
                tabela[indice].Estado = EstadoSlot.REMOVIDO;
                tamanho--;
                return tabela[indice].Valor;
            }

            indice = (indice + passo) % capacidade;
            tentativas++;
        }
        
        return default(TValor);
    }
    
    public int Size() => tamanho;

    public bool IsEmpty() => tamanho == 0;

    public IEnumerable<TChave> Keys()
    {
        foreach (var item in tabela)
        {
            if (item.Estado == EstadoSlot.OCUPADO)
            {
                yield return item.Chave;
            }
        }
    }

    public IEnumerable<TValor> Elements()
    {
        foreach (var item in tabela)
        {
            if (item.Estado == EstadoSlot.OCUPADO)
            {
                yield return item.Valor;
            }
        }
    }
    
    public void PrintTable()
    {
        Console.WriteLine($"Tabela (Tamanho: {tamanho}, Capacidade: {capacidade}):");
        for (int i = 0; i < capacidade; i++)
        {
            var slot = tabela[i];
            Console.Write($"Indice {i}: ");
            if (slot.Estado == EstadoSlot.OCUPADO)
            {
                Console.WriteLine($"[OCUPADO] Chave: {slot.Chave}, Valor: {slot.Valor}");
            }
            else if (slot.Estado == EstadoSlot.REMOVIDO)
            {
                Console.WriteLine("[REMOVIDO]");
            }
            else
            {
                Console.WriteLine("[VAZIO]");
            }
        }
    }
}

public class Programa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("### TESTANDO TABELA HASH COM SONDAGEM LINEAR ###");
        TabelaHash<int, string> tabelaLinear = new TabelaHash<int, string>(TecnicaSondagem.Linear, 5);

        tabelaLinear.InsertItem(5, "Maçã");
        tabelaLinear.InsertItem(15, "Pera");
        tabelaLinear.InsertItem(25, "Uva");
        tabelaLinear.PrintTable();

        Console.WriteLine("Acionando Rehash...");
        tabelaLinear.InsertItem(3, "Laranja");
        tabelaLinear.PrintTable();

        Console.WriteLine($"Buscando elemento com chave 15: {tabelaLinear.FindElement(15)}");
        Console.WriteLine($"Removendo elemento com chave 5: Valor '{tabelaLinear.RemoveElement(5)}' removido.");
        tabelaLinear.PrintTable();
        Console.WriteLine($"Buscando elemento com chave 5 após remoção: {tabelaLinear.FindElement(5) ?? "NÃO ENCONTRADO"}");


        Console.WriteLine("\n### TESTANDO TABELA HASH COM HASHING DUPLO ###");
        TabelaHash<int, string> tabelaDupla = new TabelaHash<int, string>(TecnicaSondagem.HashDuplo, 5);

        tabelaDupla.InsertItem(5, "Notebook");
        tabelaDupla.InsertItem(15, "Mouse");
        tabelaDupla.InsertItem(25, "Teclado");
        tabelaDupla.PrintTable();

        Console.WriteLine("Acionando Rehash...");
        tabelaDupla.InsertItem(1, "Monitor");
        tabelaDupla.PrintTable();
        
        Console.WriteLine("Chaves presentes na tabela: " + string.Join(", ", tabelaDupla.Keys()));
        Console.WriteLine("Valores presentes na tabela: " + string.Join(", ", tabelaDupla.Elements()));
    }
}