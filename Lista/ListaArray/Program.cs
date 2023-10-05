using System;

public class Lista<T>
{
    private T[] array;
    private int size;
    private const int DefaultCapacity = 10;

    public Lista()
    {
        array = new T[DefaultCapacity];
        size = 0;
    }

    public int Size()
    {
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public T First()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A lista está vazia.");
        }
        return array[0];
    }

    public T Last()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A lista está vazia.");
        }
        return array[size - 1];
    }

    public T Before(int p)
    {
        if (p <= 0 || p >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(p));
        }
        return array[p - 1];
    }

    public T After(int p)
    {
        if (p < 0 || p >= size - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(p));
        }
        return array[p + 1];
    }

    public void ReplaceElement(int n, T o)
    {
        if (n < 0 || n >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }
        array[n] = o;
    }

    public void SwapElements(int n, int q)
    {
        if (n < 0 || n >= size || q < 0 || q >= size)
        {
            throw new ArgumentOutOfRangeException();
        }

        T temp = array[n];
        array[n] = array[q];
        array[q] = temp;
    }

    public void InsertBefore(int n, T o)
    {
        if (n < 0 || n >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        for (int i = size; i > n; i--)
        {
            array[i] = array[i - 1];
        }

        array[n] = o;
        size++;
    }

    public void InsertAfter(int n, T o)
    {
        if (n < 0 || n >= size - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        for (int i = size - 1; i > n; i--)
        {
            array[i + 1] = array[i];
        }

        array[n + 1] = o;
        size++;
    }

    public void InsertFirst(T o)
    {
        InsertBefore(0, o);
    }

    public void InsertLast(T o)
    {
        if (size >= array.Length)
        {
            EnsureCapacity(size + 1);
        }

        array[size] = o;
        size++;
    }

    public void Remove(int n)
    {
        if (n < 0 || n >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        for (int i = n; i < size - 1; i++)
        {
            array[i] = array[i + 1];
        }

        size--;
    }

    private void EnsureCapacity(int CapacidadeMin)
    {
        int novaCapacidade = array.Length == 0 ? DefaultCapacity : array.Length * 2;
        if (novaCapacidade < CapacidadeMin)
        {
            novaCapacidade = CapacidadeMin;
        }
        Array.Resize(ref array, novaCapacidade);
    }
}

class Test
{
    static void Main(string[] args)
    {
        Lista<int> lista = new Lista<int>();

        Console.WriteLine("Size: " + lista.Size());
        Console.WriteLine("Is the list empty? " + lista.IsEmpty());

        lista.InsertLast(1);
        lista.InsertLast(2);
        lista.InsertLast(3);

        Console.WriteLine("Size: " + lista.Size());
        Console.WriteLine("First object: " + lista.First());
        Console.WriteLine("Last object: " + lista.Last());

        Console.WriteLine("Object before index 2: " + lista.Before(2));
        Console.WriteLine("Object after index 0: " + lista.After(0));

        lista.ReplaceElement(1, 10);
        Console.WriteLine("Replace object at index 1 with 10: " + lista.Last());

        lista.SwapElements(0, 2);
        Console.WriteLine("Swap objects at indexes 0 and 2: First object: " + lista.First() + ", Last object: " + lista.Last());

        lista.InsertBefore(1, 5);
        Console.WriteLine("Inserted object 5 before index 1: First object: " + lista.First() + ", Size: " + lista.Size());

        lista.InsertAfter(2, 8);
        Console.WriteLine("Inserted oboject 8 after index 2: Last object: " + lista.Last() + ", List size: " + lista.Size());

        lista.InsertFirst(0);
        Console.WriteLine("Inserted object 0 at the beginning of the list: First object: " + lista.First() + ", Size: " + lista.Size());

        lista.Remove(3);
        Console.WriteLine("Removed element at index 3: List size: " + lista.Size());

    }
}