using System;

public class Node<T>
{
    public T Element { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Previous { get; set; }

    public Node(T element)
    {
        Element = element;
        Next = null;
        Previous = null;
    }
}

public class DoublyLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public int Size()
    {
        return count;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFirst(Node<T> node)
    {
        return node == head;
    }

    public bool IsLast(Node<T> node)
    {
        return node == tail;
    }

    public Node<T> First()
    {
        if (IsEmpty())
            throw new InvalidOperationException("A lista está vazia.");
        return head;
    }

    public Node<T> Last()
    {
        if (IsEmpty())
            throw new InvalidOperationException("A lista está vazia.");
        return tail;
    }

    public Node<T> Before(Node<T> node)
    {
        if (node.Previous == null)
            throw new InvalidOperationException("O nó não tem um nó anterior.");
        return node.Previous;
    }

    public Node<T> After(Node<T> node)
    {
        if (node.Next == null)
        {
            throw new InvalidOperationException("O nó não tem um proximo nó .");
        }
        return node.Next;
    }

    public void ReplaceElement(Node<T> node, T element)
    {
        node.Element = element;
    }

    public void SwapElements(Node<T> node1, Node<T> node2)
    {
        T temp = node1.Element;
        node1.Element = node2.Element;
        node2.Element = temp;
    }

    public void InsertBefore(Node<T> node, T element)
    {
        Node<T> newNode = new Node<T>(element);
        newNode.Previous = node.Previous;
        newNode.Next = node;
        if (node.Previous == null)
        {
            head = newNode;
        }
        else
        {
            node.Previous.Next = newNode;
        }
        node.Previous = newNode;
        count++;
    }

    public void InsertAfter(Node<T> node, T element)
    {
        Node<T> newNode = new Node<T>(element);
        newNode.Previous = node;
        newNode.Next = node.Next;
        if (node.Next == null)
        {
            tail = newNode;
        }
        else
        {
            node.Next.Previous = newNode;
        }
        node.Next = newNode;
        count++;
    }

    public void InsertFirst(T element)
    {
        Node<T> newNode = new Node<T>(element);
        newNode.Next = head;
        if (head == null)
        {
            tail = newNode;
        }
        else
        {
            head.Previous = newNode;
        }
        head = newNode;
        count++;
    }

    public void InsertLast(T element)
    {
        Node<T> newNode = new Node<T>(element);
        newNode.Previous = tail;
        if (tail == null)
        {
            head = newNode;
        }
        else
        {
            tail.Next = newNode;
        }
        tail = newNode;
        count++;
    }

    public void Remove(Node<T> node)
    {
        if (node.Previous == null)
        {
            head = node.Next;
        }
        else
        {
            node.Previous.Next = node.Next;
        }

        if (node.Next == null)
        {
            tail = node.Previous;
        }
        else
        {
            node.Next.Previous = node.Previous;
        }

        count--;
    }
}
class Test
{
    static void Main(string[] args)
    {
        DoublyLinkedList<int> list = new DoublyLinkedList<int>();

        Console.WriteLine("Empty list? " + list.IsEmpty());
        Console.WriteLine("Size: " + list.Size());

        list.InsertFirst(1);
        list.InsertLast(2);
        list.InsertAfter(list.First(), 3);
        list.InsertBefore(list.Last(), 4);

        Console.WriteLine("is empty list? " + list.IsEmpty());
        Console.WriteLine("Size: " + list.Size());

        Console.WriteLine("First object " + list.First().Element);
        Console.WriteLine("Last object: " + list.Last().Element);

        Console.WriteLine("Object before last: " + list.Before(list.Last()).Element);
        Console.WriteLine("Object after first: " + list.After(list.First()).Element);

        Console.WriteLine("List objects:");
        Node<int> currentNode = list.First();
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Element);
            currentNode = list.After(currentNode);
        }

        list.Remove(list.First());

        Console.WriteLine("Object in the list after the first one is removed:");
        currentNode = list.First();
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Element);
            currentNode = list.After(currentNode);
        }
    }
}
