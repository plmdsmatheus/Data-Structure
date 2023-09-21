using System;
using System.Collections;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class Queue<T>
{
    private Node<T> front;
    private Node<T> rear;
    private int size;

    public Queue()
    {
        front = null;
        rear = null;
        size = 0;
    }

    public int Count
    {
        get { return size; }
    }

    public bool IsEmpty
    {
        get { return size == 0; }
    }

    public void Enqueue(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (rear == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }

        size++;
    }

    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        T data = front.Data;
        front = front.Next;
        size--;

        if (front == null)
        {
            rear = null;
        }

        return data;
    }

    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        return front.Data;
    }

    public void MostrarFila()
    {
        if (IsEmpty)
        {
            Console.WriteLine("A fila está vazia.");
            return;
        }

        Console.Write("Fila atual: ");
        Node<T> currentNode = front;
        while (currentNode != null)
        {
            Console.Write(currentNode.Data + " ");
            currentNode = currentNode.Next;
        }
        Console.WriteLine();
    }

    public void Clear()
    {
        front = null;
        rear = null;
    }
}

class Test
{
    static void Main(string[] args)
    {
        Queue<int> fila = new Queue<int>();

        fila.Enqueue(1);
        fila.Enqueue(2);
        fila.Enqueue(3);

        fila.MostrarFila();

        Console.WriteLine("Elemento no início da fila: " + fila.Peek());
        Console.WriteLine("Removendo elemento da fila: " + fila.Dequeue());
        Console.WriteLine("");
        fila.Enqueue(4);
        fila.MostrarFila();

        Console.WriteLine("Elemento no início da fila: " + fila.Peek());
        Console.WriteLine("Tamanho da fila: " + fila.Count);
        Console.WriteLine("");
        Console.WriteLine("-- Fila Limpa -- ");
        fila.Clear();
        fila.MostrarFila();
    }
}
