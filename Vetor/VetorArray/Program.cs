using System;

class Vetor
{
    private object[] array;
    private int size;

    public Vetor(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException("A capacidade do vetor não pode ser negativa");
        }

        array = new object[capacity];
        size = 0;
    }

    public object ElemAtRank(int rank)
    {
        if (rank < 0 || rank >= size)
        {
            throw new IndexOutOfRangeException("Rank está fora do tamanho do array.");
        }

        return array[rank];
    }

    public object ReplaceAtRank(int rank, object obj)
    {
        if (rank < 0 || rank >= size)
        {
            throw new IndexOutOfRangeException("Rank está fora do tamanho do array.");
        }

        object objAntigo = array[rank];
        array[rank] = obj;
        return objAntigo;
    }

    public void InsertAtRank(int rank, object obj)
    {
        if (rank < 0 || rank > size)
        {
            throw new IndexOutOfRangeException("Rank está fora do tamanho do array.");
        }

        if (size == array.Length)
        {
            // Dobra o tamanho do array.
            Duplicate();
        }

        // Deslocamento para direita.
        for (int i = size; i > rank; i--)
        {
            array[i] = array[i - 1];
        }

        array[rank] = obj;
        size++;
    }

    public object RemoveAtRank(int rank)
    {
        if (rank < 0 || rank >= size)
        {
            throw new IndexOutOfRangeException("Rank está fora do tamanho do array.");
        }

        object objToRemove = array[rank];

        // Deslocamento para esquerda.
        for (int i = rank; i < size - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[size - 1] = null;
        size--;

        return objToRemove;
    }

    public int Size()
    {
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    private void Duplicate()
    {
        int newCapacity = (array.Length == 0) ? 1 : array.Length * 2;
        Array.Resize(ref array, newCapacity);
    }
    public void ListArray()
    {
        Console.Write("Elementos no vetor: ");
        for (int i = 0; i < size; i++)
        {
            Console.Write(array[i]);

            if (i < size - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}

class Test
{
    static void Main(string[] args)
    {
        Vetor vetor = new Vetor(2);
        vetor.InsertAtRank(0, 1);
        vetor.InsertAtRank(1, 2);
        vetor.InsertAtRank(2, 3);

        Console.WriteLine("");
        vetor.ListArray();
        Console.WriteLine("");

        Console.WriteLine("1º obj no array: " + vetor.ElemAtRank(1)); 

        vetor.ReplaceAtRank(1, 4);
        Console.WriteLine("1º obj após a troca: " + vetor.ElemAtRank(1)); 

        Console.WriteLine("");
        vetor.ListArray();
        Console.WriteLine("");

        vetor.RemoveAtRank(0);
        Console.WriteLine("Tamanho: " + vetor.Size()); 
        vetor.ListArray();
        vetor.InsertAtRank(0, 1);
        vetor.ListArray();
    }
}