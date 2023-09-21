using System;
using System.Collections.Generic;

public class Queuetwostacks<T>
{
    private Stack<T> StackEntry = new Stack<T>();
    private Stack<T> StackExit = new Stack<T>();

    public void Enqueue(T item)
    {
        StackEntry.Push(item);
    }

    public T Dequeue()
    {
        if (StackExit.Count == 0)
        {
            if (StackEntry.Count == 0)
            {
                throw new InvalidOperationException("Empty stack.");
            }

            while (StackEntry.Count > 0)
            {
                T item = StackEntry.Pop();
                StackExit.Push(item);
            }
        }

        return StackExit.Pop();
    }

    public int Count
    {
        get { return StackEntry.Count + StackExit.Count; }
    }

    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    public void ViewQueue()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Empyt queue.");
            return;
        }

        Console.WriteLine("Queue Objects:");

        if (StackExit.Count == 0)
        {
            while (StackEntry.Count > 0)
            {
                T item = StackEntry.Pop();
                StackExit.Push(item);
            }
        }

        foreach (T item in StackExit)
        {
            Console.WriteLine($"{item}");
        }
    }
}

class Test
{
    static void Main()
    {
        Queuetwostacks<int> fila = new Queuetwostacks<int>();

        fila.Enqueue(1);
        fila.Enqueue(2);
        fila.Enqueue(3);
        Console.WriteLine("");
        fila.ViewQueue();

        Console.WriteLine("");
        Console.WriteLine($"Front: {fila.Dequeue()}");
        Console.WriteLine($"Front: {fila.Dequeue()}");
        Console.WriteLine("");

        Console.WriteLine("Elements in the current queue:");
        fila.ViewQueue();
        Console.WriteLine("");

        Console.WriteLine($"Front: {fila.Dequeue()}");

        Console.WriteLine($"Empyt Stack? {fila.IsEmpty}");
    }
}
