using System;

public class SkipListNode
{
    public int Value { get; }
    public SkipListNode[] Next { get; }

    public SkipListNode(int value, int level)
    {
        Value = value;
        Next = new SkipListNode[level + 1];
    }
}

public class SkipList
{
    private const int MaxLevels = 16;
    private const double Probability = 0.5;

    private readonly Random random = new Random();
    private SkipListNode head = new SkipListNode(int.MinValue, MaxLevels);
    private int level = 0;

    public void Insert(int value)
    {
        var update = new SkipListNode[MaxLevels + 1];
        var current = head;

        for (int i = level; i >= 0; i--)
        {
            while (current.Next[i] != null && current.Next[i].Value < value)
            {
                current = current.Next[i];
            }

            update[i] = current;
        }

        var newLevel = RandomLevel();
        if (newLevel > level)
        {
            for (int i = level + 1; i <= newLevel; i++)
            {
                update[i] = head;
            }
            level = newLevel;
        }

        var newNode = new SkipListNode(value, newLevel);
        for (int i = 0; i <= newLevel; i++)
        {
            newNode.Next[i] = update[i].Next[i];
            update[i].Next[i] = newNode;
        }
    }
    public bool Remove(int value)
    {
        var update = new SkipListNode[MaxLevels + 1];
        var current = head;

        for (int i = level; i >= 0; i--)
        {
            while (current.Next[i] != null && current.Next[i].Value < value)
            {
                current = current.Next[i];
            }

            update[i] = current;
        }

        current = current.Next[0];

        if (current != null && current.Value == value)
        {
            for (int i = 0; i <= level; i++)
            {
                if (update[i].Next[i] != current)
                {
                    break;
                }

                update[i].Next[i] = current.Next[i];
            }

            while (level > 0 && head.Next[level] == null)
            {
                level--;
            }

            return true;
        }

        return false;
    }


    public bool Search(int value)
    {
        var current = head;
        for (int i = level; i >= 0; i--)
        {
            while (current.Next[i] != null && current.Next[i].Value < value)
            {
                current = current.Next[i];
            }
        }

        current = current.Next[0];
        return current != null && current.Value == value;
    }

    public void Print()
    {
        for (int i = level; i >= 0; i--)
        {
            var current = head;
            while (current.Next[i] != null)
            {
                Console.Write(current.Next[i].Value + " ");
                current = current.Next[i];
            }
            Console.WriteLine();
        }
    }

    private int RandomLevel()
    {
        int newLevel = 0;
        while (random.NextDouble() < Probability && newLevel < MaxLevels)
        {
            newLevel++;
        }
        return newLevel;
    }
}

public class SkipListTest
{
    public static void Main()
    {
        SkipList skipList = new SkipList();

        skipList.Insert(3);
        skipList.Insert(6);
        skipList.Insert(7);
        skipList.Insert(9);
        skipList.Insert(12);
        skipList.Insert(19);
        skipList.Insert(17);
        skipList.Insert(26);
        skipList.Insert(21);
        skipList.Insert(25);

        Console.WriteLine("Skip List:");
        skipList.Print();

        int searchValue = 19;
        Console.WriteLine($"\nProcura por {searchValue}: {skipList.Search(searchValue)}");

        int removeValue = 26;
        Console.WriteLine($"Remoção de {removeValue}: {skipList.Remove(removeValue)}");

        Console.WriteLine("\nSkip List depois da remoção:");
        skipList.Print();
    }
}
