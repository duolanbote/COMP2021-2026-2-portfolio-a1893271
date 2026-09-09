using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        
        List<string> names = new List<string>()
        {
            "Tom", "Jack", "Alice", "David", "Bob",
            "Lucy", "John", "Emma", "Peter", "Mary"
        };

        var orderedNames = names.OrderBy(x => x).ToList();

        Console.WriteLine("Task 1:");

        foreach (string name in orderedNames)
        {
            Console.WriteLine(name);
        }


        
        

    Stack<BankAccount> accountsStack = new Stack<BankAccount>();

    accountsStack.Push(new BankAccount("Tom", 1000));
    accountsStack.Push(new BankAccount("Alice", 2000));
    accountsStack.Push(new BankAccount("Jack", 1500));
    accountsStack.Push(new BankAccount("Bob", 3000));
    accountsStack.Push(new BankAccount("Lucy", 2500));
    accountsStack.Push(new BankAccount("David", 1800));
    accountsStack.Push(new BankAccount("Emma", 2200));
    accountsStack.Push(new BankAccount("John", 1200));
    accountsStack.Push(new BankAccount("Mary", 2700));
    accountsStack.Push(new BankAccount("Peter", 1600));

    var stackOwners = accountsStack
        .Select(x => x.Owner)
        .OrderBy(x => x);

    Console.WriteLine("Stack:");

    foreach (string owner in stackOwners)
    {
        Console.WriteLine(owner);
    }


    

    Queue<BankAccount> accountsQueue = new Queue<BankAccount>();

    accountsQueue.Enqueue(new BankAccount("Tom", 1000));
    accountsQueue.Enqueue(new BankAccount("Alice", 2000));
    accountsQueue.Enqueue(new BankAccount("Jack", 1500));
    accountsQueue.Enqueue(new BankAccount("Bob", 3000));
    accountsQueue.Enqueue(new BankAccount("Lucy", 2500));
    accountsQueue.Enqueue(new BankAccount("David", 1800));
    accountsQueue.Enqueue(new BankAccount("Emma", 2200));
    accountsQueue.Enqueue(new BankAccount("John", 1200));
    accountsQueue.Enqueue(new BankAccount("Mary", 2700));
    accountsQueue.Enqueue(new BankAccount("Peter", 1600));

    var queueOwners = accountsQueue
        .Select(x => x.Owner)
        .OrderBy(x => x);

    Console.WriteLine("Queue:");

    foreach (string owner in queueOwners)
    {
        Console.WriteLine(owner);
    }

    var filteredStack = accountsStack
    .Where(x => x.Owner.Contains("e"))
    .OrderBy(x => x.Balance)
    .Select(x => x.Owner);

    Console.WriteLine("Stack:");

    foreach (string owner in filteredStack)
    {
        Console.WriteLine(owner);
    }


    /
    var filteredQueue = accountsQueue
        .Where(x => x.Owner.Contains("e"))
        .OrderBy(x => x.Balance)
        .Select(x => x.Owner);

    Console.WriteLine("Queue:");

    foreach (string owner in filteredQueue)
    {
        Console.WriteLine(owner);
    }
    }
}