# TAD Lista

O **TAD Lista** modela uma **sequência de posições** que armazenam objetos de qualquer tipo.  
Ele estabelece uma **relação de ordem** entre as posições (antes / depois).

---

## Métodos Genéricos
| Método | Descrição |
|---------|------------|
| `size()` | Retorna o número de elementos na lista. |
| `isEmpty()` | Retorna `true` se a lista estiver vazia, `false` caso contrário. |

---

## Métodos de Fila
| Método | Descrição |
|---------|------------|
| `isFirst(n)` | Retorna `true` se `n` for a primeira posição da lista. |
| `isLast(n)` | Retorna `true` se `n` for a última posição da lista. |

---

## Métodos de Acesso
| Método | Descrição |
|---------|------------|
| `first()` | Retorna a primeira posição da lista. |
| `last()` | Retorna a última posição da lista. |
| `before(p)` | Retorna a posição imediatamente anterior a `p`. |
| `after(p)` | Retorna a posição imediatamente posterior a `p`. |

---

## Métodos de Atualização
| Método | Descrição |
|---------|------------|
| `replaceElement(n, o)` | Substitui o elemento armazenado na posição `n` por `o`. |
| `swapElements(n, q)` | Troca os elementos armazenados nas posições `n` e `q`. |
| `insertBefore(n, o)` | Insere um novo elemento `o` **antes** da posição `n`. |
| `insertAfter(n, o)` | Insere um novo elemento `o` **depois** da posição `n`. |
| `insertFirst(o)` | Insere um novo elemento `o` no **início** da lista. |
| `insertLast(o)` | Insere um novo elemento `o` no **final** da lista. |
| `remove(n)` | Remove o elemento armazenado na posição `n`. |
