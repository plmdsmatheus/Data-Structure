using System;

namespace Data_Structure
{
    class FilaArrayCircular<T>
    {
        private T[] items;
        private int capacidade;
        private int tamanho;
        private int inicio;
        private int fim;

         public void MostrarArray()
    {
        for (int i = 0; i < capacidade; i++)
        {
            Console.Write(items[i]);
            if (i != capacidade - 1)
            {
                Console.Write(" -> ");
            }
        }
        Console.WriteLine();
    }

        public T PrimeiroElemento(){
        if (EstaVazia())
        {
            throw new InvalidOperationException("A fila está vazia");
        }

        return items[inicio];
    }

        public FilaArrayCircular(int capacidadeInicial)
        {
            capacidade = capacidadeInicial;
            items = new T[capacidade];
            tamanho = 0;
            inicio = 0;
            fim = -1;
        }

        public bool EstaVazia()
        {
            return tamanho == 0;
        }

        public bool EstaCheia()
        {
            return tamanho == capacidade;
        }

        public int Tamanho()
        {
            return tamanho;
        }

        public void Enfileirar(T item)
        {
            if (EstaCheia())
            {
                DuplicarArray();
            }

            fim = (fim + 1) % capacidade;
            items[fim] = item;
            tamanho++;
        }

        public T Desenfileirar()
        {
            if (EstaVazia())
            {
                throw new InvalidOperationException("A fila está vazia");
            }

            T itemDesenfileirado = items[inicio];
            items[inicio] = default(T);
            inicio = (inicio + 1) % capacidade;
            tamanho--;
            return itemDesenfileirado;
        }

        private void DuplicarArray()
        {
            int novaCapacidade = capacidade * 2;
            T[] novoArray = new T[novaCapacidade];

            for (int i = 0; i < tamanho; i++)
            {
                novoArray[i] = items[(inicio + i) % capacidade];
            }

            items = novoArray;
            capacidade = novaCapacidade;
            inicio = 0;
            fim = tamanho - 1;
        }
    }

    class FilaTest
    {
        static void Main()
        {
            FilaArrayCircular<int> fila = new FilaArrayCircular<int>(5);

            Console.WriteLine("Enqueue objects:");
            for (int i = 1; i <= 8; i++)
            {
                fila.Enfileirar(i);
                Console.WriteLine($"Enqueue: {i}, Size: {fila.Tamanho()}");
            }

            Console.WriteLine($"\nFirst Object: {fila.PrimeiroElemento()}");
            fila.MostrarArray();

            Console.WriteLine("\nDequeue objects:");
            while (!(fila.EstaVazia()))
            {
                int item = fila.Desenfileirar();
                Console.WriteLine($"Dequeue: {item}, Size: {fila.Tamanho()}");
            }
            fila.Enfileirar(5);
            fila.Enfileirar(4);
            fila.Enfileirar(3);
            fila.Enfileirar(2);
            fila.Enfileirar(1);
            fila.MostrarArray();
        }
    }
}
