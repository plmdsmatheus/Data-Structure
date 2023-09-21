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

public class lista<T>
{
    private Node<T> front;
    private Node<T> rear;

    public lista()
    {
        front = null;
        rear = null;
    }

    public bool IsEmpty()
    {
        return front == null;
    }

    public void Enlista(T item)
    {
        Node<T> newNode = new Node<T>(item);

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
    }

    public T Delista()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        T data = front.Data;
        front = front.Next;

        if (front == null)
        {
            rear = null;
        }

        return data;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        return front.Data;
    }

    public void Clear()
    {
        front = null;
        rear = null;
    }

    public int Count()
    {
        int count = 0;
        Node<T> current = front;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public void Listar()
    {
        if (IsEmpty())
        {
            Console.WriteLine("A fila está vazia.");
        }
        else
        {
            Console.Write("Conteúdo da fila: ");
            Node<T> current = front;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}

class Test
{
    static void Main(string[] args)
    {
        lista<int> lista = new lista<int>();

        // Enfileirar elementos
        lista.Enlista(1);
        lista.Enlista(2);
        lista.Enlista(3);

        lista.Listar();

        // Desenfileirar e imprimir elementos
        Console.WriteLine("Elemento desenfileirado: " + lista.Delista()); // Deve imprimir 1
        Console.WriteLine("Elemento desenfileirado: " + lista.Delista()); // Deve imprimir 2

        // Verificar o elemento na frente da fila
        Console.WriteLine("Elemento na frente da fila: " + lista.Peek()); // Deve imprimir 3

        // Contar elementos na fila
        Console.WriteLine("Número de elementos na fila: " + lista.Count()); // Deve imprimir 1

        // Limpar a fila
        lista.Clear();
        Console.WriteLine("Fila limpa. Vazia? " + lista.IsEmpty()); // Deve imprimir True
    }
}
