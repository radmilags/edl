<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/bd/Logo_C_sharp.svg/1200px-Logo_C_sharp.svg.png" width="100px" />
  <img src="https://cdn.iconscout.com/icon/free/png-256/free-java-logo-icon-download-in-svg-png-gif-file-formats--wordmark-programming-language-pack-logos-icons-1174953.png?f=webp" width="150px" />
</p>

# 📚 TAD Fila

<p align="center">
  <img src="https://img.shields.io/badge/TAD-Fila-yellow?style=for-the-badge" alt="TAD Fila" />
</p>

---

## 📖 Descrição

O **TAD Fila** é uma estrutura de dados que armazena objetos arbitrários e segue o esquema **FIFO** (First In, First Out), ou seja, os elementos são inseridos no final da fila e removidos do início da fila.

Possui duas variáveis que guardam o início da fila e o final

int i, f;

na remoção fila[i] = null; i++;
when i == f; -> array/fila vazia

//Criar arquivo descrevendo o array circular, estrutura quebrada

dobrar o tamanho do array sempre para a complexidade se manter em O(1);

---

## 🔄 Operações Principais

- **`enqueue(object)`**: Insere um elemento no fim da fila.
    fila[f] = elemento;
    f = (f+1) % n;
    isso é a mesma coisa de 
    f++;
    if(f==n) f = 0;
- **`dequeue()`**: Remove e retorna o elemento do início da fila.
    elemento = fila[i];
    i = (i+1)%n;
    return elemento;
- **`first()`**: Retorna o elemento do início sem removê-lo.
- **`size()`**: Retorna o número de elementos armazenados na fila.
    return (n-i+f) % n -> retorna a quantidade de elementos
- **`isEmpty()`**: Indica se há elementos na fila.

---

## ⚠️ Exceções

- **`EFilaVaziaException`**: Chamada quando se tenta remover ou ver um elemento do início da fila, mas a fila está vazia. 

---

## 📊 Fluxo de Funcionamento

1. **Inserção (enqueue)**:
    - O elemento é adicionado ao final da fila.
2. **Remoção (dequeue)**:
    - O elemento é retirado do início da fila, seguindo a ordem FIFO.

---

## 🧠 Exemplos

```java
Fila minhaFila = new Fila();
minhaFila.enqueue(1);  // Adiciona 1 à fila
minhaFila.enqueue(2);  // Adiciona 2 à fila
System.out.println(minhaFila.dequeue());  // Remove e imprime 1
System.out.println(minhaFila.first());    // Retorna 2, sem removê-lo

```C#
Fila minhaFila = new Fila();
minhaFila.enqueue(1);  // Adiciona 1 à fila
minhaFila.enqueue(2);  // Adiciona 2 à fila
Console.WriteLine(minhaFila.dequeue());  // Remove e imprime 1
Console.WriteLine(minhaFila.first());    // Retorna 2, sem removê-lo