using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist_and_generics
{


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

    public class LinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public LinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void AddAt(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            if (index == Count)
            {
                AddLast(data);
                return;
            }

            Node<T> newNode = new Node<T>(data);
            Node<T> current = head;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
            Count++;
        }

        public void RemoveFirst()
        {
            if (head == null) throw new InvalidOperationException("List is empty.");

            head = head.Next;
            if (head == null) tail = null;
            Count--;
        }

        public void RemoveLast()
        {
            if (head == null) throw new InvalidOperationException("List is empty.");

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                tail = current;
            }
            Count--;
        }

        public void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int>();  // Create a new linked list of type int

            while (true)  // Infinite loop for repeated user input
            {
                // Display options to the user
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add element at the beginning");
                Console.WriteLine("2. Add element at the end");
                Console.WriteLine("3. Add element at a specific position");
                Console.WriteLine("4. Remove the first element");
                Console.WriteLine("5. Remove the last element");
                Console.WriteLine("6. Print the list");
                Console.WriteLine("7. Exit the program");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the element to add at the beginning: ");
                        int firstElement = int.Parse(Console.ReadLine());
                        list.AddFirst(firstElement);
                        break;

                    case 2:
                        Console.Write("Enter the element to add at the end: ");
                        int lastElement = int.Parse(Console.ReadLine());
                        list.AddLast(lastElement);
                        break;

                    case 3:
                        Console.Write("Enter the position to add the element: ");
                        int position = int.Parse(Console.ReadLine());
                        Console.Write("Enter the element to add: ");
                        int elementAtPosition = int.Parse(Console.ReadLine());
                        try
                        {
                            list.AddAt(position, elementAtPosition);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            list.RemoveFirst();
                            Console.WriteLine("Removed the first element.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        try
                        {
                            list.RemoveLast();
                            Console.WriteLine("Removed the last element.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 6:
                        Console.WriteLine("Current list:");
                        list.PrintList();
                        break;

                    case 7:
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }






}   

