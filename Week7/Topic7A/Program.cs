using System;
using System.Collections.Generic;




//notes : sortedset keep element sorted. and set means removing duplicates element
class Program
{
    static void Main()
    {
        SortedSet<int> scores = new SortedSet<int>();

        scores.Add(65);
        scores.Add(80);
        scores.Add(45);
        scores.Add(92);
        scores.Add(70);
        scores.Add(55);
        scores.Add(88);
        scores.Add(76);
        scores.Add(60);
        scores.Add(95);

        Console.WriteLine("Original scores:");
        DisplayScores(scores);

        
        scores.Add(100);

        Console.WriteLine("After adding a new high score:");
        DisplayScores(scores);

        scores.Add(80);

        Console.WriteLine("After adding a duplicate score:");
        DisplayScores(scores);

        BankAccount account1 = new BankAccount("Alice", 1000);
        BankAccount account2 = new BankAccount("Bob", 2500);
        BankAccount account3 = new BankAccount("Charlie", 800);
        BankAccount account4 = new BankAccount("David", 3200);
        BankAccount account5 = new BankAccount("Emma", 1500);
        BankAccount account6 = new BankAccount("Frank", 900);
        BankAccount account7 = new BankAccount("Grace", 2100);
        BankAccount account8 = new BankAccount("Henry", 1700);
        BankAccount account9 = new BankAccount("Ivy", 4000);
        BankAccount account10 = new BankAccount("Jack", 1200);

        SortedSet<BankAccount> accounts = new SortedSet<BankAccount>();

        accounts.Add(account1);
        accounts.Add(account2);
        accounts.Add(account3);
        accounts.Add(account4);
        accounts.Add(account5);
        accounts.Add(account6);
        accounts.Add(account7);
        accounts.Add(account8);
        accounts.Add(account9);
        accounts.Add(account10);
    }

    static void DisplayScores(SortedSet<int> scores)
    {
        int lowest = int.MaxValue;
        int highest = int.MinValue;

        foreach (int score in scores)
        {
            Console.WriteLine(score);

            if (score < lowest)
            {
                lowest = score;
            }

            if (score > highest)
            {
                highest = score;
            }
        }

        Console.WriteLine("Lowest score: " + lowest);
        Console.WriteLine("Highest score: " + highest);
    }


    //uncomplete, find a time to fix it

    
}