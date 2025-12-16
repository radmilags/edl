using System;

public class MergeSortAlgo
{
    public void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;

            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);

            Merge(arr, left, middle, right);
        }
    }

    private void Merge(int[] arr, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; ++i)
            L[i] = arr[left + i];
        for (int j = 0; j < n2; ++j)
            R[j] = arr[middle + 1 + j];

        int k = left;
        int x = 0;
        int y = 0;

        while (x < n1 && y < n2)
        {
            if (L[x] <= R[y])
            {
                arr[k] = L[x];
                x++;
            }
            else
            {
                arr[k] = R[y];
                y++;
            }
            k++;
        }

        while (x < n1)
        {
            arr[k] = L[x];
            x++;
            k++;
        }

        while (y < n2)
        {
            arr[k] = R[y];
            y++;
            k++;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        int[] dados = { 12, 11, 13, 5, 6, 7 };
        
        MergeSortAlgo alg = new MergeSortAlgo();
        
        Console.WriteLine("Original:");
        Imprimir(dados);

        alg.Sort(dados, 0, dados.Length - 1);

        Console.WriteLine("\nOrdenado:");
        Imprimir(dados);
    }

    static void Imprimir(int[] arr)
    {
        foreach (int val in arr) Console.Write(val + " ");
        Console.WriteLine();
    }
}
