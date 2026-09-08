
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> history = new Stack<string>();

        history.Push("Text");
        history.Push("Image");
        history.Push("Colour");

        Console.WriteLine("Initial Stack:");

        foreach (string action in history)
        {
            Console.WriteLine(action);
        }

        Console.WriteLine("\nTop item:");
        Console.WriteLine(history.Peek());

        history.Pop();

        Console.WriteLine("Other item Pop:");

        foreach (string action in history)
        {
            Console.WriteLine(action);
        }
        Queue<string> jobs = new Queue<string>();

        jobs.Enqueue("Print Job 1");
        jobs.Enqueue("Print Job 2");
        jobs.Enqueue("Print Job 3");

        Console.WriteLine("Initial Queue:");

        foreach (string job in jobs)
        {
            Console.WriteLine(job);
        }

        Console.WriteLine("\nFront item:");
        Console.WriteLine(jobs.Peek());

        jobs.Dequeue();

        Console.WriteLine("Other Dequeue:");

        foreach (string job in jobs)
        {
            Console.WriteLine(job);
        }

        Stack<BankAccount> accounts = new Stack<BankAccount>();

        accounts.Push(new BankAccount("Alice", 1000));
        accounts.Push(new BankAccount("Bob", 2000));
        accounts.Push(new BankAccount("Charlie", 3000));
        accounts.Push(new BankAccount("David", 4000));
        accounts.Push(new BankAccount("Emma", 5000));
        accounts.Push(new BankAccount("Frank", 6000));
        accounts.Push(new BankAccount("Grace", 7000));
        accounts.Push(new BankAccount("Henry", 8000));
        accounts.Push(new BankAccount("Ivy", 9000));
        accounts.Push(new BankAccount("Jack", 10000));

        Console.WriteLine("Stack:");

        foreach (BankAccount account in accounts)
        {
            Console.WriteLine(account);
        }

        Queue<BankAccount> queue = StackToQueue(accounts);

        Console.WriteLine("Queue:");

        foreach (BankAccount account in queue)
        {
            Console.WriteLine(account);
        }
    }

    static Queue<BankAccount> StackToQueue(Stack<BankAccount> stack)
    {
        Queue<BankAccount> queue = new Queue<BankAccount>();

        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }

        return queue;
    }
}