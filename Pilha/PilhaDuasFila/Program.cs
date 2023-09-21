using System;
using System.Collections.Generic;

class TwoQueueStack<T>
{
    private Queue<T> primaryQueue = new Queue<T>();
    private Queue<T> secondaryQueue = new Queue<T>();

    public void Push(T item)
    {
        primaryQueue.Enqueue(item);
    }

    public T Pop()
    {
        if (primaryQueue.Count == 0)
        {
            throw new InvalidOperationException("Empyt queue.");
        }

        while (primaryQueue.Count > 1)
        {
            secondaryQueue.Enqueue(primaryQueue.Dequeue());
        }

        T poppedItem = primaryQueue.Dequeue();

        SwapQueues();

        return poppedItem;
    }

    public T Peek()
    {
        if (primaryQueue.Count == 0)
        {
            throw new InvalidOperationException("Empyt queue.");
        }

        while (primaryQueue.Count > 1)
        {
            secondaryQueue.Enqueue(primaryQueue.Dequeue());
        }

        T topItem = primaryQueue.Peek();

        SwapQueues();

        return topItem;
    }

    public int Count
    {
        get { return primaryQueue.Count; }
    }

    private void SwapQueues()
    {
        Queue<T> temp = primaryQueue;
        primaryQueue = secondaryQueue;
        secondaryQueue = temp;
    }

    public void PrintQueues()
    {
        Console.WriteLine("Primary queue:");
        foreach (var item in primaryQueue)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Secundary Queue:");
        foreach (var item in secondaryQueue)
        {
            Console.WriteLine(item);
        }
    }
}

class Test
{
    static void Main(string[] args)
    {
        TwoQueueStack<int> stack = new TwoQueueStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Stack top: " + stack.Peek());

        Console.WriteLine("Queue content:");
        stack.PrintQueues();

        Console.WriteLine("Unstacking objects:");
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}
