package Pilha.pilha_src;

public class PilhaArray implements Pilha {
    private Object[] array;
    private int topo;

    public PilhaArray(int capacidade) {
        this.array = new Object[capacidade];
        this.topo = -1;
    }

    @Override
    public int size() {
        return topo + 1;
    }

    @Override
    public boolean isEmpty() {
        return topo == -1;
    }

    @Override
    public Object top() throws PilhaVaziaExcecao {
        if (isEmpty()) {
            throw new PilhaVaziaExcecao("A pilha está vazia.");
        }
        return array[topo];
    }

    @Override
    public void push(Object o) {
        if (topo == array.length - 1) {
            throw new PilhaCheiaExcecao("A pilha está cheia.");
        }
        array[++topo] = o;
    }

    @Override
    public Object pop() throws PilhaVaziaExcecao {
        if (isEmpty()) {
            throw new PilhaVaziaExcecao("A pilha está vazia.");
        }
        return array[topo--];
    }
}