using System;

public class ListaArray<T> : ILista<T>
{
    private T[] _itens;
    private int _tamanho;
    private const int CAPACIDADE_INICIAL = 4;

    public ListaArray()
    {
        _itens = new T[CAPACIDADE_INICIAL];
        _tamanho = 0;
    }

    public int Tamanho() => _tamanho;

    public bool EstaVazia() => _tamanho == 0;

    private void RedimensionarSeNecessario()
    {
        if (_tamanho == _itens.Length)
        {
            int novaCapacidade = _itens.Length * 2;
            Console.WriteLine($"\n--> LISTA CHEIA! Redimensionando de {_itens.Length} para {novaCapacidade} <--\n");
            T[] novoArray = new T[novaCapacidade];
            Array.Copy(_itens, novoArray, _tamanho);
            _itens = novoArray;
        }
        else if (_tamanho > 0 && _tamanho < _itens.Length / 3)
        {
            int novaCapacidade = _itens.Length / 2;
            if (novaCapacidade < CAPACIDADE_INICIAL)
            {
                novaCapacidade = CAPACIDADE_INICIAL;
            }
            
            if(novaCapacidade != _itens.Length)
            {
                Console.WriteLine($"\n--> BAIXA OCUPAÇÃO! Redimensionando de {_itens.Length} para {novaCapacidade} <--\n");
                T[] novoArray = new T[novaCapacidade];
                Array.Copy(_itens, novoArray, _tamanho);
                _itens = novoArray;
            }
        }
    }

    private void ValidarIndice(int indice, bool paraAdicionar = false)
    {
        int limiteSuperior = paraAdicionar ? _tamanho : _tamanho - 1;
        if (indice < 0 || indice > limiteSuperior)
        {
            throw new IndexOutOfRangeException($"Índice {indice} está fora do intervalo válido [0, {limiteSuperior}].");
        }
    }

    public void Adicionar(T elemento)
    {
        RedimensionarSeNecessario();
        _itens[_tamanho] = elemento;
        _tamanho++;
    }
    
    public void AdicionarNoInicio(T elemento)
    {
        AdicionarNaPosicao(0, elemento);
    }

    public void AdicionarNaPosicao(int indice, T elemento)
    {
        ValidarIndice(indice, paraAdicionar: true);
        RedimensionarSeNecessario();
        
        for (int i = _tamanho; i > indice; i--)
        {
            _itens[i] = _itens[i - 1];
        }

        _itens[indice] = elemento;
        _tamanho++;
    }

    public T RemoverDoFim()
    {
        if (EstaVazia()) throw new InvalidOperationException("A lista está vazia.");

        _tamanho--;
        T itemRemovido = _itens[_tamanho];
        _itens[_tamanho] = default(T);
        RedimensionarSeNecessario();
        return itemRemovido;
    }

    public T RemoverDoInicio()
    {
        return RemoverDaPosicao(0);
    }
    
    public T RemoverDaPosicao(int indice)
    {
        ValidarIndice(indice);
        T itemRemovido = _itens[indice];

        for (int i = indice; i < _tamanho - 1; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        
        _tamanho--;
        _itens[_tamanho] = default(T);
        RedimensionarSeNecessario();
        return itemRemovido;
    }

    public T Obter(int indice)
    {
        ValidarIndice(indice);
        return _itens[indice];
    }

    public int IndiceDe(T elemento)
    {
        for (int i = 0; i < _tamanho; i++)
        {
            if (Equals(_itens[i], elemento))
            {
                return i;
            }
        }
        return -1;
    }

    public bool Contem(T elemento)
    {
        return IndiceDe(elemento) != -1;
    }

    public void Limpar()
    {
        _itens = new T[CAPACIDADE_INICIAL];
        _tamanho = 0;
    }

    public override string ToString()
    {
        if (EstaVazia())
        {
            return "Lista vazia.";
        }
        return $"Lista (tamanho: {_tamanho}, capacidade: {_itens.Length}): [ {string.Join(", ", _itens, 0, _tamanho)} ]";
    }
}