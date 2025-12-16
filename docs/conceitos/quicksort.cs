using System;

public class QuickSortAlgo
{
    public void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            Sort(arr, low, pi - 1);
            Sort(arr, pi + 1, high);
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    private void Swap(int[] arr, int a, int b)
    {
        int aux = arr[a];
        arr[a] = arr[b];
        arr[b] = aux;
    }
}

public class Program{
    public static void Main(string[] args){
        int[] dados = { 10, 7, 8, 9, 1, 5 };

        QuickSortAlgo ordenador = new QuickSortAlgo();
        
        Console.WriteLine("Antes:");
        Imprimir(dados);

        ordenador.Sort(dados, 0, dados.Length - 1);

        Console.WriteLine("\nDepois:");
        Imprimir(dados);
        
    }
    
    static void Imprimir(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
