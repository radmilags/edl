# 📚 TAD Lista

## 📖 Descrição

O **TAD Lista** (Tipo Abstrato de Dado Lista) define um "contrato" para uma coleção de elementos que são mantidos em uma **sequência ordenada**. Ele especifica quais operações uma lista deve ser capaz de realizar, sem ditar *como* elas devem ser implementadas (seja com arrays ou listas encadeadas).

---

## ⚙️ Operações do TAD Lista

### Métodos Genéricos

-   **`size()`**: Retorna o número total de elementos na lista.
-   **`isEmpty()`**: Retorna `true` se a lista não contiver nenhum elemento (`size() == 0`).

### Métodos de Acesso

-   **`first()`**: Retorna o primeiro elemento da lista.
-   **`last()`**: Retorna o último elemento da lista.
-   **`before(p)`**: Retorna o elemento que está imediatamente antes da posição `p`.
-   **`after(p)`**: Retorna o elemento que está imediatamente depois da posição `p`.

### Métodos de Consulta de Posição

-   **`isFirst(n)`**: Retorna `true` se o nó/posição `n` for o primeiro da lista.
-   **`isLast(n)`**: Retorna `true` se o nó/posição `n` for o último da lista.

### Métodos de Atualização

-   **`replaceElement(n, o)`**: Substitui o elemento no nó/posição `n` pelo novo objeto `o`.
-   **`swapElements(n, q)`**: Troca os elementos armazenados nos nós/posições `n` e `q`.
-   **`insertBefore(n, o)`**: Insere um novo objeto `o` na lista, imediatamente antes do nó/posição `n`.
-   **`insertAfter(n, o)`**: Insere um novo objeto `o` na lista, imediatamente depois do nó/posição `n`.
-   **`insertFirst(o)`**: Insere um novo objeto `o` no início da lista.
-   **`insertLast(o)`**: Insere um novo objeto `o` no final da lista.
-   **`remove(n)`**: Remove o nó/posição `n` da lista.