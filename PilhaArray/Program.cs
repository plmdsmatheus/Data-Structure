using System;
using System.Collections;

public class Pilha<T>
{
    private T[] array;
    private int capacidade;
    private int topoVermelho;
    private int topoPreto;

    public PilhaRubroNegra(int capacidadeInicial)
    {
        if (capacidadeInicial < 2)
        {
            throw new ArgumentException("A capacidade inicial deveser pelo menos 2.");
        }

        capacidade = capacidadeInicial;
        array = new T[capacidade];
        topoVermelho = -1;
        topoPreto = capacidade;
    }

    public void PushVermelho(T item)
    {
        if (topoVermelho + 1 >= topoPreto)
        {
            Duplicar();
        }

        array[++topoVermelho] = item;
    }

    public void PushPreto(T item)
    {
        if(topoPreto - 1 <= topoVermelho)
        {
            Duplicar();
        }

        array[--topoPreto] = item;
    }

    public T popVermelho()
    {
        if(topoVermelho == -1)
        {
            throw new InvalidOperationException("Pilha vazia");
        }

        return array[topoVermelho--];
    }

    public T popPreto()
    {
        if(topoPreto == capacidade)
        {
            throw new InvalidOperationException("Pilha vazia");
        }

        return array[topoPreto++];
    }

    private void Duplicar()
    {
        int novaCapacidade = capacidade * 2;
        T[] novoArray = new T[novaCapacidade];

        for(int i = 0; i <= topoVermelho; i++)
        {
            novoArray[i] = array[i];
        }

        for(int i = capacidade - 1, j = novaCapacidade - 1; i >= topoPreto; i--, j--)
        {
            novoArray[i] = array[i];
        }

        topoPreto = novaCapacidade - (capacidade - topoPreto);
        capacidade = novaCapacidade;
        array = novoArray;
    }

    static void Teste()
    {
        PilhaRubroNegra<int> pilhas = new PilhaRubroNegra<int>(5);

        pilhas.PushVermelho(1);
        pilhas.PushVermelho(2);
        pilhas.PushVermelho(3);

        pilhas.PushPreto(4);
        pilhas.PushPreto(5);
        pilhas.PushPreto(6);

        Console.WriteLine("Elementos da pilha vermelha:");
        while(true)
        {
            try
            {
                int item = pilhas.popVermelho();
                Console.WriteLine(item);
            }
            catch (InvalidOperationException)
            {
                break;
            }
        }

        Console.WriteLine("Elementos da pilha preta:");
        while(true)
        {
            try
            {
                int item = pilhas.popPreto();
                Console.WriteLine(item);
            }
            catch (InvalidOperationException)
            {
                break;
            }
        }
    }
}