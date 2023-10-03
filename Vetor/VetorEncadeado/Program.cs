using System;

public class VetorEncadeadoDuplamente
{
    private class No
    {
        public object Elemento { get; set; }
        public No Anterior { get; set; }
        public No Proximo { get; set; }

        public No(object elemento)
        {
            Elemento = elemento;
            Anterior = null;
            Proximo = null;
        }
    }

    private No Cabeca;
    private int Tamanho;

    public VetorEncadeadoDuplamente()
    {
        Cabeca = null;
        Tamanho = 0;
    }

    public object ElemAtRank(int r)
    {
        if (r < 0 || r >= Tamanho)
        {
            throw new ArgumentOutOfRangeException("Posição fora dos limites.");
        }

        No atual = Cabeca;
        for (int i = 0; i < r; i++)
        {
            atual = atual.Proximo;
        }

        return atual.Elemento;
    }

    public object ReplaceAtRank(int r, object o)
    {
        if (r < 0 || r >= Tamanho)
        {
            throw new ArgumentOutOfRangeException("Posição fora dos limites.");
        }

        No atual = Cabeca;
        for (int i = 0; i < r; i++)
        {
            atual = atual.Proximo;
        }

        object elementoAntigo = atual.Elemento;
        atual.Elemento = o;
        return elementoAntigo;
    }

    public void InsertAtRank(int r, object o)
    {
        if (r < 0 || r > Tamanho)
        {
            throw new ArgumentOutOfRangeException("Posição fora dos limites.");
        }

        No novoNodo = new No(o);

        if (r == 0)
        {
            novoNodo.Proximo = Cabeca;
            Cabeca = novoNodo;
        }
        else
        {
            No atual = Cabeca;
            for (int i = 0; i < r - 1; i++)
            {
                atual = atual.Proximo;
            }

            novoNodo.Proximo = atual.Proximo;
            atual.Proximo = novoNodo;
        }

        Tamanho++;
    }

    public object RemoveAtRank(int r)
    {
        if (r < 0 || r >= Tamanho)
        {
            throw new ArgumentOutOfRangeException("Posição fora dos limites.");
        }

        object elementoRemovido;
        if (r == 0)
        {
            elementoRemovido = Cabeca.Elemento;
            Cabeca = Cabeca.Proximo;
        }
        else
        {
            No atual = Cabeca;
            for (int i = 0; i < r - 1; i++)
            {
                atual = atual.Proximo;
            }

            elementoRemovido = atual.Proximo.Elemento;
            atual.Proximo = atual.Proximo.Proximo;
        }

        Tamanho--;
        return elementoRemovido;
    }

    public int Size()
    {
        return Tamanho;
    }

    public bool IsEmpty()
    {
        return Tamanho == 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        VetorEncadeadoDuplamente vetor = new VetorEncadeadoDuplamente();

        vetor.InsertAtRank(0, 10);
        vetor.InsertAtRank(1, 20);
        vetor.InsertAtRank(2, 30);

        Console.WriteLine("Tamanho do vetor: " + vetor.Size());

        Console.WriteLine("Elementos do vetor:");
        for (int i = 0; i < vetor.Size(); i++)
        {
            Console.WriteLine("Elemento na posição " + i + ": " + vetor.ElemAtRank(i));
        }

        object elementoAntigo = vetor.ReplaceAtRank(1, 25);
        Console.WriteLine("Elemento antigo na posição 1: " + elementoAntigo);
        Console.WriteLine("Novo elemento na posição 1: " + vetor.ElemAtRank(1));

        object elementoRemovido = vetor.RemoveAtRank(2);
        Console.WriteLine("Elemento removido na posição 2: " + elementoRemovido);

        Console.WriteLine("Novo tamanho do vetor: " + vetor.Size());

        Console.WriteLine("O vetor está vazio? " + vetor.IsEmpty());

        Console.WriteLine("Elementos do vetor após remoção:");
        for (int i = 0; i < vetor.Size(); i++)
        {
            Console.WriteLine("Elemento na posição " + i + ": " + vetor.ElemAtRank(i));
        }
    }
}
