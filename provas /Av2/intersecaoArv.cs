class intersecaoArv{

    public ArvBin intersecao(ArvBin A, ArvBin B){
        int tamanhoA = A.size();
        int[] elementosA = new int[tamanhoA];
        int indiceA = 0;
        PreencherArrayEmOrdem(A.root(), elementosA, ref indiceA);

        int tamanhoB = B.size();
        int[] elementosB = new int[tamanhoB];
        int indiceB = 0;
        PreencherArrayEmOrdem(B.root(), elementosB, ref indiceB);

        int tamanhoMaxIntersecao = tamanhoA < tamanhoB ? tamanhoA : tamanhoB;
        int[] intersecaoTemp = new int[tamanhoMaxIntersecao];
        int contadorIntersecao = 0;

        int ptrA = 0;
        int ptrB = 0;

        while (ptrA < tamanhoA && ptrB < tamanhoB)
        {
            if (elementosA[ptrA] == elementosB[ptrB])
            {
                intersecaoTemp[contadorIntersecao] = elementosA[ptrA];
                contadorIntersecao++;
                ptrA++;
                ptrB++;
            }
            else if (elementosA[ptrA] < elementosB[ptrB])
            {
                ptrA++;
            }
            else
            {
                ptrB++;
            }
        }

        ArvBin C = new ArvBin();
        for(int i = 0; i < contadorIntersecao; i++)
        {
            C.Insert(intersecaoTemp[i]);
        }

        return C;
    }
}