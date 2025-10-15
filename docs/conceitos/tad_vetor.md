# 📚 TAD Vetor

## 📖 Descrição

O **TAD Vetor** estende a noção de um arranjo (array) comum. Enquanto um array é apenas uma estrutura de armazenamento "crua", o TAD Vetor adiciona uma camada de "inteligência" para gerenciar uma sequência de objetos, garantindo sua integridade.

A principal diferença é que o TAD Vetor **gerencia ativamente os elementos**, abrindo espaço para novas inserções e fechando buracos após remoções, algo que um array primitivo não faz.

---

## ⚙️ Operações Principais

-   **`size()`**: Retorna o número de elementos *realmente* armazenados no vetor.
-   **`isEmpty()`**: Retorna `true` se o vetor não contiver elementos (`size() == 0`).
-   **`elementAtRank(int r)`**: Retorna o elemento que está no ranque (índice) `r`.
-   **`replaceAtRank(int r, object o)`**: Substitui o elemento no ranque `r` pelo novo objeto `o`.
-   **`insertAtRank(int r, object o)`**: Insere o objeto `o` no ranque `r`, empurrando todos os elementos subsequentes uma posição para a direita.
-   **`removeAtRank(int r)`**: Remove o elemento no ranque `r`, puxando todos os elementos subsequentes uma posição para a esquerda para fechar o buraco.

---

## 💥 Exceções (A Rede de Segurança)

A principal exceção no TAD Vetor é a **`IndexOutOfRangeException`**, que ocorre quando se tenta acessar um ranque (índice) inválido.

| Método | Condição para o Erro (`r` é o ranque) |
| :--- | :--- |
| `elementAtRank(r)` | `r < 0` **ou** `r >= size()` |
| `replaceAtRank(r, o)` | `r < 0` **ou** `r >= size()` |
| `removeAtRank(r)` | `r < 0` **ou** `r >= size()` |
| `insertAtRank(r, o)` | `r < 0` **ou** `r > size()` |

---

## 🎯 Aplicações de Vetores

#### 1. Banco de Dados Elementar 🗃️
Funciona como um "banco de dados" simples na memória, onde cada posição do vetor armazena um registro completo (ex: um objeto cliente). É extremamente rápido para acessar um registro se o seu índice for conhecido (O(1)).

#### 2. Componente de Outras Estruturas de Dados 🧱
É o "tijolo" fundamental para construir estruturas mais complexas:
-   **Pilha:** Pode ser implementada com um vetor e um índice `topo`.
-   **Fila/Fila Circular:** Usa um vetor e dois índices, `inicio` e `fim`.
-   **Heap:** A representação mais comum de um Heap é através de um vetor, onde a relação pai-filho é calculada matematicamente a partir dos índices.
-   **Tabela Hash:** A própria tabela onde os dados são armazenados é um grande vetor.

#### 3. Estrutura Auxiliar para Algoritmos 🛠️
Serve como uma área de trabalho temporária e eficiente para muitos algoritmos.
-   **Algoritmos de Ordenação:** (Bubble Sort, Merge Sort, Quick Sort, etc.) operam diretamente sobre vetores para organizar os dados.
-   **Busca Binária:** Exige que os dados estejam em um vetor ordenado para funcionar.
-   **Contagem de Frequência:** Pode usar um vetor para contar ocorrências de itens de forma muito rápida.

---

## 🔑 Diferença Crucial: TAD Vetor vs. Array

> **TAD Vetor se reorganiza. Array deixa o buraco.**

-   **Ao remover com TAD Vetor:** A estrutura inteira é deslocada para a esquerda para manter a sequência contínua e sem espaços vazios. O `size` é decrementado.
-   **Ao "remover" em um Array:** Apenas o valor na posição é alterado (geralmente para `null` ou `0`), deixando um "buraco". O tamanho (`.length`) do array e a posição dos outros elementos não mudam.